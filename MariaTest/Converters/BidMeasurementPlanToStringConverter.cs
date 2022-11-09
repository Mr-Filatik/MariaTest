using System;
using System.Globalization;
using System.Windows.Data;

namespace MariaTest.Converters
{
    /// <summary>
    /// Class for converting the measurement plan into a string
    /// </summary>
    internal class BidMeasurementPlanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "Дата не назначена";
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
