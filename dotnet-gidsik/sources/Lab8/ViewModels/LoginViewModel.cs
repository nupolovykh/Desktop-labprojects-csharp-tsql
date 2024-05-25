using Lab8.Commands;
using Lab8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _nav;

        public LoginViewModel(IMVVMNavigationService nav)
        {
            Title = "Login";
            _nav = nav;
        }

        private ICommand _login = null!;
        public ICommand Login => _login ??= new DelegatedCommand(
            action: _ => { },
            canExecute: _ => true
        );
    }
}
