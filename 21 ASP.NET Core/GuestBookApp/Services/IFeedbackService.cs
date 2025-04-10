using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public interface IFeedbackService
    {
        void AddFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DeleteFeedback(int id);
        Feedback GetFeedbackById(int id);
        IEnumerable<Feedback> GetAllFeedback();
    }
}
