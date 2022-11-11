﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using MariaTest.Models;

namespace MariaTest.Converters
{
    /// <summary>
    /// Class for converting object to visibility
    /// </summary>
    internal class ObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
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
