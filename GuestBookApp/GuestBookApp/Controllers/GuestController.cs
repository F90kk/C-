using GuestBookApp.Models;
using GuestBookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class GuestController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public GuestController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult Recent()
        {
            var feedbacks = _feedbackService.GetRecentFeedback();
            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entry = new GuestEntry
            {
                Name = model.Name,
                Message = $"{model.Message} (Рейтинг: {model.Rating})"
            };

            _feedbackService.SaveFeedback(entry);

            TempData["FeedbackMessage"] = "Спасибо за отзыв";
            return RedirectToAction("Recent");
        }
    }
}
