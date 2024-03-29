
namespace application_win_form_db.Services.Interfaces
{
	public interface IDbWorker
	{
		public Dictionary<string, ObservableCollection<object>> EntityDictionary { get; set; }

		public Dictionary<string, Type> TypeToId { get; }

		public IEnumerable<User> Users { get; }

		public IEnumerable<Operator> Operators { get; }

		public IEnumerable<SurveyLine> SurveyLines { get; }

		public IEnumerable<Terrain> Terrains { get; }

		public IEnumerable<Equipment> Equipment { get; }

		public IEnumerable<Picket> Pickets { get; }

		public IEnumerable<Project> Projects { get; }

		public IEnumerable<Customer> Customers { get; }

		public IEnumerable<Measurement> Measurements { get; }

		public IEnumerable<Datum> Datum { get; }

		public void SaveChanges();
	}
}
