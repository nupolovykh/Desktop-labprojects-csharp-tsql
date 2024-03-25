
using application_win_form_db.Models;

namespace application_win_form_db.Services.Implementations
{
	internal class RealDbWorker : IDbWorker
	{
		private AppDbContext _context;

		private readonly List<User> _users;
		private readonly List<Operator> _operators;
		private readonly List<SurveyLine> _surveyLines;
		private readonly List<Terrain> _terrains;
		private readonly List<Equipment> _equipment;
		private readonly List<Picket> _pickets;
		private readonly List<Project> _projects;
		private readonly List<Customer> _customers;
		private readonly List<Measurement> _measurements;
		private readonly List<Datum> _data;

		public RealDbWorker(AppDbContext context)
		{
			_context = context;

			_users = _context.Users
				.Include(x => x.Operator)
					.ToList();
			
			_operators = _context.Operators
				.Include(x => x.SurveyLine)
				.Include(x => x.User)
					.ToList();

			_surveyLines = _context.SurveyLines
				.Include(x => x.Terrain)
				.Include(x => x.Equipment)
				.Include(x => x.Operator)
				.Include(x => x.Pickets)
					.ToList();

			_terrains = _context.Terrains
				.Include(x => x.Project)
				.Include(x => x.SurveyLines)
					.ToList();

			_equipment = _context.Equipment
				.Include(x => x.SurveyLine)
					.ToList();

			_pickets = _context.Pickets
				.Include(x => x.SurveyLine)
				.Include(x => x.Measurements)
					.ToList();

			_projects = _context.Projects
				.Include(x => x.Customer)
				.Include(x => x.Terrains)
					.ToList();

			_customers = _context.Customers
				.Include(x => x.Projects)
					.ToList();

			_measurements = _context.Measurements
				.Include(x => x.Picket)
				.Include(x => x.Data)
					.ToList();

			_data = _context.Data
				.Include(x => x.Measurement)
					.ToList();
		}

		public IEnumerable<User> Users => _users;

		public IEnumerable<Operator> Operators => _operators;

		public IEnumerable<SurveyLine> SurveyLines => _surveyLines;

		public IEnumerable<Terrain> Terrains => _terrains;

		public IEnumerable<Equipment> Equipment => _equipment;

		public IEnumerable<Picket> Pickets => _pickets;

		public IEnumerable<Project> Projects => _projects;

		public IEnumerable<Customer> Customers => _customers;

		public IEnumerable<Measurement> Measurements => _measurements;

		public IEnumerable<Datum> Datum => _data;

		public void SaveChanges() => _context.SaveChanges();
	}
}
