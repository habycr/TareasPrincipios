using System.Windows;
using RestauranteApp.WPF.ViewModels;

namespace RestauranteApp.WPF
{
    /// <summary>
    /// Ventana principal que aloja el flujo completo de la aplicación
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
