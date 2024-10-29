using Lab7.Commands;
using Lab7.Models.Database.Entity;
using Lab7.Services.DbWorker;
using Lab7.Services.ViewManager;
using Lab7.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Lab7.ViewModels
{
	internal class UsersListViewModel : ViewModelBase
	{
		private readonly IDbWorker _worker;
		private readonly IViewsManager _viewsManager;
		private readonly IServiceProvider _provider;

		private IEnumerable<User> _users;
		public IEnumerable<User> Users => _users;

		public ICommand ReturnToUserInfo { get; set; }

		public UsersListViewModel() { }

		public UsersListViewModel(IServiceProvider provider, IDbWorker worker, IViewsManager viewsManager)
		{
			_worker = worker;
			_viewsManager = viewsManager;
			_provider = provider;

			_users = _worker.Users;

			ReturnToUserInfo = new DelegateCommand(
				action: (_) =>
				{
					var context = _provider.GetRequiredService<UserInfoViewModel>();
					_viewsManager.Open<UserInfoView>(context);
				},
				condition: (_) => true,
				vmb: this);
		}
	}
}
