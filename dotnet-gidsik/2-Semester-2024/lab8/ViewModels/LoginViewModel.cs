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
        private readonly IDropBoxGateway _gateway;

        public LoginViewModel(IMVVMNavigationService navigation, IDropBoxGateway gateway)
        {
            Title = "Login";
            _navigation = navigation;
            _gateway = gateway;
        }

        private string key;

        public string Key
		{
            get { return key; }
            set { key = value; }
        }

        private ICommand getKey = null!;

        public ICommand GetKey => getKey ??= new DelegatedCommand(
            action: _ => {

                Process.Start(new ProcessStartInfo()
                {
                    FileName = _gateway.ReferToBrowser,
                    UseShellExecute = true
                });

            },
            canExecute: _ => true
        );

		private ICommand setKey = null!;

		public ICommand SetKey => setKey ??= new DelegatedCommand(
			action: async (_) => {

                bool success = await _gateway.oAuth2Token(Key);
                if (success) _navigation.NavigateTo<ExplorerViewModel>();

			},
			canExecute: _ => true
		);
	}
}
