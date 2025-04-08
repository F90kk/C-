using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.Include(l => l.Book).ToListAsync();
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public async Task DeleteAsync(Loan loan)
        {
            _context.Loans.Remove(loan);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}