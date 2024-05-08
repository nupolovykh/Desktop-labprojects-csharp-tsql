using Lab7.Models.Database;
using Lab7.Models.Database.Entity;

namespace Lab7.Services.DbWorker
{
	public interface IDbWorker
	{
		IEnumerable<User> Users { get; }
		IEnumerable<Role> Roles { get; }
		AppDbContext Context { get; }
		void SaveChanges();
	}
}
