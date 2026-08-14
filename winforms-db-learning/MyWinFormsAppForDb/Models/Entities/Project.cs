using System;
using System.Collections.Generic;

namespace MyWinFormsAppForDb.Models
{
	public partial class Project
	{
		public Project()
		{
			Terrains = new HashSet<Terrain>();
		}

		public int ProjectId { get; set; }
		public int? CustomerId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? Status { get; set; }

		public virtual Customer? Customer { get; set; }
		public virtual ICollection<Terrain> Terrains { get; set; }
	}
}
