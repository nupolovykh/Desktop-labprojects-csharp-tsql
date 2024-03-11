using System;
using System.Collections.Generic;

namespace application_win_form_db.Models
{
    public partial class Terrain
    {
        public Terrain()
        {
            SurveyLines = new HashSet<SurveyLine>();
        }

        public int TerrainId { get; set; }
        public int? ProjectId { get; set; }
        public string? Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? TerrainType { get; set; }
        public int? SizeInSquareMeters { get; set; }

        public virtual Project? Project { get; set; }
        public virtual ICollection<SurveyLine> SurveyLines { get; set; }
    }
}
