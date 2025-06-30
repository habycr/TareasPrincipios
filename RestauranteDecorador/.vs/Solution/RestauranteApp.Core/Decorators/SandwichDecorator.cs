using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Interfaces;

namespace RestauranteApp.Core.Decorators
{
    /// <summary>
    /// Clase base abstracta para todos los decoradores de sándwiches (adicionales)
    /// Implementa ISandwich y delega al sándwich decorado
    /// </summary>
    public abstract class SandwichDecorator : ISandwich
    {
        /// <summary>
        /// Sándwich al que se le aplica el decorador (componente base)
        /// </summary>
        protected ISandwich _sandwich;

        /// <summary>
        /// Nombre del adicional que representa este decorador
        /// </summary>
        protected readonly string _nombreAdicional;

        /// <summary>
        /// Precio adicional aplicado por este decorador
        /// </summary>
        protected readonly decimal _precioAdicional;

        /// <summary>
        /// Constructor del decorador
        /// </summary>
        /// <param name="sandwich">Sándwich a decorar</param>
        /// <param name="nombreAdicional">Nombre del adicional</param>
        /// <param name="precioAdicional">Precio adicional a aplicar</param>
        protected SandwichDecorator(ISandwich sandwich, string nombreAdicional, decimal precioAdicional)
        {
            _sandwich = sandwich ?? throw new ArgumentNullException(nameof(sandwich));
            _nombreAdicional = nombreAdicional;
            _precioAdicional = precioAdicional;
        }

        public virtual string GetNombre()
        {
            return $"{_sandwich.GetNombre()} + {_nombreAdicional}";
        }

        public virtual decimal GetPrecio()
        {
            return _sandwich.GetPrecio() + _precioAdicional;
        }

        public virtual string GetDescripcion()
        {
            return $"{_sandwich.GetDescripcion()} + {_nombreAdicional} (${_precioAdicional:F1})";
        }

        public virtual TipoProteina GetTipoProteina()
        {
            return _sandwich.GetTipoProteina();
        }

        public virtual TamanoSandwich GetTamano()
        {
            return _sandwich.GetTamano();
        }

        public virtual IList<string> GetAdicionales()
        {
            var adicionales = _sandwich.GetAdicionales();
            adicionales.Add(_nombreAdicional);
            return adicionales;
        }

        public override string ToString()
        {
            return GetDescripcion();
        }
    }
}
