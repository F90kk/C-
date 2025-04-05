using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class AddBookViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _author;
        private readonly Window _window;

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

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                if (value != _year)
                {
                    _year = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public AddBookViewModel(Window window)
        {
            _window = window;
            AddCommand = new RelayCommand(AddBook, CanAddBook);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddBook()
        {
            _window.DialogResult = true;
            _window.Close();
        }

        private bool CanAddBook()
        {
            return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author) && Year > 0;
        }

        private void Cancel()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}