namespace application_win_form_db.Services.Interfaces
{
	public interface IDbWorker
	{
		IEnumerable<User> Users { get; }

		public void SaveChanges();
	}
}
