using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Models;
using RestauranteApp.Core.Interfaces;

namespace RestauranteApp.Core.Services
{
    /// <summary>
    /// Servicio que encapsula la lógica de gestión de órdenes
    /// </summary>
    public class OrdenService
    {
        private readonly Orden _orden;

        /// <summary>
        /// Inicializa una nueva instancia del servicio para una orden
        /// </summary>
        public OrdenService()
        {
            _orden = new Orden();
        }

        /// <summary>
        /// Devuelve la orden actual
        /// </summary>
        public Orden ObtenerOrdenActual()
        {
            return _orden;
        }

        /// <summary>
        /// Agrega un sándwich a la orden actual
        /// </summary>
        public void AgregarSandwich(ISandwich sandwich, int cantidad = 1)
        {
            _orden.AgregarSandwich(sandwich, cantidad);
        }

        /// <summary>
        /// Remueve un sándwich de la orden por índice
        /// </summary>
        public bool RemoverSandwich(int indice)
        {
            return _orden.RemoverDetalle(indice);
        }

        /// <summary>
        /// Limpia la orden actual
        /// </summary>
        public void LimpiarOrden()
        {
            _orden.LimpiarOrden();
        }

        /// <summary>
        /// Calcula el total de la orden actual
        /// </summary>
        public decimal CalcularTotal()
        {
            return _orden.CalcularTotal();
        }

        /// <summary>
        /// Devuelve el resumen textual de la orden
        /// </summary>
        public string ObtenerResumen()
        {
            return _orden.GenerarResumen();
        }

        /// <summary>
        /// Indica si la orden está vacía
        /// </summary>
        public bool EstaVacia()
        {
            return _orden.EstaVacia;
        }
    }
}

