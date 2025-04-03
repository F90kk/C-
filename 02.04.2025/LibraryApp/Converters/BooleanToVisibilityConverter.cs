﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LibraryApp
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = parameter as string == "True";
            bool isVisible = (bool)value;

            if (invert)
                isVisible = !isVisible;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}