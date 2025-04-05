using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibraryApp
{
    public partial class LoginWindow : Window
    {
        private string _password;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _password = passwordBox.Password;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
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

            var user = users.FirstOrDefault(u => u.Username == UsernameTextBox.Text && u.Password == _password);
            if (user != null)
            {
                CurrentUser = user;
                var mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public static User CurrentUser { get; private set; }
    }
}