using Lab7.Models.Database;
using Lab7.Models.Database.Entity;

namespace Lab7.Services.DbWorker
{
	public interface IDbWorker
	{
		List<User> Users { get; }
		List<Role> Roles { get; }
		AppDbContext Context { get; }
		void SaveChanges();
	}
}
