using Lab7.Commands;
using Lab7.Models.Database.Entity;
using Lab7.Services.Authorization;
using Lab7.Services.ViewManager;
using Lab7.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class UserInfoViewModel : ViewModelBase
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
				OnPropertyChanged(nameof(Login));
			}
		}

		private string _roleName;
		public string RoleName
		{
			get => _roleName;
			set
			{
				_roleName = value;
				OnPropertyChanged(nameof(RoleName));
			}
		}

		public ICommand SignOut { get; set; }
		public ICommand OpenUsersList { get; set; }

		public UserInfoViewModel() { }

		public UserInfoViewModel(IServiceProvider provider, IAuthorization authorization, IViewsManager viewsManager)
		{
			_authorization = authorization;
			_viewsManager = viewsManager;
			_provider = provider;

			Login = _authorization.CurrentUser.Login;
			RoleName = _authorization.CurrentUser.Role.Name;

			SignOut = new DelegateCommand(
				action: (_) =>
				{
					_authorization.LogOut();
					var context = _provider.GetRequiredService<LoginViewModel>();
					_viewsManager.Open<Login>(context);
				},
				condition: (_) =>
				{
					return !string.IsNullOrEmpty(Login);
				},
				vmb: this);

			OpenUsersList = new DelegateCommand(
				action: (_) =>
				{
					var context = _provider.GetRequiredService<UsersListViewModel>();
					_viewsManager.Open<UsersListView>(context);
				},
				condition: (_) => RoleName is "Admin",
				vmb: this);
		}
	}
}
