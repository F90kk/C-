using Microsoft.EntityFrameworkCore;
using GuestBookApp.Models;
using System.Collections.Generic;

namespace GuestBookApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
