using LibraryApp.Data;
using LibraryApp.Helpers;
using LibraryApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class LoansViewModel : ProjectViewModel<Loan>
    {
        private Book _selectedBook;
        private string _borrower;
        public ICommand BorrowBookCommand { get; }
        public ICommand ReturnBookCommand { get; }

        public Book SelectedBook
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
        }

        public string Borrower
        {
            get => _borrower;
            set { _borrower = value; OnPropertyChanged(); }
        }

        public LoansViewModel(IRepository<Loan> repo, ObservableCollection<Book> books) : base(repo)
        {
            Books = books;

            BorrowBookCommand = new AsyncRelayCommand(async () =>
            {
                if (SelectedBook != null && !string.IsNullOrEmpty(Borrower))
                {
                    var newLoan = new Loan
                    {
                        BookId = SelectedBook.Id,
                        Borrower = Borrower,
                        LoanDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        ReturnDate = null
                    };
                    await _repo.AddAsync(newLoan);
                    await _repo.SaveAsync();
                    ((AsyncRelayCommand)LoadCommand).Execute(null);
                    Borrower = string.Empty;
                    SelectedBook = null;
                }
            });

            ReturnBookCommand = new AsyncRelayCommand(async () =>
            {
                if (SelectedItem != null && SelectedItem.ReturnDate == null)
                {
                    SelectedItem.ReturnDate = DateTime.Now.ToString("yyyy-MM-dd");
                    await _repo.SaveAsync();
                    ((AsyncRelayCommand)LoadCommand).Execute(null);
                }
            });
        }

        public ObservableCollection<Book> Books { get; }
    }
}