using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public interface IFeedbackService
    {
        void SaveFeedback(GuestEntry entry);
        IEnumerable<GuestEntry> GetRecentFeedback();
    }
}
