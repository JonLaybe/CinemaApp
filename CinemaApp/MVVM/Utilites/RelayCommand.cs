using System;
using System.Windows.Input;

namespace CinemaApp.MVVM.Utilites
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            _action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            this._action(parameter);
        }
    }
}
