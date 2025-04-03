using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace LibraryApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _newTitle;
        private string _newAuthor;
        private string _searchAuthor;

        public ObservableCollection<Book> Books { get; set; }
        public CollectionViewSource BooksViewSource { get; set; }

        public string NewTitle
        {
            get => _newTitle;
            set
            {
                _newTitle = value;
                OnPropertyChanged(nameof(NewTitle));
            }
        }

        public string NewAuthor
        {
            get => _newAuthor;
            set
            {
                _newAuthor = value;
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
                BooksViewSource.View.Refresh();
            }
        }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Title = "Война и мир", Author = "Л. Толстой", IsAvailable = true },
                new Book { Title = "1984", Author = "Дж. Оруэлл", IsAvailable = false }
            };

            BooksViewSource = new CollectionViewSource { Source = Books };
            BooksViewSource.Filter += BooksViewSource_Filter;
        }

        private void BooksViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchAuthor))
            {
                e.Accepted = true;
                return;
            }

            var book = e.Item as Book;
            e.Accepted = book?.Author.Contains(SearchAuthor) ?? false;
        }

        public void AddBook()
        {
            if (!string.IsNullOrEmpty(NewTitle) && !string.IsNullOrEmpty(NewAuthor))
            {
                Books.Add(new Book 
                { 
                    Title = NewTitle, 
                    Author = NewAuthor, 
                    IsAvailable = true 
                });
                NewTitle = string.Empty;
                NewAuthor = string.Empty;
            }
        }

        public void TakeBook(Book book)
        {
            book.IsAvailable = !book.IsAvailable;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}