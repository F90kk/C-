using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class LibraryService
    {
        private readonly List<Book> _books;

        public LibraryService(IEnumerable<Book> books)
        {
            _books = new List<Book>(books);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            await Task.Delay(1500); // Симуляция задержки для ProgressBar
            return _books.FindAll(b => b.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void ToggleBookAvailability(Book book)
        {
            book.IsAvailable = !book.IsAvailable;
        }
    }
}