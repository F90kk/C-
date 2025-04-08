using LibraryApp.Views;
using System;
using System.Threading;
using System.Windows;

namespace LibraryApp
{
    public partial class App : Application
    {
        private static Mutex _mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "LibraryApp";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("Приложение уже запущено!");
                Shutdown();
                return;
            }

            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var loginWindow = new LoginWindow();
            bool? loginResult = loginWindow.ShowDialog();

            if (loginResult == true && ViewModels.LoginViewModel.CurrentUser != null)
            {
                try
                {
                    var mainWindow = new MainWindow();
                    MainWindow = mainWindow;
                    mainWindow.Show();
                    ShutdownMode = ShutdownMode.OnMainWindowClose;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при инициализации главного окна: {ex.Message}");
                    Shutdown();
                }
            }
            else
            {
                Shutdown();
            }
        }
    }
}