using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Interfaces;

namespace RestauranteApp.Core.Models
{
    /// <summary>
    /// Representa un ítem individual dentro de una orden (un sándwich con sus adicionales)
    /// </summary>
    public class DetalleOrden
    {
        /// <summary>
        /// Sándwich con todos sus adicionales aplicados (patrón Decorator)
        /// </summary>
        public ISandwich Sandwich { get; set; }

        /// <summary>
        /// Cantidad de este ítem en la orden
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Constructor del detalle de orden
        /// </summary>
        /// <param name="sandwich">Sándwich decorado con adicionales</param>
        /// <param name="cantidad">Cantidad de sándwiches</param>
        public DetalleOrden(ISandwich sandwich, int cantidad = 1)
        {
            Sandwich = sandwich ?? throw new ArgumentNullException(nameof(sandwich));
            Cantidad = cantidad > 0 ? cantidad : throw new ArgumentException("La cantidad debe ser mayor a cero", nameof(cantidad));
        }

        /// <summary>
        /// Calcula el subtotal de este detalle (precio unitario * cantidad)
        /// </summary>
        /// <returns>Subtotal del detalle</returns>
        public decimal CalcularSubtotal()
        {
            return Sandwich.GetPrecio() * Cantidad;
        }

        /// <summary>
        /// Obtiene la descripción completa del detalle
        /// </summary>
        /// <returns>Descripción formateada del sándwich y cantidad</returns>
        public string ObtenerDescripcionCompleta()
        {
            var descripcion = Sandwich.GetDescripcion();
            var precio = Sandwich.GetPrecio();
            var subtotal = CalcularSubtotal();

            if (Cantidad > 1)
            {
                return $"{descripcion} (${precio:F1}) x{Cantidad} = ${subtotal:F1}";
            }
            else
            {
                return $"{descripcion} = ${subtotal:F1}";
            }
        }

        public string DescripcionCompleta => ObtenerDescripcionCompleta();

        /// <summary>
        /// Representación en string del detalle
        /// </summary>
        /// <returns>Descripción completa como string</returns>
        public override string ToString()
        {
            return ObtenerDescripcionCompleta();
        }
    }
}
