// Controllers/GuestController.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuestBookApp.Models;

namespace GuestBookApp.Controllers
{
    public class GuestController : Controller
    {
        private static List<GuestEntry> entries = new List<GuestEntry>();

        // GET: /Guest/Recent
        public IActionResult Recent()
        {
            var model = new GuestViewModel
            {
                Entries = entries.OrderByDescending(e => e.Date).ToList(),
                NewEntry = new GuestEntry()
            };
            return View(model);
        }

        // POST: /Guest/Recent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recent([FromForm] GuestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Добавляем новый комментарий
                model.NewEntry.Date = DateTime.Now;
                entries.Add(model.NewEntry);

                // Сохраняем данные формы в TempData для отображения после редиректа
                TempData["ShowSuccessMessage"] = true;

                // Создаем новую модель, чтобы сохранить введенные данные
                var newModel = new GuestViewModel
                {
                    Entries = entries.OrderByDescending(e => e.Date).ToList(),
                    NewEntry = new GuestEntry
                    {
                        Name = model.NewEntry.Name, // Сохраняем имя
                        Message = model.NewEntry.Message // Сохраняем сообщение
                    }
                };

                return View(newModel);
            }

            // Если валидация не пройдена, возвращаем страницу с ошибками
            model.Entries = entries.OrderByDescending(e => e.Date).ToList();
            return View(model);
        }

    }
}