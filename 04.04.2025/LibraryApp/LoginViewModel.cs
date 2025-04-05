using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly Window _window;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }

        public LoginViewModel(Window window)
        {
            _window = window;
            LoginCommand = new RelayCommand(Login, CanLogin);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Login()
        {
            List<User> users = new List<User>();

            // Загрузка пользователей из users.json
            if (File.Exists("users.json"))
            {
                var json = File.ReadAllText("users.json");
                users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                // Если файла нет, создаем тестовых пользователей
                users.Add(new User { Username = "admin", Password = "admin123", IsAdmin = true });
                users.Add(new User { Username = "reader", Password = "reader123", IsAdmin = false });
                File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
            }

            var user = users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                CurrentUser = user; // Сохраняем текущего пользователя
                _window.DialogResult = true;
                _window.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Cancel()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        public static User CurrentUser { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}