using System.Windows;
using System.Windows.Controls;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddBook();
        }

        private void TakeBook_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Book book)
            {
                _viewModel.TakeBook(book);
            }
        }
    }
}