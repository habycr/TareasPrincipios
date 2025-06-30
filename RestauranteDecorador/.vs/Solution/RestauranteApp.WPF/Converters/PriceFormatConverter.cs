using System;
using System.Globalization;
using System.Windows.Data;

namespace RestauranteApp.WPF.Converters
{
    /// <summary>
    /// Convierte un valor decimal a formato de precio con símbolo "$"
    /// </summary>
    public class PriceFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal dec)
                return $"${dec:F2}";
            return "$0.00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s && s.StartsWith("$") && decimal.TryParse(s[1..], out var result))
                return result;

            return 0m;
        }
    }
}
