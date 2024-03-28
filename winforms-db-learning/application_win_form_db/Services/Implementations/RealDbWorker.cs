using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace application_win_form_db.Services.Implementations
{
	internal class RealDbWorker : IDbWorker
	{
		private readonly AppDbContext _context;

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

		private Dictionary<string, ObservableCollection<object>> _entityDictionary = new();
		private Dictionary<string, Type> _typeToId = new();

		public RealDbWorker(AppDbContext context)
		{
			_context = context;

			_users = _context.Users
				.Include(x => x.Operator)
					.ToList();
			_entityDictionary.Add(nameof(Users), new ObservableCollection<object>(Users));

			_operators = _context.Operators
				.Include(x => x.SurveyLine)
				.Include(x => x.User)
					.ToList();
			_entityDictionary.Add(nameof(Operators), new ObservableCollection<object>(Operators));

			_surveyLines = _context.SurveyLines
				.Include(x => x.Terrain)
				.Include(x => x.Equipment)
				.Include(x => x.Operator)
				.Include(x => x.Pickets)
					.ToList();
			_entityDictionary.Add(nameof(SurveyLines), new ObservableCollection<object>(SurveyLines));

			_terrains = _context.Terrains
				.Include(x => x.Project)
				.Include(x => x.SurveyLines)
					.ToList();
			_entityDictionary.Add(nameof(Terrains), new ObservableCollection<object>(Terrains));

			_equipment = _context.Equipment
				.Include(x => x.SurveyLine)
					.ToList();
			_entityDictionary.Add(nameof(Equipment), new ObservableCollection<object>(Equipment));

			_pickets = _context.Pickets
				.Include(x => x.SurveyLine)
				.Include(x => x.Measurements)
					.ToList();
			_entityDictionary.Add(nameof(Pickets), new ObservableCollection<object>(Pickets));

			_projects = _context.Projects
				.Include(x => x.Customer)
				.Include(x => x.Terrains)
					.ToList();
			_entityDictionary.Add(nameof(Projects), new ObservableCollection<object>(Projects));

			_customers = _context.Customers
				.Include(x => x.Projects)
					.ToList();
			_entityDictionary.Add(nameof(Customers), new ObservableCollection<object>(Customers));

			_measurements = _context.Measurements
				.Include(x => x.Picket)
				.Include(x => x.Data)
					.ToList();
			_entityDictionary.Add(nameof(_context.Measurements), new ObservableCollection<object>(_measurements));

			_data = _context.Data
				.Include(x => x.Measurement)
					.ToList();
			_entityDictionary.Add(nameof(_context.Data), new ObservableCollection<object>(_data));

			_typeToId.CreateTypeToIdDictionary(context);
			_entityDictionary.SubscribeToCollectionChangesInDictionary(context);
		}

		public Dictionary<string, ObservableCollection<object>> EntityDictionary
		{
			get { return _entityDictionary; }
			set {  _entityDictionary = value; }
		}

		public Dictionary<string, Type> TypeToId => _typeToId;

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
