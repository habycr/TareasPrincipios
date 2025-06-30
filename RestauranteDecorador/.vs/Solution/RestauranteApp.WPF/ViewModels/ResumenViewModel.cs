using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.Helpers;
using RestauranteApp.WPF.Services;
using RestauranteApp.WPF.Views;

namespace RestauranteApp.WPF.ViewModels
{
    /// <summary>
    /// ViewModel para mostrar el resumen final de la orden
    /// </summary>
    public class ResumenViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly OrdenService _ordenService;
        private readonly DialogService _dialogService = new();

        private string _resumenTexto;
        public string ResumenTexto
        {
            get => _resumenTexto;
            set
            {
                _resumenTexto = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReiniciarCommand { get; }
        public ICommand SalirCommand { get; }

        public ResumenViewModel(MainViewModel mainViewModel, OrdenService ordenService)
        {
            _mainViewModel = mainViewModel;
            _ordenService = ordenService;

            ResumenTexto = _ordenService.ObtenerResumen();

            ReiniciarCommand = new RelayCommand(ReiniciarProceso);
            SalirCommand = new RelayCommand(Salir);
        }

        private void ReiniciarProceso()
        {
            if (_dialogService.Confirmar("Reiniciar", "¿Desea comenzar una nueva orden?"))
            {
                _ordenService.LimpiarOrden();
                _mainViewModel.CambiarVista(new SandwichBuilderView(_mainViewModel, _ordenService));
            }
        }

        private void Salir()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
