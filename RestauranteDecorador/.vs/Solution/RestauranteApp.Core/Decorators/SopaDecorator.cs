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
    /// Decorador que agrega Sopa a un sándwich
    /// </summary>
    public class SopaDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Sopa
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega sopa</param>
        public SopaDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Sopa",
                PreciosConstants.PrecioSopa.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}

