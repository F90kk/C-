using LibraryApp.Helpers;
using LibraryApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
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
            _window = window ?? throw new ArgumentNullException(nameof(window));
            LoginCommand = new RelayCommand(Login, CanLogin);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Login()
        {
            try
            {
                List<User> users = new List<User>();

                if (File.Exists("users.json"))
                {
                    var json = File.ReadAllText("users.json");
                    users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                }
                else
                {
                    users.Add(new User { Username = "admin", Password = "admin123", IsAdmin = true });
                    users.Add(new User { Username = "reader", Password = "reader123", IsAdmin = false });
                    File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
                }

                var user = users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    CurrentUser = user;
                    _window.DialogResult = true;
                    _window.Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Cancel()
        {
            try
            {
                _window.DialogResult = false;
                _window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене: {ex.Message}");
            }
        }

        public static User CurrentUser { get; set; }
    }
}