using System;
using System.Globalization;
using System.Windows.Data;

namespace RestauranteApp.WPF.Converters
{
    public class NombreAdicionalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string texto && texto.Contains(" - "))
                return texto.Split(" - ")[0];
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
