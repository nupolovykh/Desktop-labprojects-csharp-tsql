using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.Commands
{
    internal class DelegatedCommand : ICommand
    {
        private Action<object?> _action;
        private Predicate<object?> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegatedCommand(Action<object?> action, Predicate<object?> canExecute = null!)
        {
            _action = action;
            _canExecute = canExecute ?? ((_) => true);
        }

        public bool CanExecute(object? parameter) => _canExecute(parameter);

        public void Execute(object? parameter) => _action.Invoke(parameter);
    }
}
