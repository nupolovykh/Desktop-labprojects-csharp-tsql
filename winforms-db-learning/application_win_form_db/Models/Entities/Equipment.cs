using System;
using System.Collections.Generic;

namespace application_win_form_db.Models
{
    public partial class Equipment
    {
        public int EquipmentId { get; set; }
        public int? SurveyLineId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual SurveyLine? SurveyLine { get; set; }
    }
}
