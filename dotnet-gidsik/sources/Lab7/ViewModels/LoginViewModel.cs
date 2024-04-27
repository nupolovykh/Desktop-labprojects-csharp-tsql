using Lab7.Commands;
using Lab7.Services.Authorization;
using Lab7.Services.DbWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		private string _login = string.Empty;
		public string Login
		{
			get => _login;
			set
			{
				_login = value;
				OnPropertyChanged(nameof(Login));
			}
		}


		private string _password = string.Empty;
		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public ICommand LoginCommand { get; set; }

		public LoginViewModel() { } 
		public LoginViewModel(IAuthorization authorization) 
		{
			LoginCommand = new DelegateCommand(
				action: (_) =>
				{
					authorization.Login(_login, _password);
				},
				condition: (_) =>
				{
					return !string.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(_password);
				}, 
				vmb: this);
		}
	}
}
