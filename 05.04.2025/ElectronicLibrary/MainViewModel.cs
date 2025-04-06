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
        private bool _isChatServerRunning; // Флаг для отслеживания состояния сервера

        public ObservableCollection<Book> Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                SearchBooks();
            }
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
            try
            {
                MessageBox.Show("Начало инициализации MainViewModel."); // Отладка
                Books = new ObservableCollection<Book>();
                ChatMessages = new ObservableCollection<string>();
                LoadData();
                MessageBox.Show("LoadData завершён."); // Отладка
                _isChatServerRunning = false; // Инициализируем флаг
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации MainViewModel: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw; // Передаём исключение дальше
            }
        }

        public void StartBackgroundTasks()
        {
            if (!_isChatServerRunning)
            {
                StartChatServer();
                MessageBox.Show("StartChatServer запущен."); // Отладка
                _isChatServerRunning = true;
            }
            else
            {
                MessageBox.Show("Чат-сервер уже запущен."); // Отладка
            }
            CheckNewBooksNotification();
            MessageBox.Show("CheckNewBooksNotification запущен."); // Отладка
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists("library.json"))
                {
                    var json = File.ReadAllText("library.json");
                    var books = JsonConvert.DeserializeObject<List<Book>>(json);
                    if (books != null)
                    {
                        Books = new ObservableCollection<Book>(books);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        public void SearchBooks()
        {
            try
            {
                if (string.IsNullOrEmpty(SearchQuery))
                {
                    LoadData();
                    return;
                }

                var filtered = Books?.Where(b =>
                    b.Title?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    b.Author?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    b.Year.ToString() == SearchQuery).ToList();

                if (filtered != null)
                {
                    Books = new ObservableCollection<Book>(filtered);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске книг: {ex.Message}");
            }
        }

        private async void StartChatServer()
        {
            try
            {
                await Task.Run(async () =>
                {
                    while (true)
                    {
                        try
                        {
                            // Шаг 2: Увеличиваем количество доступных экземпляров канала до 10
                            using (var server = new NamedPipeServerStream("LibraryChat", PipeDirection.InOut, 10))
                            {
                                MessageBox.Show("Ожидание подключения клиента..."); // Отладка
                                await server.WaitForConnectionAsync();
                                MessageBox.Show("Клиент подключился."); // Отладка
                                using (var reader = new StreamReader(server))
                                {
                                    string message = await reader.ReadLineAsync();
                                    if (!string.IsNullOrEmpty(message))
                                    {
                                        if (Application.Current != null)
                                        {
                                            Application.Current.Dispatcher.Invoke(() => ChatMessages.Add(message));
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (Application.Current != null)
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                    MessageBox.Show($"Ошибка в чат-сервере: {ex.Message}")
                                );
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске чат-сервера: {ex.Message}");
            }
        }

        private void CheckNewBooksNotification()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        using (var mmf = MemoryMappedFile.OpenExisting("NewBookNotification"))
                        using (var view = mmf.CreateViewAccessor())
                        {
                            byte[] buffer = new byte[256];
                            view.ReadArray(0, buffer, 0, buffer.Length);
                            string message = System.Text.Encoding.UTF8.GetString(buffer).Trim('\0');
                            if (!string.IsNullOrEmpty(message))
                            {
                                if (Application.Current != null)
                                {
                                    Application.Current.Dispatcher.Invoke(() => ChatMessages.Add(message));
                                }
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        // Игнорируем, если файл еще не создан
                    }
                    catch (Exception ex)
                    {
                        if (Application.Current != null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                                MessageBox.Show($"Ошибка в CheckNewBooksNotification: {ex.Message}")
                            );
                        }
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