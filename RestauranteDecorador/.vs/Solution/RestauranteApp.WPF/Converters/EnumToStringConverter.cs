using System;
using System.Globalization;
using System.Windows.Data;

namespace RestauranteApp.WPF.Converters
{
    /// <summary>
    /// Convierte valores Enum en cadenas legibles
    /// </summary>
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString()?.Replace("Pequeno15cm", "15 cm")
                                     .Replace("Grande30cm", "30 cm")
                                     .Replace("Beef", "Beef")
                                     .Replace("Pollo", "Pollo")
                                     .Replace("Pavo", "Pavo");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string texto = value?.ToString()?.Trim().ToLower();

            return texto switch
            {
                "15 cm" => Core.Enums.TamanoSandwich.Pequeno15cm,
                "30 cm" => Core.Enums.TamanoSandwich.Grande30cm,
                "pavo" => Core.Enums.TipoProteina.Pavo,
                "pollo" => Core.Enums.TipoProteina.Pollo,
                "beef" => Core.Enums.TipoProteina.Beef,
                _ => Binding.DoNothing
            };
        }
    }
}
