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
    /// Decorador que agrega Doble Proteína a un sándwich
    /// </summary>
    public class DobleProteinaDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Doble Proteína
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega doble proteína</param>
        public DobleProteinaDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Doble Proteína",
                PreciosConstants.PrecioDobleProteina.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}

