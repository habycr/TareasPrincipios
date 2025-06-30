using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Constants;
using RestauranteApp.Core.Decorators;
using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Interfaces;
using RestauranteApp.Core.Models;
using RestauranteApp.ConsoleApp.Helpers;

namespace RestauranteApp.ConsoleApp.Menus
{
    /// <summary>
    /// Menú para seleccionar y aplicar adicionales a un sándwich
    /// </summary>
    public static class MenuAdicionales
    {
        /// <summary>
        /// Muestra el menú de adicionales y aplica decoradores al sándwich
        /// </summary>
        /// <param name="sandwichBase">Instancia base del sándwich</param>
        /// <returns>Sándwich decorado con los adicionales seleccionados</returns>
        public static ISandwich Mostrar(ISandwich sandwichBase)
        {
            ConsoleHelper.MostrarTitulo("Agregar Adicionales");

            var adicionales = PreciosConstants.ObtenerTodosLosAdicionales();
            var nombres = adicionales.Keys.ToList();

            while (true)
            {
                for (int i = 0; i < nombres.Count; i++)
                {
                    var nombre = nombres[i];
                    var precio = adicionales[nombre].ObtenerPrecio(sandwichBase.GetTamano());
                    Console.WriteLine($"{i + 1}. {nombre} (${precio:F1})");
                }

                Console.WriteLine("0. Finalizar selección de adicionales");

                int opcion = InputValidator.LeerEnteroEnRango("Seleccione un adicional", 0, nombres.Count);
                if (opcion == 0) break;

                string adicionalSeleccionado = nombres[opcion - 1];
                sandwichBase = AplicarDecorador(sandwichBase, adicionalSeleccionado);
                ConsoleHelper.MostrarMensajeExito($"Agregado: {adicionalSeleccionado}");
            }

            return sandwichBase;
        }

        /// <summary>
        /// Aplica el decorador correspondiente al nombre del adicional
        /// </summary>
        /// <param name="sandwich">Sándwich actual</param>
        /// <param name="adicional">Nombre del adicional</param>
        /// <returns>Sándwich decorado</returns>
        private static ISandwich AplicarDecorador(ISandwich sandwich, string adicional)
        {
            return adicional switch
            {
                "Aguacate" => new AguacateDecorator(sandwich),
                "Doble Proteína" => new DobleProteinaDecorator(sandwich),
                "Sopa" => new SopaDecorator(sandwich),
                "Extra Queso" => new ExtraQuesoDecorator(sandwich),
                "Tocino" => new TocinoDecorator(sandwich),
                "Verduras Extra" => new VerdurasExtraDecorator(sandwich),
                _ => sandwich // No aplica nada si no se reconoce (fallback)
            };
        }
    }
}

