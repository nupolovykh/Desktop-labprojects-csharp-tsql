using System;
using System.Collections.Generic;

namespace application_win_form_db.Models
{
    public partial class Picket
    {
        public Picket()
        {
            Measurements = new HashSet<Measurement>();
        }

        public int PicketId { get; set; }
        public int? SurveyLineId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual SurveyLine? SurveyLine { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
