using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using MariaTestTask.Model;

namespace MariaTest.Converters
{
    /// <summary>
    /// Class to convert bool value to visibility (reverse)
    /// </summary>
    public class BoolToVisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool?)value == false)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
