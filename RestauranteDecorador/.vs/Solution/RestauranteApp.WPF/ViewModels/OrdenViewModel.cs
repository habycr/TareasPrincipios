using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RestauranteApp.Core.Models;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.Services;
using RestauranteApp.WPF.Helpers;
using RestauranteApp.WPF.Views;
using RestauranteApp.Core.Constants;
using RestauranteApp.Core.Enums;

namespace RestauranteApp.WPF.ViewModels
{
    /// <summary>
    /// ViewModel para visualizar y modificar la orden actual
    /// </summary>
    public class OrdenViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly OrdenService _ordenService;
        private readonly DialogService _dialogService = new();

        public ObservableCollection<DetalleOrden> Detalles { get; }

        public decimal Total => _ordenService.CalcularTotal();
        

        public ICommand EliminarItemCommand { get; }
        public ICommand VaciarOrdenCommand { get; }
        public ICommand ContinuarCommand { get; }
        public ICommand FinalizarCommand { get; }

        public OrdenViewModel(MainViewModel mainViewModel, OrdenService ordenService)
        {
            _mainViewModel = mainViewModel;
            _ordenService = ordenService;

            Detalles = new ObservableCollection<DetalleOrden>(_ordenService.ObtenerOrdenActual().Detalles);

            EliminarItemCommand = new RelayCommand<DetalleOrden>(EliminarItem);
            VaciarOrdenCommand = new RelayCommand(VaciarOrden);
            ContinuarCommand = new RelayCommand(ContinuarConstruyendo);
            FinalizarCommand = new RelayCommand(FinalizarOrden);
        }

        private void EliminarItem(DetalleOrden item)
        {
            int index = Detalles.IndexOf(item);
            if (index >= 0)
            {
                _ordenService.RemoverSandwich(index);
                Detalles.RemoveAt(index);
                OnPropertyChanged(nameof(Total));
            }
        }

        private void VaciarOrden()
        {
            if (_dialogService.Confirmar("Confirmar", "¿Desea vaciar la orden?"))
            {
                _ordenService.LimpiarOrden();
                Detalles.Clear();
                OnPropertyChanged(nameof(Total));
            }
        }

        private void ContinuarConstruyendo()
        {
            _mainViewModel.CambiarVista(new SandwichBuilderView(_mainViewModel, _ordenService));

        }

        private void FinalizarOrden()
        {
            _mainViewModel.CambiarVista(new ResumenView(_mainViewModel, _ordenService));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
