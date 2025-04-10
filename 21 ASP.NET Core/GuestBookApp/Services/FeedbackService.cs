using System;
using System.Collections.Generic;
using System.Linq;
using GuestBookApp.Models;
using GuestBookApp.Data;

namespace GuestBookApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFeedback(Feedback feedback)
        {
            feedback.SubmittedAt = DateTime.Now;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            _context.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            return _context.Feedbacks.OrderByDescending(f => f.SubmittedAt).ToList();
        }
    }
}
