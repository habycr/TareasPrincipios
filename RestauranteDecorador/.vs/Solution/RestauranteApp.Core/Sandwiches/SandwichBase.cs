using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Interfaces;
using RestauranteApp.Core.Constants;

namespace RestauranteApp.Core.Sandwiches
{
    /// <summary>
    /// Clase base abstracta para todos los sándwiches
    /// Implementa la interfaz ISandwich y proporciona funcionalidad común
    /// </summary>
    public abstract class SandwichBase : ISandwich
    {
        /// <summary>
        /// Tipo de proteína del sándwich
        /// </summary>
        protected TipoProteina TipoProteina { get; }

        /// <summary>
        /// Tamaño del sándwich
        /// </summary>
        protected TamanoSandwich Tamano { get; }

        /// <summary>
        /// Precio base del sándwich
        /// </summary>
        protected decimal PrecioBase { get; }

        /// <summary>
        /// Constructor protegido para las clases derivadas
        /// </summary>
        /// <param name="tipoProteina">Tipo de proteína del sándwich</param>
        /// <param name="tamano">Tamaño del sándwich</param>
        protected SandwichBase(TipoProteina tipoProteina, TamanoSandwich tamano)
        {
            TipoProteina = tipoProteina;
            Tamano = tamano;
            PrecioBase = PreciosConstants.ObtenerPrecioBase(tipoProteina, tamano);
        }

        /// <summary>
        /// Obtiene el nombre del sándwich basado en la proteína y tamaño
        /// Las clases derivadas pueden sobrescribir este método para personalizar el nombre
        /// </summary>
        /// <returns>Nombre del sándwich</returns>
        public virtual string GetNombre()
        {
            var nombreProteina = ObtenerNombreProteina();
            var tamanoTexto = ObtenerTextoTamano();
            return $"{nombreProteina} de {tamanoTexto}";
        }

        /// <summary>
        /// Obtiene el precio del sándwich (solo precio base, sin adicionales)
        /// </summary>
        /// <returns>Precio base del sándwich</returns>
        public virtual decimal GetPrecio()
        {
            return PrecioBase;
        }

        /// <summary>
        /// Obtiene la descripción formateada del sándwich
        /// Incluye nombre y precio base
        /// </summary>
        /// <returns>Descripción completa del sándwich</returns>
        public virtual string GetDescripcion()
        {
            return $"{GetNombre()} (${GetPrecio():F1})";
        }

        /// <summary>
        /// Obtiene el tipo de proteína del sándwich
        /// </summary>
        /// <returns>Tipo de proteína</returns>
        public TipoProteina GetTipoProteina()
        {
            return TipoProteina;
        }

        /// <summary>
        /// Obtiene el tamaño del sándwich
        /// </summary>
        /// <returns>Tamaño del sándwich</returns>
        public TamanoSandwich GetTamano()
        {
            return Tamano;
        }

        /// <summary>
        /// Obtiene la lista de adicionales del sándwich
        /// Para sándwiches base, siempre retorna lista vacía
        /// Los decoradores sobrescribirán este método
        /// </summary>
        /// <returns>Lista vacía para sándwiches base</returns>
        public virtual IList<string> GetAdicionales()
        {
            return new List<string>();
        }

        /// <summary>
        /// Método helper para obtener el nombre de la proteína en formato display
        /// </summary>
        /// <returns>Nombre de la proteína formateado</returns>
        protected virtual string ObtenerNombreProteina()
        {
            return TipoProteina switch
            {
                TipoProteina.Pavo => "Pavo",
                TipoProteina.Beef => "Beef",
                TipoProteina.Pollo => "Pollo",
                _ => TipoProteina.ToString()
            };
        }

        /// <summary>
        /// Método helper para obtener el texto del tamaño
        /// </summary>
        /// <returns>Texto descriptivo del tamaño</returns>
        protected virtual string ObtenerTextoTamano()
        {
            return Tamano switch
            {
                TamanoSandwich.Pequeno15cm => "15 cm",
                TamanoSandwich.Grande30cm => "30 cm",
                _ => Tamano.ToString()
            };
        }

        /// <summary>
        /// Método abstracto que las clases derivadas deben implementar
        /// para proporcionar información específica del tipo de sándwich
        /// </summary>
        /// <returns>Información específica del sándwich</returns>
        public abstract string ObtenerInformacionEspecifica();

        /// <summary>
        /// Representación en string del sándwich
        /// </summary>
        /// <returns>Descripción del sándwich</returns>
        public override string ToString()
        {
            return GetDescripcion();
        }

        /// <summary>
        /// Método de comparación para verificar igualdad entre sándwiches
        /// Dos sándwiches son iguales si tienen el mismo tipo de proteína y tamaño
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si son iguales</returns>
        public override bool Equals(object obj)
        {
            if (obj is SandwichBase other)
            {
                return TipoProteina == other.TipoProteina &&
                       Tamano == other.Tamano;
            }
            return false;
        }

        /// <summary>
        /// Genera hash code basado en proteína y tamaño
        /// </summary>
        /// <returns>Hash code del sándwich</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(TipoProteina, Tamano);
        }

        /// <summary>
        /// Valida si el sándwich tiene una configuración válida
        /// </summary>
        /// <returns>True si la configuración es válida</returns>
        public virtual bool EsConfiguracionValida()
        {
            return PrecioBase > 0 &&
                   Enum.IsDefined(typeof(TipoProteina), TipoProteina) &&
                   Enum.IsDefined(typeof(TamanoSandwich), Tamano);
        }
    }
}
