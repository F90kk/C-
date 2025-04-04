using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly LibraryService _libraryService;
        private string _newTitle;
        private string _newAuthor;
        private string _searchAuthor;
        private string _searchTitle;
        private bool _isLoading;
        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
                OnPropertyChanged(nameof(FilteredBooks));
            }
        }

        public ObservableCollection<Book> FilteredBooks
        {
            get
            {
                if (string.IsNullOrEmpty(SearchAuthor))
                    return Books;
                return new ObservableCollection<Book>(
                    Books.Where(b => b.Author.IndexOf(SearchAuthor, StringComparison.OrdinalIgnoreCase) >= 0));
            }
        }

        public string NewTitle
        {
            get => _newTitle;
            set
            {
                _newTitle = value;
                MessageBox.Show($"NewTitle обновлено: {value}", "Отладка", MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged(nameof(NewTitle));
            }
        }

        public string NewAuthor
        {
            get => _newAuthor;
            set
            {
                _newAuthor = value;
                MessageBox.Show($"NewAuthor обновлено: {value}", "Отладка", MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged(nameof(NewAuthor));
            }
        }

        public string SearchAuthor
        {
            get => _searchAuthor;
            set
            {
                _searchAuthor = value;
                OnPropertyChanged(nameof(SearchAuthor));
                OnPropertyChanged(nameof(FilteredBooks));
            }
        }

        public string SearchTitle
        {
            get => _searchTitle;
            set
            {
                _searchTitle = value;
                OnPropertyChanged(nameof(SearchTitle));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand AddBookCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand ToggleBookCommand { get; }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Title = "Война и мир", Author = "Л. Толстой", IsAvailable = true },
                new Book { Title = "1984", Author = "Дж. Оруэлл", IsAvailable = false }
            };

            _libraryService = new LibraryService(Books);

            AddBookCommand = new RelayCommand(AddBook);
            SearchCommand = new RelayCommand(async () => await SearchBooksAsync());
            ToggleBookCommand = new RelayCommand<Book>(ToggleBookAvailability);
        }

        private void AddBook()
        {
            if (string.IsNullOrEmpty(NewTitle) || string.IsNullOrEmpty(NewAuthor))
            {
                MessageBox.Show("Пожалуйста, заполните поля 'Название книги' и 'Автор'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newBook = new Book
            {
                Title = NewTitle,
                Author = NewAuthor,
                IsAvailable = true
            };
            Books.Add(newBook);
            _libraryService.AddBook(newBook);
            MessageBox.Show($"Книга '{newBook.Title}' от '{newBook.Author}' успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NewTitle = string.Empty;
            NewAuthor = string.Empty;
            OnPropertyChanged(nameof(FilteredBooks));
        }

        private async Task SearchBooksAsync()
        {
            IsLoading = true;
            var results = await _libraryService.SearchBooksAsync(SearchTitle ?? "");
            Books.Clear();
            foreach (var book in results)
            {
                Books.Add(book);
            }
            IsLoading = false;
            OnPropertyChanged(nameof(FilteredBooks));
            MessageBox.Show($"Поиск завершён. Найдено книг: {Books.Count}.", "Результат поиска", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToggleBookAvailability(Book book)
        {
            _libraryService.ToggleBookAvailability(book);
            MessageBox.Show($"Статус книги '{book.Title}' изменён на: {(book.IsAvailable ? "В наличии" : "Занята")}.", "Статус изменён", MessageBoxButton.OK, MessageBoxImage.Information);
            OnPropertyChanged(nameof(FilteredBooks));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}