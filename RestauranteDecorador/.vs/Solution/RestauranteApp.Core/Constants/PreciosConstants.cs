using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Models;

namespace RestauranteApp.Core.Constants
{
    /// <summary>
    /// Constantes de precios para sándwiches y adicionales del restaurante
    /// </summary>
    public static class PreciosConstants
    {
        #region Precios Base de Sándwiches

        /// <summary>
        /// Precios base del sándwich de Pavo
        /// </summary>
        public static readonly Dictionary<TamanoSandwich, decimal> PreciosPavo = new()
        {
            { TamanoSandwich.Pequeno15cm, 12.0m },
            { TamanoSandwich.Grande30cm, 18.0m }
        };

        /// <summary>
        /// Precios base del sándwich de Beef
        /// </summary>
        public static readonly Dictionary<TamanoSandwich, decimal> PreciosBeef = new()
        {
            { TamanoSandwich.Pequeno15cm, 14.0m },
            { TamanoSandwich.Grande30cm, 20.0m }
        };

        /// <summary>
        /// Precios base del sándwich de Pollo
        /// </summary>
        public static readonly Dictionary<TamanoSandwich, decimal> PreciosPollo = new()
        {
            { TamanoSandwich.Pequeno15cm, 12.0m },
            { TamanoSandwich.Grande30cm, 16.0m }
        };

        #endregion

        #region Precios de Adicionales

        /// <summary>
        /// Precio del adicional Aguacate
        /// </summary>
        public static readonly PrecioAdicional PrecioAguacate = new(1.5m, 2.0m);

        /// <summary>
        /// Precio del adicional Doble Proteína
        /// </summary>
        public static readonly PrecioAdicional PrecioDobleProteina = new(4.5m, 6.0m);

        /// <summary>
        /// Precio del adicional Sopa
        /// </summary>
        public static readonly PrecioAdicional PrecioSopa = new(3.0m, 4.2m);

        /// <summary>
        /// Precio del adicional Extra Queso
        /// </summary>
        public static readonly PrecioAdicional PrecioExtraQueso = new(2.0m, 2.8m);

        /// <summary>
        /// Precio del adicional Tocino
        /// </summary>
        public static readonly PrecioAdicional PrecioTocino = new(3.5m, 4.5m);

        /// <summary>
        /// Precio del adicional Verduras Extra
        /// </summary>
        public static readonly PrecioAdicional PrecioVerdurasExtra = new(1.0m, 1.5m);

        #endregion

        #region Métodos Helper

        /// <summary>
        /// Obtiene el precio base de un sándwich según su tipo y tamaño
        /// </summary>
        /// <param name="tipoProteina">Tipo de proteína del sándwich</param>
        /// <param name="tamano">Tamaño del sándwich</param>
        /// <returns>Precio base del sándwich</returns>
        /// <exception cref="ArgumentException">Si el tipo de proteína no es válido</exception>
        public static decimal ObtenerPrecioBase(TipoProteina tipoProteina, TamanoSandwich tamano)
        {
            var preciosSandwich = tipoProteina switch
            {
                TipoProteina.Pavo => PreciosPavo,
                TipoProteina.Beef => PreciosBeef,
                TipoProteina.Pollo => PreciosPollo,
                _ => throw new ArgumentException($"Tipo de proteína no válido: {tipoProteina}")
            };

            if (preciosSandwich.TryGetValue(tamano, out var precio))
            {
                return precio;
            }

            throw new ArgumentException($"Tamaño no válido: {tamano}");
        }

        /// <summary>
        /// Obtiene todos los precios de adicionales disponibles
        /// </summary>
        /// <returns>Diccionario con nombre del adicional y sus precios</returns>
        public static Dictionary<string, PrecioAdicional> ObtenerTodosLosAdicionales()
        {
            return new Dictionary<string, PrecioAdicional>
            {
                { "Aguacate", PrecioAguacate },
                { "Doble Proteína", PrecioDobleProteina },
                { "Sopa", PrecioSopa },
                { "Extra Queso", PrecioExtraQueso },
                { "Tocino", PrecioTocino },
                { "Verduras Extra", PrecioVerdurasExtra }
            };
        }

        #endregion
    }
}