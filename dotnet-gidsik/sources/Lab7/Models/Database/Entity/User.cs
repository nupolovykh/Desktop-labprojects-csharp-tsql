using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Models.Database.Entity
{
	public class User
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public string Login { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public Role Role { get; set; }
	}
}
