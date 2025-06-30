using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RestauranteApp.Core.Enums;
using RestauranteApp.Core.Factories;
using RestauranteApp.Core.Interfaces;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.Services;
using RestauranteApp.WPF.Helpers;
using RestauranteApp.WPF.Views;
using RestauranteApp.Core.Constants;

namespace RestauranteApp.WPF.ViewModels
{
    public class SandwichBuilderViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly DialogService _dialogService = new();
        private readonly OrdenService _ordenService;

        public ObservableCollection<TipoProteina> TiposProteina { get; }
        public ObservableCollection<TamanoSandwich> TamanosDisponibles { get; }
        public ObservableCollection<string> AdicionalesConPrecio { get; }
        public ObservableCollection<int> Cantidades { get; }

        public Dictionary<string, int> AdicionalesSeleccionados { get; }

        private TipoProteina _tipoSeleccionado;
        public TipoProteina TipoSeleccionado
        {
            get => _tipoSeleccionado;
            set
            {
                _tipoSeleccionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrecioProteina));
                OnPropertyChanged(nameof(PrecioTamano));
                ActualizarPreciosAdicionales();
            }
        }

        private TamanoSandwich _tamanoSeleccionado;
        public TamanoSandwich TamanoSeleccionado
        {
            get => _tamanoSeleccionado; 
            set
            {
                _tamanoSeleccionado = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrecioProteina));
                OnPropertyChanged(nameof(PrecioTamano));
                ActualizarPreciosAdicionales();
            }
        }

        public decimal PrecioProteina => PreciosConstants.ObtenerPrecioBase(TipoSeleccionado, TamanoSeleccionado);
        public decimal PrecioTamano => PreciosConstants.ObtenerPrecioBase(TipoSeleccionado, TamanoSeleccionado);


        public ICommand CambiarCantidadCommand { get; }
        public ICommand AgregarSandwichCommand { get; }

        public SandwichBuilderViewModel(MainViewModel mainViewModel, OrdenService ordenService)
        {
            _mainViewModel = mainViewModel;
            _ordenService = ordenService; // usar instancia existente

            TiposProteina = new ObservableCollection<TipoProteina>((TipoProteina[])Enum.GetValues(typeof(TipoProteina)));
            TamanosDisponibles = new ObservableCollection<TamanoSandwich>((TamanoSandwich[])Enum.GetValues(typeof(TamanoSandwich)));
            Cantidades = new ObservableCollection<int> { 0, 1, 2, 3, 4, 5 };
            AdicionalesSeleccionados = new Dictionary<string, int>();
            AdicionalesConPrecio = new ObservableCollection<string>();

            TipoSeleccionado = TipoProteina.Pavo;
            TamanoSeleccionado = TamanoSandwich.Pequeno15cm;

            ActualizarPreciosAdicionales();

            CambiarCantidadCommand = new RelayCommand<Tuple<string, int>>(ActualizarCantidadAdicional);
            AgregarSandwichCommand = new RelayCommand(AgregarSandwich);
        }


        private void ActualizarPreciosAdicionales()
        {
            AdicionalesConPrecio.Clear();
            var todos = PreciosConstants.ObtenerTodosLosAdicionales();

            foreach (var adicional in todos)
            {
                var precio = adicional.Value.ObtenerPrecio(TamanoSeleccionado);
                AdicionalesConPrecio.Add($"{adicional.Key} - ${precio:F2}");
            }
        }

        private void ActualizarCantidadAdicional(Tuple<string, int> data)
        {
            string adicional = data.Item1.Split(" - ")[0];
            int cantidad = data.Item2;

            if (cantidad > 0)
                AdicionalesSeleccionados[adicional] = cantidad;
            else
                AdicionalesSeleccionados.Remove(adicional);
        }

        private void AgregarSandwich()
        {
            ISandwich sandwich = SandwichFactory.CrearSandwich(TipoSeleccionado, TamanoSeleccionado);

            foreach (var adicional in AdicionalesSeleccionados)
            {
                for (int i = 0; i < adicional.Value; i++)
                    sandwich = AplicarDecorador(sandwich, adicional.Key);
            }

            _ordenService.AgregarSandwich(sandwich);
            _dialogService.MostrarInformacion("Agregado", "Sándwich agregado a la orden.");

            _mainViewModel.CambiarVista(new OrdenView(_mainViewModel, _ordenService));
        }

        public void ActualizarCantidadAdicional(string adicional, int cantidad)
        {
            if (cantidad > 0)
                AdicionalesSeleccionados[adicional] = cantidad;
            else
                AdicionalesSeleccionados.Remove(adicional);
        }


        private ISandwich AplicarDecorador(ISandwich sandwich, string adicional)
        {
            return adicional switch
            {
                "Aguacate" => new Core.Decorators.AguacateDecorator(sandwich),
                "Doble Proteína" => new Core.Decorators.DobleProteinaDecorator(sandwich),
                "Sopa" => new Core.Decorators.SopaDecorator(sandwich),
                "Extra Queso" => new Core.Decorators.ExtraQuesoDecorator(sandwich),
                "Tocino" => new Core.Decorators.TocinoDecorator(sandwich),
                "Verduras Extra" => new Core.Decorators.VerdurasExtraDecorator(sandwich),
                _ => sandwich
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
