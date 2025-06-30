using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;

namespace RestauranteApp.Core.Sandwiches
{
    /// <summary>
    /// Implementación concreta de un sándwich de pollo
    /// </summary>
    public class SandwichPollo : SandwichBase
    {
        /// <summary>
        /// Constructor del sándwich de pollo
        /// </summary>
        /// <param name="tamano">Tamaño del sándwich</param>
        public SandwichPollo(TamanoSandwich tamano)
            : base(TipoProteina.Pollo, tamano)
        {
        }

        /// <summary>
        /// Devuelve información específica del sándwich
        /// </summary>
        /// <returns>Texto identificativo del tipo de sándwich</returns>
        public override string ObtenerInformacionEspecifica()
        {
            return "Sándwich de Pollo";
        }
    }
}

