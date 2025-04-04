using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibrary
{
    public class LibraryService
    {
        private readonly List<BookModel> _books;

        public LibraryService()
        {
            _books = new List<BookModel>
            {
                new BookModel { Title = "Book 1", Author = new AuthorModel { Name = "Author A" }, IsAvailable = true },
                new BookModel { Title = "Book 2", Author = new AuthorModel { Name = "Author B" }, IsAvailable = false },
                new BookModel { Title = "Book 3", Author = new AuthorModel { Name = "Author C" }, IsAvailable = true }
            };
        }

        public async Task<List<BookModel>> SearchBooksAsync(string searchTerm)
        {
            await Task.Delay(1500);
            return _books.FindAll(b => b.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public bool BookBook(BookModel book)
        {
            if (book.IsAvailable)
            {
                book.IsAvailable = false;
                return true;
            }
            return false;
        }
    }
}