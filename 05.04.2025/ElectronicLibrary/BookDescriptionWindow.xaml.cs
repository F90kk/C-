using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace LibraryApp
{
    public partial class BookDescriptionWindow : Window
    {
        public BookDescriptionWindow(Book book)
        {
            try
            {
                InitializeComponent();
                DataContext = book;
                Loaded += (s, e) => FlipToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии описания: {ex.Message}");
            }
        }

        private void FlipToBack()
        {
            try
            {
                DoubleAnimation flipAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5))
                };
                flipAnimation.Completed += (s, e) =>
                {
                    FrontPanel.Visibility = Visibility.Hidden;
                    BackPanel.Visibility = Visibility.Visible;
                    DoubleAnimation flipBackAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = -1,
                        Duration = new Duration(TimeSpan.FromSeconds(0.5))
                    };
                    FlipTransform.BeginAnimation(ScaleTransform.ScaleXProperty, flipBackAnimation);
                };
                FlipTransform.BeginAnimation(ScaleTransform.ScaleXProperty, flipAnimation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при анимации: {ex.Message}");
            }
        }
    }
}