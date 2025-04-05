using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books;
        private string _searchQuery;
        private string _chatMessage;
        private ObservableCollection<string> _chatMessages;
        private ICommand _addBookCommand;
        private ICommand _sendMessageCommand;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); SearchBooks(); }
        }

        public string ChatMessage
        {
            get => _chatMessage;
            set { _chatMessage = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> ChatMessages
        {
            get => _chatMessages;
            set { _chatMessages = value; OnPropertyChanged(); }
        }

        public ICommand AddBookCommand
        {
            get => _addBookCommand;
            set { _addBookCommand = value; OnPropertyChanged(); }
        }

        public ICommand SendMessageCommand
        {
            get => _sendMessageCommand;
            set { _sendMessageCommand = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();
            ChatMessages = new ObservableCollection<string>();
            LoadData();
            StartChatServer();
            SetupFileWatcher();
            CheckNewBooksNotification();
        }

        private void LoadData()
        {
            if (File.Exists("library.json"))
            {
                var json = File.ReadAllText("library.json");
                var books = JsonConvert.DeserializeObject<List<Book>>(json);
                Books = new ObservableCollection<Book>(books);
            }
        }

        public void SearchBooks()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                LoadData(); // Если поиск пустой, загружаем все книги
                return;
            }

            var filtered = Books.Where(b =>
                b.Title.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Author.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Year.ToString() == SearchQuery).ToList();

            Books = new ObservableCollection<Book>(filtered);
        }

        private async void StartChatServer()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    var server = new NamedPipeServerStream("LibraryChat", PipeDirection.InOut);
                    server.WaitForConnection();

                    var reader = new StreamReader(server);
                    string message = reader.ReadLine();
                    Application.Current.Dispatcher.Invoke(() => ChatMessages.Add(message));
                }
            });
        }

        private void SetupFileWatcher()
        {
            var watcher = new FileSystemWatcher
            {
                Path = Directory.GetCurrentDirectory(),
                Filter = "library.json",
                EnableRaisingEvents = true
            };
            watcher.Changed += (s, e) => LoadData();
        }

        private void CheckNewBooksNotification()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var mmf = MemoryMappedFile.OpenExisting("NewBookNotification");
                        var view = mmf.CreateViewAccessor();
                        byte[] buffer = new byte[256];
                        view.ReadArray(0, buffer, 0, buffer.Length);
                        string message = System.Text.Encoding.UTF8.GetString(buffer).Trim('\0');
                        if (!string.IsNullOrEmpty(message))
                        {
                            Application.Current.Dispatcher.Invoke(() => ChatMessages.Add(message));
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        // Игнорируем, если файл еще не создан
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}