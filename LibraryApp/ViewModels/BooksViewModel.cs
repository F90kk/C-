using LibraryApp.Data;
using LibraryApp.Helpers;
using LibraryApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class BooksViewModel : ProjectViewModel<Book>
    {
        private string _title;
        private string _author;
        private string _genre;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }

        public BooksViewModel(IRepository<Book> repo) : base(repo)
        {
            AddCommand = new AsyncRelayCommand(async () =>
            {
                var newBook = new Book { Title = Title, Author = Author, Genre = Genre };
                await _repo.AddAsync(newBook);
                await _repo.SaveAsync();
                ((AsyncRelayCommand)LoadCommand).Execute(null);
                Title = string.Empty;
                Author = string.Empty;
                Genre = string.Empty;
            });
        }
    }
}