using System.Windows;

namespace LibraryApp
{
    public partial class AddBookWindow : Window
    {
        public Book NewBook { get; set; }

        public AddBookWindow()
        {
            InitializeComponent();
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

            NewBook = new Book
            {
                Title = TitleTextBox.Text,
                Author = AuthorTextBox.Text,
                Year = year,
                Publisher = PublisherTextBox.Text,
                ISBN = ISBNTextBox.Text
            };

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
