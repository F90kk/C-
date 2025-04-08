using LibraryApp.Helpers;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private string _title;
        private string _author;
        private int _year;
        private string _description;
        private string _filePath;
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

        public int Year
        {
            get => _year;
            set { _year = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        public string FilePath
        {
            get => _filePath;
            set { _filePath = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public AddBookViewModel(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            AddCommand = new RelayCommand(AddBook, CanAddBook);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddBook()
        {
            try
            {
                _window.DialogResult = true;
                _window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        private bool CanAddBook()
        {
            return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author) && Year > 0 && !string.IsNullOrEmpty(FilePath);
        }

        private void Cancel()
        {
            try
            {
                _window.DialogResult = false;
                _window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене: {ex.Message}");
            }
        }
    }
}