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
    /// Decorador que agrega Aguacate a un sándwich
    /// </summary>
    public class AguacateDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Aguacate
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega aguacate</param>
        public AguacateDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Aguacate",
                PreciosConstants.PrecioAguacate.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}

