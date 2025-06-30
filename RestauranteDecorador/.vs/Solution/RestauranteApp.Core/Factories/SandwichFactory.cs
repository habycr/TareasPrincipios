using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Interfaces;
using RestauranteApp.Core.Sandwiches;

namespace RestauranteApp.Core.Factories
{
    /// <summary>
    /// Fábrica para crear instancias de sándwiches base según tipo de proteína y tamaño
    /// </summary>
    public static class SandwichFactory
    {
        /// <summary>
        /// Crea un sándwich base del tipo y tamaño especificado
        /// </summary>
        /// <param name="tipoProteina">Tipo de proteína (Pavo, Beef, Pollo)</param>
        /// <param name="tamano">Tamaño del sándwich (15cm o 30cm)</param>
        /// <returns>Instancia de ISandwich correspondiente</returns>
        /// <exception cref="ArgumentException">Si el tipo de proteína no es válido</exception>
        public static ISandwich CrearSandwich(TipoProteina tipoProteina, TamanoSandwich tamano)
        {
            return tipoProteina switch
            {
                TipoProteina.Pavo => new SandwichPavo(tamano),
                TipoProteina.Beef => new SandwichBeef(tamano),
                TipoProteina.Pollo => new SandwichPollo(tamano),
                _ => throw new ArgumentException($"Tipo de proteína no soportado: {tipoProteina}")
            };
        }
    }
}

