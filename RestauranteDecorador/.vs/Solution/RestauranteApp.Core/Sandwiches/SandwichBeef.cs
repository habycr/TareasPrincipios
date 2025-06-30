using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;

namespace RestauranteApp.Core.Sandwiches
{
    /// <summary>
    /// Implementación concreta de un sándwich de carne de res (beef)
    /// </summary>
    public class SandwichBeef : SandwichBase
    {
        /// <summary>
        /// Constructor del sándwich de beef
        /// </summary>
        /// <param name="tamano">Tamaño del sándwich</param>
        public SandwichBeef(TamanoSandwich tamano)
            : base(TipoProteina.Beef, tamano)
        {
        }

        /// <summary>
        /// Devuelve información específica del sándwich
        /// </summary>
        /// <returns>Texto identificativo del tipo de sándwich</returns>
        public override string ObtenerInformacionEspecifica()
        {
            return "Sándwich de Beef";
        }
    }
}

