using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class GuestEntry
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Сообщение обязательно")]
        public string Message { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}