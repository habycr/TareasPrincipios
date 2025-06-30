using System.Windows;

namespace RestauranteApp.WPF.Services
{
    /// <summary>
    /// Servicio para mostrar diálogos de mensaje en la interfaz WPF
    /// </summary>
    public class DialogService
    {
        /// <summary>
        /// Muestra un mensaje informativo
        /// </summary>
        public void MostrarInformacion(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Muestra un mensaje de advertencia
        /// </summary>
        public void MostrarAdvertencia(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Muestra un mensaje de error
        /// </summary>
        public void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Muestra un diálogo de confirmación Sí/No
        /// </summary>
        /// <returns>True si el usuario selecciona Sí</returns>
        public bool Confirmar(string titulo, string mensaje)
        {
            var resultado = MessageBox.Show(mensaje, titulo, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return resultado == MessageBoxResult.Yes;
        }
    }
}

