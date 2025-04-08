using LibraryApp.Data;
using LibraryApp.Helpers;
using LibraryApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Loan> _loanRepo;
        private ObservableCollection<Book> _books;
        private string _searchQuery;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                SearchBooks();
            }
        }

        public ICommand AddBookCommand { get; set; }
        public BooksViewModel BooksViewModel { get; }
        public LoansViewModel LoansViewModel { get; }

        public MainViewModel(IRepository<Book> bookRepo, IRepository<Loan> loanRepo)
        {
            _bookRepo = bookRepo;
            _loanRepo = loanRepo;
            Books = new ObservableCollection<Book>();
            BooksViewModel = new BooksViewModel(_bookRepo);
            LoansViewModel = new LoansViewModel(_loanRepo, Books);
            AddBookCommand = new RelayCommand(AddBook);
            LoadDataAsync().GetAwaiter().GetResult();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var books = await _bookRepo.GetAllAsync();
                Books.Clear();
                foreach (var book in books) Books.Add(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void SearchBooks()
        {
            try
            {
                if (string.IsNullOrEmpty(SearchQuery))
                {
                    LoadDataAsync().GetAwaiter().GetResult();
                    return;
                }

                var filtered = Books?.Where(b =>
                    b.Title?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    b.Author?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (filtered != null)
                {
                    Books = new ObservableCollection<Book>(filtered);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске книг: {ex.Message}");
            }
        }

        private void AddBook()
        {
            var addBookWindow = new Views.AddBookWindow();
            if (addBookWindow.ShowDialog() == true)
            {
                var vm = addBookWindow.DataContext as AddBookViewModel;
                var book = new Book
                {
                    Title = vm.Title,
                    Author = vm.Author,
                    Genre = "Unknown", // Добавлено для совместимости с новой структурой
                    FilePath = vm.FilePath
                };
                _bookRepo.AddAsync(book).GetAwaiter().GetResult();
                _bookRepo.SaveAsync().GetAwaiter().GetResult();
                Books.Add(book);
            }
        }
    }
}