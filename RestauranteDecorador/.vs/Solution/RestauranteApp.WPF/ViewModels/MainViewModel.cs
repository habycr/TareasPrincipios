using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.Views;

namespace RestauranteApp.WPF.ViewModels
{
    /// <summary>
    /// ViewModel principal que maneja la navegación entre vistas
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _vistaActual;
        private readonly OrdenService _ordenService = new(); 

        public object VistaActual
        {
            get => _vistaActual;
            set
            {
                _vistaActual = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Inicializa el ViewModel con la vista inicial (SandwichBuilderView)
        /// </summary>
        public MainViewModel()
        {
            VistaActual = new SandwichBuilderView(this, _ordenService); 
        }

        /// <summary>
        /// Cambia la vista actual (navegación entre pantallas)
        /// </summary>
        public void CambiarVista(object nuevaVista)
        {
            VistaActual = nuevaVista;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
