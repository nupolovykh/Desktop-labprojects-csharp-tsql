using System;
using System.Collections.Generic;

namespace MyWinFormsAppForDb.Models
{
	public partial class SurveyLine
	{
		public SurveyLine()
		{
			Pickets = new HashSet<Picket>();
		}

		public int SurveyLineId { get; set; }
		public int? TerrainId { get; set; }
		public string? Name { get; set; }
		public decimal? Latitude { get; set; }
		public decimal? Longitude { get; set; }
		public int? LengthInMeters { get; set; }

		public virtual Terrain? Terrain { get; set; }
		public virtual Equipment? Equipment { get; set; }
		public virtual Operator? Operator { get; set; }
		public virtual ICollection<Picket> Pickets { get; set; }
	}
}
