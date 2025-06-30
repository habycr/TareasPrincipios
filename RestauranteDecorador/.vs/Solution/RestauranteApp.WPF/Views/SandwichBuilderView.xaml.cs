using System.Windows.Controls;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.ViewModels;

namespace RestauranteApp.WPF.Views
{
    /// <summary>
    /// Lógica de interacción para SandwichBuilderView.xaml
    /// </summary>
    public partial class SandwichBuilderView : UserControl
    {
        public SandwichBuilderView(MainViewModel mainViewModel, OrdenService ordenService)
        {
            InitializeComponent();
            DataContext = new SandwichBuilderViewModel(mainViewModel, ordenService);
        }

        /// <summary>
        /// Maneja el cambio de cantidad de un adicional desde el ComboBox
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is string texto && combo.SelectedItem is int cantidad)
            {
                // Extraer nombre del adicional (antes del " - $")
                string adicional = texto.Split(" - ")[0];

                if (DataContext is SandwichBuilderViewModel vm)
                {
                    vm.ActualizarCantidadAdicional(adicional, cantidad);
                }
            }
        }
    }
}
