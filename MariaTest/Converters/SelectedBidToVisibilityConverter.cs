using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using MariaTestTask.Model;

namespace MariaTest.Converters
{
    /// <summary>
    /// Class for converting object to visibility
    /// </summary>
    public class SelectedBidToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Bid?)value == null)
            {
                return Visibility.Hidden;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
