using RestauranteApp.ConsoleApp.Menus;

namespace RestauranteApp.ConsoleApp
{
    /// <summary>
    /// Punto de entrada principal de la aplicación de consola
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Title = "RestauranteApp - Sándwich Builder";
            MenuPrincipal.Mostrar();

            System.Console.WriteLine();
            System.Console.WriteLine("Gracias por su compra. ¡Buen provecho!");
            System.Console.WriteLine("Presione cualquier tecla para salir...");
            System.Console.ReadKey();
        }
    }
}