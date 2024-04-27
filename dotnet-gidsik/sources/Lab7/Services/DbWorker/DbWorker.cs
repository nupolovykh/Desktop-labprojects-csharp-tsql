using Lab7.Models.Database;
using Lab7.Models.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

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

		public IEnumerable<User> Users => _users;
		public IEnumerable<Role> Roles => _roles;

		public AppDbContext Context => _context;

		public void SaveChanges() => _context.SaveChanges();
	}
}
