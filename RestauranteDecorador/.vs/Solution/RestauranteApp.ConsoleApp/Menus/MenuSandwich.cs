using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Factories;
using RestauranteApp.Core.Interfaces;
using RestauranteApp.ConsoleApp.Helpers;

namespace RestauranteApp.ConsoleApp.Menus
{
    /// <summary>
    /// Menú para seleccionar el tipo y tamaño del sándwich base
    /// </summary>
    public static class MenuSandwich
    {
        /// <summary>
        /// Muestra el menú de selección de sándwich base
        /// </summary>
        /// <returns>Instancia de ISandwich base (sin adicionales)</returns>
        public static ISandwich Mostrar()
        {
            ConsoleHelper.MostrarTitulo("Seleccione el tipo de sándwich");

            var tipos = Enum.GetValues(typeof(TipoProteina)).Cast<TipoProteina>().ToList();
            for (int i = 0; i < tipos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tipos[i]}");
            }

            int opcionTipo = InputValidator.LeerEnteroEnRango("Ingrese una opción", 1, tipos.Count);
            var tipoSeleccionado = tipos[opcionTipo - 1];

            ConsoleHelper.MostrarTitulo("Seleccione el tamaño");

            var tamanos = Enum.GetValues(typeof(TamanoSandwich)).Cast<TamanoSandwich>().ToList();
            for (int i = 0; i < tamanos.Count; i++)
            {
                string textoTamano = tamanos[i] == TamanoSandwich.Pequeno15cm ? "15 cm" : "30 cm";
                Console.WriteLine($"{i + 1}. {textoTamano}");
            }

            int opcionTamano = InputValidator.LeerEnteroEnRango("Ingrese una opción", 1, tamanos.Count);
            var tamanoSeleccionado = tamanos[opcionTamano - 1];

            var sandwich = SandwichFactory.CrearSandwich(tipoSeleccionado, tamanoSeleccionado);

            ConsoleHelper.MostrarMensajeExito($"Sándwich seleccionado: {sandwich.GetDescripcion()}");

            return sandwich;
        }
    }
}

