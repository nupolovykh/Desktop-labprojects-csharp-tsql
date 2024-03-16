using System;
using System.Collections.Generic;

namespace application_win_form_db.Models
{
    public partial class Operator
    {
        public int OperatorId { get; set; }
        public int? SurveyLineId { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public int? UserId { get; set; }

        public virtual SurveyLine? SurveyLine { get; set; }
        public virtual User? User { get; set; }
    }
}
