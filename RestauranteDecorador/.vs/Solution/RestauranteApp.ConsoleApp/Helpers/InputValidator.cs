using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp.ConsoleApp.Helpers
{
    /// <summary>
    /// Clase utilitaria para validar y leer entradas del usuario desde la consola
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Solicita al usuario ingresar un número entero dentro de un rango
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar antes de leer</param>
        /// <param name="minimo">Valor mínimo permitido</param>
        /// <param name="maximo">Valor máximo permitido</param>
        /// <returns>Entero válido dentro del rango</returns>
        public static int LeerEnteroEnRango(string mensaje, int minimo, int maximo)
        {
            int valor;
            bool valido;

            do
            {
                Console.Write($"{mensaje} ({minimo}-{maximo}): ");
                string entrada = Console.ReadLine();
                valido = int.TryParse(entrada, out valor) && valor >= minimo && valor <= maximo;

                if (!valido)
                {
                    ConsoleHelper.MostrarError("Entrada inválida. Intente nuevamente.");
                }
            } while (!valido);

            return valor;
        }

        /// <summary>
        /// Solicita al usuario ingresar un número entero (sin rango)
        /// </summary>
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write($"{mensaje}: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out valor))
                    return valor;

                ConsoleHelper.MostrarError("Entrada inválida. Ingrese un número entero.");
            }
        }

        /// <summary>
        /// Solicita al usuario una opción tipo sí/no (Y/N)
        /// </summary>
        /// <param name="mensaje">Mensaje de confirmación</param>
        /// <returns>True si el usuario responde sí</returns>
        public static bool Confirmar(string mensaje)
        {
            while (true)
            {
                Console.Write($"{mensaje} (S/N): ");
                string entrada = Console.ReadLine()?.Trim().ToUpper();

                if (entrada == "S" || entrada == "SI")
                    return true;
                if (entrada == "N" || entrada == "NO")
                    return false;

                ConsoleHelper.MostrarError("Por favor, responda con 'S' o 'N'.");
            }
        }

        /// <summary>
        /// Lee una cadena de texto no vacía desde consola
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <returns>Texto no vacío</returns>
        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write($"{mensaje}: ");
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada;

                ConsoleHelper.MostrarError("El valor no puede estar vacío.");
            }
        }
    }
}
