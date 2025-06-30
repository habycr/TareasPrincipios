using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Interfaces;
using System.Text;

namespace RestauranteApp.Core.Models
{
    /// <summary>
    /// Representa una orden completa del restaurante con múltiples sándwiches
    /// </summary>
    public class Orden
    {
        private readonly List<DetalleOrden> _detalles;

        /// <summary>
        /// Número único de la orden
        /// </summary>
        public int NumeroOrden { get; private set; }

        /// <summary>
        /// Fecha y hora de creación de la orden
        /// </summary>
        public DateTime FechaCreacion { get; private set; }

        /// <summary>
        /// Lista de detalles de la orden (solo lectura)
        /// </summary>
        public IReadOnlyList<DetalleOrden> Detalles => _detalles.AsReadOnly();

        /// <summary>
        /// Indica si la orden está vacía
        /// </summary>
        public bool EstaVacia => _detalles.Count == 0;

        /// <summary>
        /// Cantidad total de ítems en la orden
        /// </summary>
        public int CantidadTotalItems => _detalles.Sum(d => d.Cantidad);

        /// <summary>
        /// Constructor de la orden
        /// </summary>
        /// <param name="numeroOrden">Número único de la orden</param>
        public Orden(int numeroOrden = 0)
        {
            NumeroOrden = numeroOrden > 0 ? numeroOrden : GenerarNumeroOrden();
            FechaCreacion = DateTime.Now;
            _detalles = new List<DetalleOrden>();
        }

        /// <summary>
        /// Agrega un sándwich a la orden
        /// </summary>
        /// <param name="sandwich">Sándwich a agregar</param>
        /// <param name="cantidad">Cantidad de sándwiches</param>
        public void AgregarSandwich(ISandwich sandwich, int cantidad = 1)
        {
            if (sandwich == null)
                throw new ArgumentNullException(nameof(sandwich));

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero", nameof(cantidad));

            var detalle = new DetalleOrden(sandwich, cantidad);
            _detalles.Add(detalle);
        }

        /// <summary>
        /// Remueve un detalle específico de la orden
        /// </summary>
        /// <param name="indice">Índice del detalle a remover</param>
        /// <returns>True si se removió exitosamente</returns>
        public bool RemoverDetalle(int indice)
        {
            if (indice >= 0 && indice < _detalles.Count)
            {
                _detalles.RemoveAt(indice);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Limpia todos los detalles de la orden
        /// </summary>
        public void LimpiarOrden()
        {
            _detalles.Clear();
        }

        /// <summary>
        /// Calcula el total de la orden
        /// </summary>
        /// <returns>Precio total de todos los sándwiches</returns>
        public decimal CalcularTotal()
        {
            return _detalles.Sum(detalle => detalle.CalcularSubtotal());
        }

        /// <summary>
        /// Genera el resumen completo de la orden
        /// </summary>
        /// <returns>String formateado con el detalle completo</returns>
        public string GenerarResumen()
        {
            if (EstaVacia)
            {
                return "La orden está vacía.";
            }

            var sb = new StringBuilder();
            sb.AppendLine("==================================================================");

            foreach (var detalle in _detalles)
            {
                sb.AppendLine(detalle.ObtenerDescripcionCompleta());
            }

            sb.AppendLine("==================================================================");
            sb.AppendLine($"TOTAL ${CalcularTotal():F1}");

            return sb.ToString();
        }

        /// <summary>
        /// Genera un número de orden único basado en timestamp
        /// </summary>
        /// <returns>Número de orden único</returns>
        private static int GenerarNumeroOrden()
        {
            return (int)(DateTime.Now.Ticks % int.MaxValue);
        }

        /// <summary>
        /// Representación en string de la orden
        /// </summary>
        /// <returns>Resumen de la orden</returns>
        public override string ToString()
        {
            return $"Orden #{NumeroOrden} - {CantidadTotalItems} ítems - Total: ${CalcularTotal():F1}";
        }
    }
}
