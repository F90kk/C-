using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {

            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _viewModel.AddBookCommand = new RelayCommand(AddBook);
            _viewModel.SendMessageCommand = new RelayCommand(SendMessage);
        }

        private async void AddBook()
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
                    UploadProgress = 0
                };

                // Симуляция прогресса загрузки
                for (int i = 0; i <= 100; i += 10)
                {
                    book.UploadProgress = i;
                    if (!_viewModel.Books.Contains(book))
                        _viewModel.Books.Add(book);
                    await Task.Delay(100);
                }

                // Сохранение в JSON
                var books = _viewModel.Books.ToList();
                File.WriteAllText("library.json", JsonConvert.SerializeObject(books, Formatting.Indented));

                // Уведомление через Memory-Mapped File
                var mmf = MemoryMappedFile.CreateOrOpen("NewBookNotification", 256);
                var view = mmf.CreateViewAccessor();
                byte[] message = System.Text.Encoding.UTF8.GetBytes($"Добавлена книга: {book.Title}");
                view.WriteArray(0, message, 0, message.Length);
            }
        }

        private async void SendMessage()
        {
            if (string.IsNullOrEmpty(_viewModel.ChatMessage)) return;

            var client = new NamedPipeClientStream(".", "LibraryChat", PipeDirection.InOut);
            await client.ConnectAsync();
            var writer = new StreamWriter(client) { AutoFlush = true };
            await writer.WriteLineAsync($"{LoginViewModel.CurrentUser.Username}: {_viewModel.ChatMessage}");
            _viewModel.ChatMessage = string.Empty;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SearchBooks();
        }
    }
}