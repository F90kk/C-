using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public MainViewModel()
        {
            // Инициализация коллекции книг (для примера)
            Books = new ObservableCollection<Book>()
            {
            };

            AddBookCommand = new RelayCommand(AddBook);
            EditBookCommand = new RelayCommand(EditBook, CanEditBook);
            DeleteBookCommand = new RelayCommand(DeleteBook, CanDeleteBook);
        }

        private void AddBook(object parameter)
        {
            var addBookWindow = new AddBookWindow();
            if (addBookWindow.ShowDialog() == true)
            {
                Book newBook = addBookWindow.NewBook;
                newBook.Id = Books.Count + 1;
                Books.Add(newBook);
            }
        }

        private void EditBook(object parameter)
        {
            if (SelectedBook != null)
            {
                var editBookWindow = new EditBookWindow(SelectedBook);
                if (editBookWindow.ShowDialog() == true)
                {
                    // Обновление книги выполняется в EditBookWindow
                    OnPropertyChanged(nameof(Books)); // Обновляем интерфейс
                }
            }
        }

        private bool CanEditBook(object parameter)
        {
            return SelectedBook != null;
        }

        private void DeleteBook(object parameter)
        {
            if (SelectedBook != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту книгу?", "Удаление книги", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Books.Remove(SelectedBook);
                }
            }
        }

        private bool CanDeleteBook(object parameter)
        {
            return SelectedBook != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
