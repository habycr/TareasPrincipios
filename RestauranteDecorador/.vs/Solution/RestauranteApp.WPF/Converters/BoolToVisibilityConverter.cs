using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RestauranteApp.WPF.Converters
{
    /// <summary>
    /// Convierte un valor booleano en Visibility (Visible o Collapsed)
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = value is bool b && b;

            if (Invert) flag = !flag;

            return flag ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility vis)
            {
                bool result = vis == Visibility.Visible;
                return Invert ? !result : result;
            }

            return false;
        }
    }
}
