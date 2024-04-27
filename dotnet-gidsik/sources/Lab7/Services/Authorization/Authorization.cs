using Lab7.Models.Database.Entity;
using Lab7.Services.DbWorker;
using System.Windows;

namespace Lab7.Services.Authorization
{
	public class Authorization : IAuthorization
	{
		private User _currentUser { get; set; }

		private readonly IDbWorker _worker;

		public Authorization(IDbWorker worker)
		{
			_worker = worker;
		}

		public void Login(string login, string password)
		{
			var user = _worker.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

			if (user is null) return;

			_currentUser = user;
			MessageBox.Show("success");
			MessageBox.Show($"{user}");
		}

		public void SignIn(string login, string password)
		{
			var user = _worker.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

			if (user is not null) return;

			user = new User()
			{
				Id = _worker.Users.Count() + 1,
				Login = login,
				Password = password,
				RoleId = 2
			};

			_currentUser = user;
			_worker.Context.Users.Add(user);
			_worker.SaveChanges();

			MessageBox.Show("success");
			MessageBox.Show($"{user}");
		}

		public void LogOut()
		{
			_currentUser = null!;
		}

		public User CurrentUser => _currentUser;

	}
}
