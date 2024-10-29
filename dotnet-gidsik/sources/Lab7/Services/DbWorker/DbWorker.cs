using Lab7.Models.Database;
using Lab7.Models.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Services.DbWorker
{
	public class DbWorker : IDbWorker
	{
		private readonly List<User> _users;
		private readonly List<Role> _roles;

		private readonly AppDbContext _context;

		public DbWorker(AppDbContext context)
		{
			_context = context;

			_users = context.Users.Include(u => u.Role).ToList();

			_roles = context.Roles.Include(r => r.Users).ToList();
		}

		public List<User> Users => _users;
		public List<Role> Roles => _roles;

		public AppDbContext Context => _context;

		public void SaveChanges() => _context.SaveChanges();
	}
}
