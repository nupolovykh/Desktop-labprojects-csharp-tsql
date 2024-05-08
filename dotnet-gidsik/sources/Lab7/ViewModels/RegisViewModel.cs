using Lab7.Commands;
using Lab7.Services.Authorization;
using Lab7.Services.ViewManager;
using Lab7.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class RegisViewModel : ViewModelBase
	{
		private readonly IAuthorization _authorization;
		private readonly IViewsManager _viewsManager;
		private readonly IServiceProvider _provider;

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
				MyStateChanged!.Invoke();
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

		public event Action? MyStateChanged;

		public ICommand RegisCommand { get; set; }
		public ICommand GeneratePassword { get; set; }
		public ICommand OpenLoginCommand { get; set; }

		public RegisViewModel() { }

		public RegisViewModel(IServiceProvider provider, IAuthorization authorization, IViewsManager viewsManager)
		{
			_authorization = authorization;
			_viewsManager = viewsManager;
			_provider = provider;

			MyStateChanged += () => OnPropertyChanged(nameof(Password));

			RegisCommand = new DelegateCommand(
				action: (_) =>
				{
					authorization.SignIn(_login!, _password!);

					if(_authorization.CurrentUser is not null)
					{
						var context = _provider.GetRequiredService<UserInfoViewModel>();
						_viewsManager.Open<UserInfoView>(context);
					}
				},
				condition: (_) =>
				{
					return !string.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(_password) && !string.IsNullOrEmpty(_password2);
				},
				vmb: (this));

			GeneratePassword = new DelegateCommand(
			   action: (_) =>
			   {
				   Password = _authorization.RandomString();
			   },
			   condition: (_) =>
			   {
				   return string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_password2);
			   },
			   vmb: (this));

			OpenLoginCommand = new DelegateCommand(
				action: (_) =>
				{
					var context = _provider.GetRequiredService<LoginViewModel>();
					_viewsManager.Open<Login>(context);
				},
				condition: (_) => true,
				vmb: this);
		}

		public override void Dispose()
		{
			MyStateChanged -= () => OnPropertyChanged(nameof(Password));
			base.Dispose();
		}
	}
}
