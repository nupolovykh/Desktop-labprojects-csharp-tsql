using Lab8.Commands;
using Lab8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _navigation;
        private readonly IDropBoxReferModule _refer;

        public LoginViewModel(IMVVMNavigationService navigation, IDropBoxReferModule refer)
        {
            Title = "Login";
            _navigation = navigation;
            _refer = refer;
        }

        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private ICommand _OAuth = null!;
        public ICommand OAuth => _OAuth ??= new DelegatedCommand(
            action: _ => {

                //Process.Start(new ProcessStartInfo()
                //{
                //    FileName = "",//_refer.AuthUrl,
                //    UseShellExecute = true
                //});

                if (_refer.GetAuth())
                {
                    _navigation.NavigateTo<ExplorerViewModel>();
                };

            },
            canExecute: _ => true
        );
    }
}
