using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LibraryApp
{
    public partial class ReaderWindow : Window
    {
        private List<string> _pages;
        private int _currentPageIndex = 0;

        public ReaderWindow(string filePath)
        {
            try
            {
                InitializeComponent();
                LoadBook(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии книги: {ex.Message}");
            }
        }

        private void LoadBook(string filePath)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                var lines = text.Split('\n');
                _pages = new List<string>();
                for (int i = 0; i < lines.Length; i += 20)
                {
                    _pages.Add(string.Join("\n", lines.Skip(i).Take(20)));
                }
                UpdatePages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке книги: {ex.Message}");
            }
        }

        private void UpdatePages()
        {
            try
            {
                if (_pages.Count == 0) return;
                CurrentPage.Text = _pages[_currentPageIndex];
                NextPage.Text = _currentPageIndex + 1 < _pages.Count ? _pages[_currentPageIndex + 1] : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении страниц: {ex.Message}");
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentPageIndex + 1 >= _pages.Count) return;

                DoubleAnimation animCurrent = new DoubleAnimation(0, -400, TimeSpan.FromSeconds(0.5));
                DoubleAnimation animNext = new DoubleAnimation(400, 0, TimeSpan.FromSeconds(0.5));
                animCurrent.Completed += (s, _) =>
                {
                    _currentPageIndex++;
                    UpdatePages();
                    Canvas.SetLeft(CurrentPage, 0);
                    Canvas.SetLeft(NextPage, 400);
                };
                CurrentPage.BeginAnimation(Canvas.LeftProperty, animCurrent);
                NextPage.BeginAnimation(Canvas.LeftProperty, animNext);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при перелистывании вперед: {ex.Message}");
            }
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentPageIndex <= 0) return;

                DoubleAnimation animCurrent = new DoubleAnimation(0, 400, TimeSpan.FromSeconds(0.5));
                DoubleAnimation animPrev = new DoubleAnimation(-400, 0, TimeSpan.FromSeconds(0.5));
                TextBlock prevPage = new TextBlock
                {
                    Width = 400,
                    Height = 400,
                    Text = _pages[_currentPageIndex - 1],
                    TextWrapping = TextWrapping.Wrap
                };
                Canvas.SetLeft(prevPage, -400);
                (CurrentPage.Parent as Canvas).Children.Add(prevPage);
                animCurrent.Completed += (s, _) =>
                {
                    _currentPageIndex--;
                    UpdatePages();
                    Canvas.SetLeft(CurrentPage, 0);
                    Canvas.SetLeft(NextPage, 400);
                    (CurrentPage.Parent as Canvas).Children.Remove(prevPage);
                };
                CurrentPage.BeginAnimation(Canvas.LeftProperty, animCurrent);
                prevPage.BeginAnimation(Canvas.LeftProperty, animPrev);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при перелистывании назад: {ex.Message}");
            }
        }
    }
}