using System;
using System.Collections.Generic;

namespace MyWinFormsAppForDb.Models
{
	public partial class Customer
	{
		public Customer()
		{
			Projects = new HashSet<Project>();
		}

		public int CustomerId { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Phone { get; set; }

		public virtual ICollection<Project> Projects { get; set; }
	}
}
