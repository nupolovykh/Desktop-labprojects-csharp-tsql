using Lab7.Commands;
using Lab7.Services.Authorization;
using Lab7.Services.ViewManager;
using Lab7.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		private readonly IAuthorization _authorization;
		private readonly IViewsManager _viewsManager;
		private readonly IServiceProvider _provider;

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
		public ICommand OpenRegisCommand { get; set; }

		public LoginViewModel() { }

		public LoginViewModel(IServiceProvider provider, IAuthorization authorization, IViewsManager viewsManager)
		{
			_authorization = authorization;
			_viewsManager = viewsManager;
			_provider = provider;

			LoginCommand = new DelegateCommand(
				action: (_) =>
				{
					_authorization.Login(Login, Password);

					if(_authorization.CurrentUser is not null)
					{
						var context = _provider.GetRequiredService<UserInfoViewModel>();
						_viewsManager.Open<UserInfoView>(context);
					}
				},
				condition: (_) =>
				{
					return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
				},
				vmb: this);

			OpenRegisCommand = new DelegateCommand(
				action: (_) =>
				{
					var context = _provider.GetRequiredService<RegisViewModel>();
					_viewsManager.Open<Regis>(context);
				},
				condition: (_) => true,
				vmb: this);
		}
	}
}
