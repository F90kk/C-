using System;
using System.Collections.Generic;
using System.Linq;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly List<GuestEntry> _feedbackList = new List<GuestEntry>();

        public void SaveFeedback(GuestEntry entry)
        {
            entry.Date = DateTime.Now;
            _feedbackList.Add(entry);
        }

        public IEnumerable<GuestEntry> GetRecentFeedback()
        {
            return _feedbackList
                .OrderByDescending(f => f.Date)
                .Take(10);
        }
    }
}
