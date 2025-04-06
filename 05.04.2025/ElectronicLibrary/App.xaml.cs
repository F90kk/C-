using System.Windows;
using System.Threading;
using System;

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

            MessageBox.Show($"loginResult: {loginResult}, CurrentUser: {(LoginViewModel.CurrentUser != null ? LoginViewModel.CurrentUser.Username : "null")}"); // Отладка

            if (loginResult == true && LoginViewModel.CurrentUser != null)
            {
                MessageBox.Show("Условие выполнено, открываем MainWindow."); // Дополнительная отладка
                try
                {
                    if (Application.Current == null)
                    {
                        MessageBox.Show("Application.Current равен null!");
                        Shutdown();
                        return;
                    }

                    var mainWindow = new MainWindow();
                    MainWindow = mainWindow;
                    mainWindow.Show();
                    MessageBox.Show("MainWindow успешно открыт."); // Дополнительная отладка

                    ShutdownMode = ShutdownMode.OnMainWindowClose;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при инициализации главного окна: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    Shutdown();
                }
            }
            else
            {
                MessageBox.Show("Условие не выполнено, завершаем приложение."); // Дополнительная отладка
                Shutdown();
            }
        }
    }
}