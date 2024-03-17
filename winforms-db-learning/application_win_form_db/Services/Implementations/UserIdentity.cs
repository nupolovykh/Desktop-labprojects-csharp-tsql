

namespace application_win_form_db.Services.Implementations
{
	internal class UserIdentity : IUserIdentity
	{
		private User? _currentUser = null;	

		public void Login(User user)
		{
			_currentUser = user;
		}

		public User GetUser() => _currentUser!;

		public void LogOut()
		{
			_currentUser = null;
		}
	}
}
