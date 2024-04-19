namespace MyWinFormsAppForDb.Services.Interfaces
{
	public interface IUserIdentity
	{
		public void Login(User user);

		public User GetUser();

		public string GetRole();

		public void LogOut();
	}
}
