using Lab7.Commands;
using Lab7.Services.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class RegisViewModel : ViewModelBase
	{
		private string _login;
		public string Login
		{
			get => _login;
			set
			{
				_login = value;
				OnPropertyChanged(nameof(_login));
			}
		}


		private string _password;
		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged(nameof(_password));
			}
		}

		private string _password2;
		public string Password2
		{
			get => _password2;
			set
			{
				_password2 = value;
				OnPropertyChanged(nameof(_password2));
			}
		}

		public ICommand RegisCommand { get; set; }

		public RegisViewModel(IAuthorization authorization)
		{
			RegisCommand = new DelegateCommand(
				action: (_) =>
				{
					authorization.SignIn(_login!, _password!);
				},
				condition: (_) =>
				{
					return !string.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(_password);
				},
				vmb: (this));
		}
	}
}
