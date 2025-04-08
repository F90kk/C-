using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LibraryApp.Views
{
    public partial class ReaderWindow : Window
    {
        private List<string> _pages;
        private int _currentPageIndex = 0;
        // --- Make LinesPerPage easily configurable ---
        private const int LinesPerPage = 25; // Increased slightly, adjust as needed

        public ReaderWindow(string filePath)
        {
            InitializeComponent(); // Must be first

            try
            {
                LoadBook(filePath);

                // Ensure initial display after loading
                if (_pages != null && _pages.Count > 0)
                {
                    // Explicitly set index to 0 before the first display
                    _currentPageIndex = 0;
                    UpdatePages(); // Display the first page(s)
                }
                else
                {
                    // Handle case where loading failed or file was empty
                    CurrentPage.Text = "Не удалось загрузить книгу или она пуста.";
                    NextPage.Text = "";
                    PreviousPageButton.IsEnabled = false; // Ensure buttons are disabled
                    NextPageButton.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                // Catch errors during the initialization/loading phase
                MessageBox.Show($"Критическая ошибка при открытии окна чтения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                CurrentPage.Text = "Ошибка загрузки.";
                NextPage.Text = "";
                PreviousPageButton.IsEnabled = false;
                NextPageButton.IsEnabled = false;
                // Optionally: this.Close();
            }
        }

        private void LoadBook(string filePath)
        {
            // Reset state in case LoadBook is called again somehow
            _pages = new List<string>();
            _currentPageIndex = 0; // Reset index

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Файл не найден: {filePath}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // _pages remains empty
            }

            try
            {
                // Use ReadLines for efficiency and better line ending handling
                var lines = File.ReadLines(filePath).ToList(); // Use ToList() to allow Skip/Take

                if (lines.Count == 0)
                {
                    _pages.Add("Книга пуста."); // Add a single page indicating emptiness
                    return;
                }

                for (int i = 0; i < lines.Count; i += LinesPerPage)
                {
                    var pageLines = lines.Skip(i).Take(LinesPerPage);
                    // Join with Environment.NewLine for cross-platform compatibility
                    _pages.Add(string.Join(Environment.NewLine, pageLines));
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Ошибка чтения файла: {ioEx.Message}", "Ошибка ввода-вывода", MessageBoxButton.OK, MessageBoxImage.Error);
                _pages.Clear(); // Ensure pages is empty on error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при загрузке книги: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _pages.Clear(); // Ensure pages is empty on error
            }
        }

        private void UpdatePages()
        {
            // No try-catch needed here if LoadBook handles file errors and we check index bounds
            if (_pages == null || _pages.Count == 0) return; // Nothing to display

            // Ensure index is within bounds (should be, but safety check)
            if (_currentPageIndex < 0) _currentPageIndex = 0;
            if (_currentPageIndex >= _pages.Count) _currentPageIndex = _pages.Count - 1;

            // --- Reset Visual State Before Updating Text ---
            // This prevents visual glitches if UpdatePages is called unexpectedly
            Canvas currentCanvas = CurrentPage.Parent as Canvas;
            if (currentCanvas != null)
            {
                // Remove any temporary TextBlocks left over from previous animations
                var tempBlocks = currentCanvas.Children.OfType<TextBlock>()
                                       .Where(tb => tb != CurrentPage && tb != NextPage).ToList();
                foreach (var block in tempBlocks)
                {
                    currentCanvas.Children.Remove(block);
                }
            }
            // Ensure original positions
            Canvas.SetLeft(CurrentPage, 0);
            Canvas.SetLeft(NextPage, 400);
            // --- End Reset ---


            // Set text for current page
            CurrentPage.Text = _pages[_currentPageIndex];

            // Set text for next page (if it exists)
            NextPage.Text = (_currentPageIndex + 1 < _pages.Count) ? _pages[_currentPageIndex + 1] : "";

            // Update button enabled state
            PreviousPageButton.IsEnabled = _currentPageIndex > 0;
            NextPageButton.IsEnabled = _currentPageIndex + 1 < _pages.Count;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (!NextPageButton.IsEnabled) return; // Already at end or animating

            // Disable buttons during animation
            PreviousPageButton.IsEnabled = false;
            NextPageButton.IsEnabled = false;

            // Ensure starting positions are correct before animating
            Canvas.SetLeft(CurrentPage, 0);
            Canvas.SetLeft(NextPage, 400); // NextPage starts off-screen right

            DoubleAnimation animCurrent = new DoubleAnimation(0, -400, TimeSpan.FromSeconds(0.5)); // Move current left (out)
            DoubleAnimation animNext = new DoubleAnimation(400, 0, TimeSpan.FromSeconds(0.5));    // Move next left (in)

            // Use a flag or check animation status if worried about multiple clicks,
            // but disabling buttons is usually sufficient.

            // Update state *after* the animation involving the *incoming* page completes
            animNext.Completed += (s, _) =>
            {
                _currentPageIndex++;
                UpdatePages(); // Update text content and button states
                // No need to reset Canvas.Left here, UpdatePages does it now.
                // Buttons re-enabled by UpdatePages
            };

            // Start animations
            CurrentPage.BeginAnimation(Canvas.LeftProperty, animCurrent);
            NextPage.BeginAnimation(Canvas.LeftProperty, animNext);
        }


        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (!PreviousPageButton.IsEnabled) return; // Already at start or animating

            // Disable buttons during animation
            PreviousPageButton.IsEnabled = false;
            NextPageButton.IsEnabled = false;

            // --- Prepare the actual previous page visually ---
            string prevPageText = _pages[_currentPageIndex - 1]; // We know this exists because button was enabled
            TextBlock prevPage = new TextBlock
            {
                Width = 400,
                Height = 400,
                Text = prevPageText,
                TextWrapping = TextWrapping.Wrap,
                FontSize = CurrentPage.FontSize, // Match style
                FontFamily = CurrentPage.FontFamily
                // Add other style properties if needed (Margin, Padding, etc.)
            };

            // Position the incoming previous page off-screen left
            Canvas.SetLeft(prevPage, -400);
            // Ensure current page is at its starting position
            Canvas.SetLeft(CurrentPage, 0);
            // Add the temporary previous page TextBlock to the canvas
            Canvas currentCanvas = CurrentPage.Parent as Canvas;
            currentCanvas?.Children.Add(prevPage);
            // --- End Preparation ---


            DoubleAnimation animCurrent = new DoubleAnimation(0, 400, TimeSpan.FromSeconds(0.5)); // Move current right (out)
            DoubleAnimation animPrev = new DoubleAnimation(-400, 0, TimeSpan.FromSeconds(0.5));   // Move previous right (in)


            // Update state *after* the animation involving the *incoming* page completes
            animPrev.Completed += (s, _) =>
            {
                _currentPageIndex--;
                UpdatePages(); // Update text, button states, and removes the temporary prevPage block
                               // Buttons re-enabled by UpdatePages
            };

            // Start animations
            CurrentPage.BeginAnimation(Canvas.LeftProperty, animCurrent);
            prevPage.BeginAnimation(Canvas.LeftProperty, animPrev);
        }

        // --- Add Names to Buttons in XAML ---
        // Make sure your XAML buttons have x:Name properties:
        // <Button x:Name="PreviousPageButton" ... />
        // <Button x:Name="NextPageButton" ... />
    }
}