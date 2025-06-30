using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;

namespace RestauranteApp.Core.Models
{
    /// <summary>
    /// Representa el precio de un adicional según el tamaño del sándwich
    /// </summary>
    public class PrecioAdicional
    {
        /// <summary>
        /// Precio para sándwich pequeño (15cm)
        /// </summary>
        public decimal PrecioPequeno { get; set; }

        /// <summary>
        /// Precio para sándwich grande (30cm)
        /// </summary>
        public decimal PrecioGrande { get; set; }

        /// <summary>
        /// Constructor con precios específicos
        /// </summary>
        /// <param name="precioPequeno">Precio para sándwich de 15cm</param>
        /// <param name="precioGrande">Precio para sándwich de 30cm</param>
        public PrecioAdicional(decimal precioPequeno, decimal precioGrande)
        {
            PrecioPequeno = precioPequeno;
            PrecioGrande = precioGrande;
        }

        /// <summary>
        /// Constructor con precio único para ambos tamaños
        /// </summary>
        /// <param name="precioUnico">Precio aplicable a ambos tamaños</param>
        public PrecioAdicional(decimal precioUnico)
        {
            PrecioPequeno = precioUnico;
            PrecioGrande = precioUnico;
        }

        /// <summary>
        /// Obtiene el precio según el tamaño del sándwich
        /// </summary>
        /// <param name="tamano">Tamaño del sándwich</param>
        /// <returns>Precio correspondiente al tamaño</returns>
        public decimal ObtenerPrecio(TamanoSandwich tamano)
        {
            return tamano switch
            {
                TamanoSandwich.Pequeno15cm => PrecioPequeno,
                TamanoSandwich.Grande30cm => PrecioGrande,
                _ => throw new ArgumentException($"Tamaño de sándwich no válido: {tamano}")
            };
        }
    }
}   
