using System.Windows;

namespace LibraryApp
{
    public partial class EditBookWindow : Window
    {
        public Book EditedBook { get; set; }

        public EditBookWindow(Book book)
        {
            InitializeComponent();
            EditedBook = book;

            TitleTextBox.Text = book.Title;
            AuthorTextBox.Text = book.Author;
            YearTextBox.Text = book.Year.ToString();
            PublisherTextBox.Text = book.Publisher;
            ISBNTextBox.Text = book.ISBN;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(AuthorTextBox.Text) ||
                string.IsNullOrWhiteSpace(YearTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(YearTextBox.Text, out int year))
            {
                MessageBox.Show("Год должен быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditedBook.Title = TitleTextBox.Text;
            EditedBook.Author = AuthorTextBox.Text;
            EditedBook.Year = year;
            EditedBook.Publisher = PublisherTextBox.Text;
            EditedBook.ISBN = ISBNTextBox.Text;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
