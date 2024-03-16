using application_win_form_db.Models;
using application_win_form_db.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace application_win_form_db.Services.Implementations
{
	internal class RealDbWorker : IDbWorker
	{
		private AppDbContext _context;

		public RealDbWorker(AppDbContext context) 
		{
			_context = context;

			///////////////// Inspect the troubles of db

			if (!_context.Database.CanConnect())
			{
				MessageBox.Show("App has no bound with db");
			}

			_context.Users.Load();

			if (_context.Users.Count() == 0) MessageBox.Show("Db has no items inside");

			/////////////////
		}

		public IEnumerable<User> Users => _context.Users.ToList(); 

		public void SaveChanges() => _context.SaveChanges();
	}
}
