using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Models.Database.Entity
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int RoleId { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }

		[ForeignKey("RoleId")]
		public Role Role { get; set; }
	}
}
