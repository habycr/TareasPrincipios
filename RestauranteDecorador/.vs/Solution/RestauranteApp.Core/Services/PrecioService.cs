using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Constants;
using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Models;

namespace RestauranteApp.Core.Services
{
    /// <summary>
    /// Servicio responsable de manejar cálculos de precios
    /// </summary>
    public class PrecioService
    {
        /// <summary>
        /// Obtiene el precio base de un sándwich dado su tipo de proteína y tamaño
        /// </summary>
        public decimal ObtenerPrecioBase(TipoProteina tipo, TamanoSandwich tamano)
        {
            return PreciosConstants.ObtenerPrecioBase(tipo, tamano);
        }

        /// <summary>
        /// Obtiene el precio de un adicional según su nombre y tamaño
        /// </summary>
        public decimal ObtenerPrecioAdicional(string nombreAdicional, TamanoSandwich tamano)
        {
            var adicionales = PreciosConstants.ObtenerTodosLosAdicionales();
            if (adicionales.TryGetValue(nombreAdicional, out var precioAdicional))
            {
                return precioAdicional.ObtenerPrecio(tamano);
            }

            throw new ArgumentException($"Adicional no reconocido: {nombreAdicional}");
        }

        /// <summary>
        /// Devuelve todos los adicionales disponibles con sus precios según tamaño
        /// </summary>
        public Dictionary<string, decimal> ObtenerPreciosAdicionales(TamanoSandwich tamano)
        {
            var resultado = new Dictionary<string, decimal>();
            var adicionales = PreciosConstants.ObtenerTodosLosAdicionales();

            foreach (var kvp in adicionales)
            {
                resultado[kvp.Key] = kvp.Value.ObtenerPrecio(tamano);
            }

            return resultado;
        }
    }
}

