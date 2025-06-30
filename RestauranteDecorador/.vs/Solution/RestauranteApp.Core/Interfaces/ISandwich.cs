using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;

namespace RestauranteApp.Core.Interfaces
{
    /// <summary>
    /// Interfaz principal para todos los sándwiches y decoradores (Patrón Decorator)
    /// Define el contrato común que deben cumplir tanto los sándwiches base como los decorados
    /// </summary>
    public interface ISandwich
    {
        /// <summary>
        /// Obtiene el nombre del sándwich (incluyendo adicionales si aplica)
        /// </summary>
        /// <returns>Nombre descriptivo del sándwich</returns>
        string GetNombre();

        /// <summary>
        /// Obtiene el precio total del sándwich (incluyendo adicionales si aplica)
        /// </summary>
        /// <returns>Precio total calculado</returns>
        decimal GetPrecio();

        /// <summary>
        /// Obtiene la descripción completa del sándwich con formato detallado
        /// Incluye el nombre, tamaño, precio base y adicionales
        /// </summary>
        /// <returns>Descripción formateada para mostrar al cliente</returns>
        string GetDescripcion();

        /// <summary>
        /// Obtiene el tipo de proteína del sándwich base
        /// </summary>
        /// <returns>Tipo de proteína (Pavo, Beef, Pollo)</returns>
        TipoProteina GetTipoProteina();

        /// <summary>
        /// Obtiene el tamaño del sándwich
        /// </summary>
        /// <returns>Tamaño del sándwich (15cm o 30cm)</returns>
        TamanoSandwich GetTamano();

        /// <summary>
        /// Obtiene una lista de todos los adicionales aplicados al sándwich
        /// Útil para mostrar el desglose detallado
        /// </summary>
        /// <returns>Lista de nombres de adicionales</returns>
        IList<string> GetAdicionales();
    }
}