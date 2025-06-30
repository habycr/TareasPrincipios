using ModeloVistaControlador.Vista;
using ModeloVistaControlador.Logica.Modelo;
using ModeloVistaControlador.Logica.Controlador;

namespace ModeloVistaControlador
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Interfaz vista = new Interfaz();
            LogicaModelo modelo = new LogicaModelo();
            controlador controlador = new controlador(vista, modelo);

            Application.Run(vista);

            Console.WriteLine("Aplicación lanzada. Presione cualquier tecla para salir.");
        }
    }
}