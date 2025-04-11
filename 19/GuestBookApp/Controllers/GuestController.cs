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

        public IActionResult Recent()
        {
            var model = new GuestViewModel
            {
                Entries = entries.OrderByDescending(e => e.Date).ToList(),
                NewEntry = new GuestEntry()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recent([FromForm] GuestViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewEntry.Date = DateTime.Now;
                entries.Add(model.NewEntry);

                TempData["ShowSuccessMessage"] = true;

                var newModel = new GuestViewModel
                {
                    Entries = entries.OrderByDescending(e => e.Date).ToList(),
                    NewEntry = new GuestEntry
                    {
                        Name = model.NewEntry.Name, 
                        Message = model.NewEntry.Message 
                    }
                };

                return View(newModel);
            }

            model.Entries = entries.OrderByDescending(e => e.Date).ToList();
            return View(model);
        }

    }
}