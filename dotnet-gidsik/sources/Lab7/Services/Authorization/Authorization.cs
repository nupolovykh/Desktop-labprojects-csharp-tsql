using Lab7.Models.Database.Entity;
using Lab7.Services.DbWorker;
using Lab7.ViewModels;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace Lab7.Services.Authorization
{
	public class Authorization : IAuthorization
	{
		private User _currentUser;

		private readonly IDbWorker _worker;

		public Authorization(IDbWorker worker)
		{
			_worker = worker;
		}

		public User CurrentUser => _currentUser;

		public void Login(string login, string password)
		{
			var user = _worker.Users.FirstOrDefault(u => u.Login == login && u.Password == password.Hash_MD5());

			if (user is null) return;

			_currentUser = user;

            MessangeLog(user);
        }

		public void SignIn(string login, string password)
		{
			var user = _worker.Users.FirstOrDefault(u => u.Login == login && u.Password == password.Hash_MD5());

			if (user is not null) return;

			user = new User()
			{
				Id = _worker.Users.Count() + 1,
				Login = login,
				Password = password.Hash_MD5(),
				RoleId = 2
			};

			_currentUser = user;
			_worker.Context.Users.Add(user);
			_worker.SaveChanges();

			MessangeLog(user);
        }

		public void LogOut()
		{
			_currentUser = null!;
			MessageBox.Show("success");
		}

        private void MessangeLog(User user)
        {
            MessageBox.Show("success");
            MessageBox.Show($"{user.Login}");
        }

        public string RandomString()
        {
			var random = new Random();
			int length = random.Next(10) + 10;

			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			IEnumerable<string> repeated = Enumerable.Repeat(chars, length);
			return new string(repeated.Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
