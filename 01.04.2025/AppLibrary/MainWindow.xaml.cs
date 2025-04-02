using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace AppLibrary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CommandBindings.Add(new CommandBinding(CustomCommands.AddBook, AddBookCommand_Executed));
            CommandBindings.Add(new CommandBinding(CustomCommands.EditBook, EditBookCommand_Executed));
            CommandBindings.Add(new CommandBinding(CustomCommands.DeleteBook, DeleteBookCommand_Executed));
        }

        private void AddBookCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow();
            addBookWindow.ShowDialog();
        }

        private void EditBookCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var editBookWindow = new EditBookWindow();
            editBookWindow.ShowDialog();
        }

        private void DeleteBookCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить книгу?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Книга удалена");
            }
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand AddBook = new RoutedUICommand(
            "Добавить книгу", "AddBook", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static readonly RoutedUICommand EditBook = new RoutedUICommand(
            "Редактировать книгу", "EditBook", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static readonly RoutedUICommand DeleteBook = new RoutedUICommand(
            "Удалить книгу", "DeleteBook", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.D, ModifierKeys.Control) });
    }
}