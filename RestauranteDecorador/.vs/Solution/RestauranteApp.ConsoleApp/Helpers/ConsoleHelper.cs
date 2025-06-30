using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestauranteApp.ConsoleApp.Helpers
{
    /// <summary>
    /// Proporciona métodos utilitarios para formatear y mostrar contenido en la consola
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Muestra una línea separadora
        /// </summary>
        public static void MostrarSeparador()
        {
            Console.WriteLine("==================================================================");
        }

        /// <summary>
        /// Muestra un título centrado con formato destacado
        /// </summary>
        /// <param name="titulo">Texto del título</param>
        public static void MostrarTitulo(string titulo)
        {
            MostrarSeparador();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CentrarTexto(titulo.ToUpper(), 66));
            Console.ResetColor();
            MostrarSeparador();
        }

        /// <summary>
        /// Muestra un mensaje en color verde (para acciones exitosas)
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public static void MostrarMensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje de error en rojo
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje informativo en amarillo
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public static void MostrarAdvertencia(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[!] {mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Solicita al usuario presionar una tecla para continuar
        /// </summary>
        public static void EsperarTecla()
        {
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Centra un texto en la consola según un ancho dado
        /// </summary>
        /// <param name="texto">Texto a centrar</param>
        /// <param name="ancho">Ancho total deseado</param>
        /// <returns>Texto centrado</returns>
        public static string CentrarTexto(string texto, int ancho)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length >= ancho)
                return texto;

            int espacios = (ancho - texto.Length) / 2;
            return new string(' ', espacios) + texto;
        }
    }
}
