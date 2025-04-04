using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ElectronicLibrary
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private readonly LibraryService _libraryService;
        private string _searchTerm;
        private bool _isLoading;
        private ObservableCollection<BookModel> _books;

        public LibraryViewModel()
        {
            _libraryService = new LibraryService();
            Books = new ObservableCollection<BookModel>();
            SearchCommand = new RelayCommand(async () => await SearchBooksAsync());
            BookCommand = new RelayCommand<BookModel>(BookBook);
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BookModel> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand BookCommand { get; }

        private async Task SearchBooksAsync()
        {
            IsLoading = true;
            var results = await _libraryService.SearchBooksAsync(SearchTerm ?? "");
            Books.Clear();
            foreach (var book in results)
            {
                Books.Add(book);
            }
            IsLoading = false;
        }

        private void BookBook(BookModel book)
        {
            if (_libraryService.BookBook(book))
            {
                MessageBox.Show("Книга успешно забронирована!");
                OnPropertyChanged(nameof(Books));
            }
            else
            {
                MessageBox.Show("Книга недоступна.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}