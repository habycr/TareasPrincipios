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
    /// Decorador que agrega Extra Queso a un sándwich
    /// </summary>
    public class ExtraQuesoDecorator : SandwichDecorator
    {
        /// <summary>
        /// Constructor del decorador de Extra Queso
        /// </summary>
        /// <param name="sandwich">Sándwich base al que se le agrega extra queso</param>
        public ExtraQuesoDecorator(ISandwich sandwich)
            : base(
                sandwich,
                "Extra Queso",
                PreciosConstants.PrecioExtraQueso.ObtenerPrecio(sandwich.GetTamano())
              )
        {
        }
    }
}

