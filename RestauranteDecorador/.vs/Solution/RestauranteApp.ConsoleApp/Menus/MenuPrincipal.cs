using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestauranteApp.Core.Interfaces;
using RestauranteApp.Core.Models;
using RestauranteApp.Core.Services;
using RestauranteApp.ConsoleApp.Helpers;
using RestauranteApp.ConsoleApp.Menus;

namespace RestauranteApp.ConsoleApp.Menus
{
    /// <summary>
    /// Menú principal de navegación de la aplicación
    /// </summary>
    public static class MenuPrincipal
    {
        private static OrdenService _ordenService = new();

        public static void Mostrar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                ConsoleHelper.MostrarTitulo("MENÚ PRINCIPAL");

                Console.WriteLine("1. Agregar sándwich");
                Console.WriteLine("2. Ver orden actual");
                Console.WriteLine("3. Eliminar sándwich de la orden");
                Console.WriteLine("4. Limpiar orden");
                Console.WriteLine("5. Finalizar y ver resumen");
                Console.WriteLine("0. Salir");

                int opcion = InputValidator.LeerEnteroEnRango("Seleccione una opción", 0, 5);

                switch (opcion)
                {
                    case 1:
                        AgregarSandwich();
                        break;

                    case 2:
                        MostrarOrden();
                        break;

                    case 3:
                        EliminarDetalle();
                        break;

                    case 4:
                        LimpiarOrden();
                        break;

                    case 5:
                        MostrarResumenFinal();
                        salir = true;
                        break;

                    case 0:
                        salir = true;
                        break;
                }

                if (!salir) ConsoleHelper.EsperarTecla();
            }
        }

        private static void AgregarSandwich()
        {
            var sandwichBase = MenuSandwich.Mostrar();
            var sandwichDecorado = MenuAdicionales.Mostrar(sandwichBase);
            int cantidad = InputValidator.LeerEntero("¿Cuántos desea agregar?");
            _ordenService.AgregarSandwich(sandwichDecorado, cantidad);

            ConsoleHelper.MostrarMensajeExito("Sándwich agregado a la orden.");
        }

        private static void MostrarOrden()
        {
            var orden = _ordenService.ObtenerOrdenActual();
            ConsoleHelper.MostrarTitulo("ORDEN ACTUAL");

            if (orden.EstaVacia)
            {
                ConsoleHelper.MostrarAdvertencia("La orden está vacía.");
                return;
            }

            int index = 1;
            foreach (var detalle in orden.Detalles)
            {
                Console.WriteLine($"{index}. {detalle.ObtenerDescripcionCompleta()}");
                index++;
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL: ${orden.CalcularTotal():F1}");
        }

        private static void EliminarDetalle()
        {
            var orden = _ordenService.ObtenerOrdenActual();

            if (orden.EstaVacia)
            {
                ConsoleHelper.MostrarAdvertencia("No hay ítems para eliminar.");
                return;
            }

            MostrarOrden();
            int max = orden.Detalles.Count;
            int indice = InputValidator.LeerEnteroEnRango("Ingrese el número del sándwich a eliminar", 1, max);
            bool resultado = _ordenService.RemoverSandwich(indice - 1);

            if (resultado)
                ConsoleHelper.MostrarMensajeExito("Ítem eliminado.");
            else
                ConsoleHelper.MostrarError("No se pudo eliminar el ítem.");
        }

        private static void LimpiarOrden()
        {
            if (_ordenService.EstaVacia())
            {
                ConsoleHelper.MostrarAdvertencia("La orden ya está vacía.");
                return;
            }

            if (InputValidator.Confirmar("¿Está seguro de que desea limpiar toda la orden?"))
            {
                _ordenService.LimpiarOrden();
                ConsoleHelper.MostrarMensajeExito("Orden vaciada.");
            }
        }

        private static void MostrarResumenFinal()
        {
            Console.Clear();
            ConsoleHelper.MostrarTitulo("RESUMEN DE LA ORDEN");

            if (_ordenService.EstaVacia())
            {
                ConsoleHelper.MostrarAdvertencia("No hay elementos en la orden.");
            }
            else
            {
                Console.WriteLine(_ordenService.ObtenerResumen());
            }
        }
    }
}

