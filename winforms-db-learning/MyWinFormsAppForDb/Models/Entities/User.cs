using System;
using System.Collections.Generic;

namespace MyWinFormsAppForDb.Models
{
	public partial class User
	{
		public int UserId { get; set; }
		public string? Login { get; set; }
		public string? Password { get; set; }
		public string? Role { get; set; }
		public string? Notes { get; set; }

		public virtual Operator? Operator { get; set; }
	}
}
