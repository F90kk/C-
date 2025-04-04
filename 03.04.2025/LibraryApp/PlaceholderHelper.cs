using System.Windows;
using System.Windows.Controls;

namespace LibraryApp
{
    public static class PlaceholderHelper
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(PlaceholderHelper),
                new PropertyMetadata(string.Empty, OnPlaceholderTextChanged));

        public static string GetPlaceholderText(DependencyObject obj) =>
            (string)obj.GetValue(PlaceholderTextProperty);

        public static void SetPlaceholderText(DependencyObject obj, string value) =>
            obj.SetValue(PlaceholderTextProperty, value);

        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += (s, _) => { if (textBox.Text == GetPlaceholderText(textBox)) textBox.Text = ""; };
                textBox.LostFocus += (s, _) => { if (string.IsNullOrEmpty(textBox.Text)) textBox.Text = GetPlaceholderText(textBox); };
                if (string.IsNullOrEmpty(textBox.Text)) textBox.Text = (string)e.NewValue;
            }
        }
    }
}