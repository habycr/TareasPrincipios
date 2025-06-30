using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Constants;
using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Interfaces;

namespace RestauranteApp.Core.Decorators
{
    /// <summary>
    /// Decorador que agrega Tocino a un sándwich
    /// </summary>
    public class TocinoDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Tocino
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega aguacate</param>
        public TocinoDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Tocino",
                PreciosConstants.PrecioTocino.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}
