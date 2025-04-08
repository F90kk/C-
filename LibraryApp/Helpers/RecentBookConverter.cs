using System;
using System.Globalization;
using System.Windows.Data;

namespace LibraryApp.Helpers
{
    public class RecentBookConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateAdded)
            {
                return (DateTime.Now - dateAdded).TotalDays < 7;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}