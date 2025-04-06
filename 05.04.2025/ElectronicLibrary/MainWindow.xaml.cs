using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            try
            {
                MessageBox.Show("Начало инициализации MainWindow."); // Отладка
                InitializeComponent();
                MessageBox.Show("InitializeComponent завершён."); // Отладка

                _viewModel = new MainViewModel();
                MessageBox.Show("MainViewModel создан."); // Отладка

                DataContext = _viewModel;
                MessageBox.Show("DataContext установлен."); // Отладка

                _viewModel.AddBookCommand = new RelayCommand(AddBook);
                _viewModel.SendMessageCommand = new RelayCommand(SendMessage);
                MessageBox.Show("Команды установлены."); // Отладка

                // Запускаем асинхронные задачи после полной инициализации
                _viewModel.StartBackgroundTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации MainWindow: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw; // Передаём исключение дальше
            }
        }

        private async void AddBook()
        {
            try
            {
                var addBookWindow = new AddBookWindow();
                if (addBookWindow.ShowDialog() == true)
                {
                    var viewModel = (AddBookViewModel)addBookWindow.DataContext;
                    var book = new Book
                    {
                        Title = viewModel.Title,
                        Author = viewModel.Author,
                        Year = viewModel.Year,
                        Description = viewModel.Description,
                        FilePath = viewModel.FilePath,
                        DateAdded = DateTime.Now,
                        UploadProgress = 0
                    };

                    for (int i = 0; i <= 100; i += 10)
                    {
                        book.UploadProgress = i;
                        if (!_viewModel.Books.Contains(book))
                            _viewModel.Books.Add(book);
                        await Task.Delay(100);
                    }

                    var books = _viewModel.Books.ToList();
                    File.WriteAllText("library.json", JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented));

                    using (var mmf = MemoryMappedFile.CreateOrOpen("NewBookNotification", 256))
                    using (var view = mmf.CreateViewAccessor())
                    {
                        byte[] message = System.Text.Encoding.UTF8.GetBytes($"Добавлена книга: {book.Title}");
                        view.WriteArray(0, message, 0, message.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        private async void SendMessage()
        {
            try
            {
                if (string.IsNullOrEmpty(_viewModel.ChatMessage)) return;

                MessageBox.Show("Попытка подключения клиента..."); // Отладка
                using (var client = new NamedPipeClientStream(".", "LibraryChat", PipeDirection.InOut))
                {
                    await client.ConnectAsync();
                    MessageBox.Show("Клиент успешно подключился."); // Отладка
                    using (var writer = new StreamWriter(client) { AutoFlush = true })
                    {
                        await writer.WriteLineAsync($"{LoginViewModel.CurrentUser.Username}: {_viewModel.ChatMessage}");
                    }
                }
                _viewModel.ChatMessage = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке сообщения: {ex.Message}");
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _viewModel.SearchBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}");
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender is ListView listView && listView.SelectedItem is Book selectedBook)
                {
                    var readerWindow = new ReaderWindow(selectedBook.FilePath);
                    readerWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии книги: {ex.Message}");
            }
        }

        private void ListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender is ListView listView && listView.SelectedItem is Book selectedBook)
                {
                    var descriptionWindow = new BookDescriptionWindow(selectedBook);
                    descriptionWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии описания: {ex.Message}");
            }
        }
    }
}