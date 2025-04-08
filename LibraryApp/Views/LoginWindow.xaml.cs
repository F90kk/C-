using LibraryApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LibraryApp.Views
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(this);
            DataContext = _viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is PasswordBox passwordBox)
                {
                    _viewModel.Password = passwordBox.Password;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вводе пароля: {ex.Message}");
            }
        }
    }
}