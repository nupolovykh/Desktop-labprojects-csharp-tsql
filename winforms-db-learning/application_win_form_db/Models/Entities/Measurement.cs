using System;
using System.Collections.Generic;

namespace application_win_form_db.Models
{
	public partial class Measurement
	{
		public Measurement()
		{
			Data = new HashSet<Datum>();
		}

		public int MeasurementId { get; set; }
		public int? PicketId { get; set; }
		public DateTime? MeasurementDate { get; set; }
		public TimeSpan? MeasurementTime { get; set; }
		public string? Notes { get; set; }

		public virtual Picket? Picket { get; set; }
		public virtual ICollection<Datum> Data { get; set; }
	}
}
