using System;
using System.Collections.Generic;

namespace MyWinFormsAppForDb.Models
{
	public partial class Datum
	{
		public int DataId { get; set; }
		public int? MeasurementId { get; set; }
		public decimal? ApparentResistivity { get; set; }
		public decimal? EffectiveThickness { get; set; }

		public virtual Measurement? Measurement { get; set; }
	}
}
