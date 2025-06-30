using System.Windows.Controls;
using RestauranteApp.Core.Services;
using RestauranteApp.WPF.ViewModels;

namespace RestauranteApp.WPF.Views
{
    public partial class ResumenView : UserControl
    {
        public ResumenView(MainViewModel mainViewModel, OrdenService ordenService)
        {
            InitializeComponent(); 
            DataContext = new ResumenViewModel(mainViewModel, ordenService);
        }
    }
}
