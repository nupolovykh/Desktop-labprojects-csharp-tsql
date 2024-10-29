using Lab7.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab7.Commands
{
    internal class DelegateCommand : ICommand
    {
        private Action<object?> _action;
        private Func<object?, bool> _condition;
        //private Predicate<object?> _canExecute;

        private ViewModelBase _viewModel;

        public DelegateCommand(Action<object?> action, Func<object?, bool> condition, ViewModelBase vmb)
        {
            _action = action;
            _condition = condition;
            _viewModel = vmb;

            _viewModel.PropertyChanged += Login_PropertyChanged!;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? param) => CanExecuteChanged == null || _condition(param);

        public void Execute(object? param)
        {
            _action(param);
        }

        public void Login_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
