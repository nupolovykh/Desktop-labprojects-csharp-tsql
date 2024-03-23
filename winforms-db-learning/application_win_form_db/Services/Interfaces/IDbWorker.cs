using application_win_form_db.Models;
using System.Xml.Linq;

namespace application_win_form_db.Services.Interfaces
{
	public interface IDbWorker
	{
		IEnumerable<User> Users { get; }

		IEnumerable<Operator> Operators { get; }

		IEnumerable<SurveyLine> SurveyLines { get; }

		IEnumerable<Terrain> Terrains { get; }

		IEnumerable<Equipment> Equipment { get; }

		IEnumerable<Picket> Pickets { get; }

		IEnumerable<Project> Projects { get; }

		IEnumerable<Customer> Customers { get; }

		IEnumerable<Measurement> Measurements { get; }

		IEnumerable<Datum> Datum { get; }

		public void SaveChanges();
	}
}
