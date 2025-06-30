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
    /// Decorador que agrega Verduras Extra a un sándwich
    /// </summary>
    public class VerdurasExtraDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Verduras Extra
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega verduras extra</param>
        public VerdurasExtraDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Verduras Extra",
                PreciosConstants.PrecioVerdurasExtra.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}

