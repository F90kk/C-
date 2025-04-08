using LibraryApp.Data;
using LibraryApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.Models;

namespace LibraryApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            var context = new LibraryContext();
            _viewModel = new MainViewModel(new BookRepository(context), new LoanRepository(context));
            DataContext = _viewModel;
        }
        
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is Book selectedBook)
            {
                var readerWindow = new ReaderWindow(selectedBook.FilePath);
                readerWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}