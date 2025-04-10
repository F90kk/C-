using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите отзыв")]
        [StringLength(500, ErrorMessage = "Отзыв не может превышать 500 символов")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Укажите рейтинг")]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }
    }
}
