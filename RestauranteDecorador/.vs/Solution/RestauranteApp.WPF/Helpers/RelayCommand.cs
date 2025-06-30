using System;
using System.Windows.Input;

namespace RestauranteApp.WPF.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action _ejecutar;
        private readonly Func<bool> _puedeEjecutar;

        public RelayCommand(Action ejecutar, Func<bool> puedeEjecutar = null)
        {
            _ejecutar = ejecutar ?? throw new ArgumentNullException(nameof(ejecutar));
            _puedeEjecutar = puedeEjecutar;
        }

        public bool CanExecute(object parameter) => _puedeEjecutar == null || _puedeEjecutar();
        public void Execute(object parameter) => _ejecutar();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _ejecutar;
        private readonly Func<T, bool> _puedeEjecutar;

        public RelayCommand(Action<T> ejecutar, Func<T, bool> puedeEjecutar = null)
        {
            _ejecutar = ejecutar ?? throw new ArgumentNullException(nameof(ejecutar));
            _puedeEjecutar = puedeEjecutar;
        }

        public bool CanExecute(object parameter) => _puedeEjecutar == null || _puedeEjecutar((T)parameter);
        public void Execute(object parameter) => _ejecutar((T)parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
