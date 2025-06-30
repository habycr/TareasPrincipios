using System.Windows.Controls;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.ViewModels;

namespace RestauranteApp.WPF.Views
{
    /// <summary>
    /// Interacción lógica para OrdenView.xaml
    /// </summary>
    public partial class OrdenView : UserControl
    {
        public OrdenView(MainViewModel mainViewModel, OrdenService ordenService)
        {
            InitializeComponent();
            DataContext = new OrdenViewModel(mainViewModel, ordenService);
        }
    }
}
