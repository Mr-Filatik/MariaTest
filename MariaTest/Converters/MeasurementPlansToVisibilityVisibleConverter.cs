using MariaTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MariaTest.Converters
{
    /// <summary>
    /// Class for converting list objects to visibility
    /// </summary>
    internal class MeasurementPlansToVisibilityVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<MeasurementPlanWithFreeCount> list = value as List<MeasurementPlanWithFreeCount>;
            if (list != null && list.Count > 0)
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
