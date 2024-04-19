namespace application_win_form_db.Services.Implementations
{
	internal class FakeDbWorker : IDbWorker
	{
		public List<User> _users;
		public List<Operator> _operators;
		public List<SurveyLine> _surveyLines;
		public List<Terrain> _terrains;
		public List<Equipment> _equipment;
		public List<Picket> _pickets;
		public List<Project> _projects;
		public List<Customer> _customers;
		public List<Measurement> _measurements;
		public List<Datum> _data;

		private Dictionary<string, ObservableCollection<object>> _entityDictionary = new();
		private Dictionary<string, Type> _typeToId = new();

		public FakeDbWorker(IServiceProvider provider)
		{

			_users = new List<User>()
			{
				new User { UserId = 1, Login = "admin", Password = "123", Role = "Admin", Notes="Edit yout Notes" },
				new User { UserId = 2, Login = "analyst", Password = "456", Role = "Analyst", Notes = "Edit yout Notes" },
				new User { UserId = 3, Login = "application_operator", Password = "789", Role = "Application Operator", Notes = "Edit yout Notes" },
				new User { UserId = 4, Login = "survey_operator", Password = "910", Role = "Survey Operator", Notes = "Edit yout Notes" }
			};
			_entityDictionary.Add(nameof(Users), new ObservableCollection<object>(Users));
			var anyUser = _users.First();
			_typeToId.Add(nameof(Users), anyUser.GetType());

			_operators = new List<Operator>()
			{
				new Operator { OperatorId = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890",
					Surname = "Engineer", SurveyLineId = 1, UserId = 1 },
				new Operator { OperatorId = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210",
					Surname = "Technician", SurveyLineId = 2, UserId = 2 },
				new Operator { OperatorId = 3, FirstName = "Michael", LastName = "Johnson", Phone = "555-123-4567",
					Surname = "Analyst", SurveyLineId = 3, UserId = 3 },
				new Operator { OperatorId = 4, FirstName = "Emily", LastName = "Brown", Phone = "555-987-6543",
					Surname = "Technician", SurveyLineId = 4, UserId = 4 }
			};
			_entityDictionary.Add(nameof(Operators), new ObservableCollection<object>(Operators));
			var anyOperator = _operators.First();
			_typeToId.Add(nameof(Operators), anyOperator.GetType());

			_surveyLines = new List<SurveyLine>()
			{
				new SurveyLine { SurveyLineId = 1, Latitude = 40.730610m, Longitude = -73.935242m, LengthInMeters = 1000,
					Name = "Utility Survey Line A", TerrainId = 1},
				new SurveyLine { SurveyLineId = 2, Latitude = 34.052235m, Longitude = -118.243683m, LengthInMeters = 1500,
					Name = "Seismic Survey Line B", TerrainId = 2 },
				new SurveyLine { SurveyLineId = 3, Latitude = 35.6895m, Longitude = 139.6917m, LengthInMeters = 1200,
					Name = "Geophysical Survey Line C", TerrainId = 3 },
				new SurveyLine { SurveyLineId = 4, Latitude = 51.5074m, Longitude = -0.1278m, LengthInMeters = 1800,
					Name = "Topographic Survey Line D", TerrainId = 4 },
				new SurveyLine { SurveyLineId = 5, Latitude = 41.9028m, Longitude = 12.4964m, LengthInMeters = 900,
					Name = "Aerial Survey Line E", TerrainId = 4 }
			};
			_entityDictionary.Add(nameof(SurveyLines), new ObservableCollection<object>(SurveyLines));
			var anySurveyLine = _surveyLines.First();
			_typeToId.Add(nameof(SurveyLines), anySurveyLine.GetType());

			_terrains = new List<Terrain>()
			{
				new Terrain { TerrainId = 1, Latitude = 40.730610m, Longitude = -73.935242m, Name = "Urban Utility Area",
					ProjectId = 1, SizeInSquareMeters = 5000, TerrainType = "Urban" },
				new Terrain { TerrainId = 2, Latitude = 34.052235m, Longitude = -118.243683m, Name = "Seismic Activity Zone",
					ProjectId = 2, SizeInSquareMeters = 7500, TerrainType = "Geological" },
				new Terrain { TerrainId = 3, Latitude = 51.507351m, Longitude = -0.127758m, Name = "Archaeological Excavation Site",
					ProjectId = 3, SizeInSquareMeters = 4000, TerrainType = "Historical" },
				new Terrain { TerrainId = 4, Latitude = 48.856613m, Longitude = 2.352222m, Name = "Environmental Conservation Zone",
					ProjectId = 4, SizeInSquareMeters = 6000, TerrainType = "Ecological" }
			};
			_entityDictionary.Add(nameof(Terrains), new ObservableCollection<object>(Terrains));
			var anyTerrain = _terrains.First();
			_typeToId.Add(nameof(Terrains), anyTerrain.GetType());

			_equipment = new List<Equipment>()
			{
				new Equipment { EquipmentId = 1, Name = "ElectraScan Pro", SurveyLineId = 1, Description = "The ElectraScan Pro is a cutting-edge" +
					" electrical tomography device designed for high-precision" +" imaging of internal structures."},
				new Equipment { EquipmentId = 2, Name = "VoltVision Elite", SurveyLineId = 2, Description = "The VoltVision Elite is a sophisticated" +
					" electrical tomography system that offers real-time monitoring and analysis capabilities."},
				new Equipment { EquipmentId = 3, Name = "OhmSense Ultra", SurveyLineId = 3, Description = "The OhmSense Ultra is a compact and portable" +
					" electrical tomography device suitable for field surveys and on-site inspections."},
				new Equipment { EquipmentId = 4, Name = "CurrentWave Prodigy", SurveyLineId = 4, Description = "The CurrentWave Prodigy is a versatile" +
					" electrical tomography instrument tailored for medical imaging and geological surveys."},
				new Equipment { EquipmentId = 5, Name = "ImpedanceMaster Plus", SurveyLineId = 5, Description = "The ImpedanceMaster Plus combines" +
					" impedance spectroscopy with tomographic imaging to deliver comprehensive electrical property maps." }
			};
			_entityDictionary.Add(nameof(Equipment), new ObservableCollection<object>(Equipment));
			var anyEquipment = _equipment.First();
			_typeToId.Add(nameof(Equipment), anyEquipment.GetType());

			_pickets = new List<Picket>()
			{
				new Picket { PicketId = 1, Latitude = 40.730610m, Longitude = -73.935242m, SurveyLineId = 1 },
				new Picket { PicketId = 2, Latitude = 34.052235m, Longitude = -118.243683m, SurveyLineId = 2 },
				new Picket { PicketId = 3, Latitude = 51.507351m, Longitude = -0.127758m, SurveyLineId = 1 },
				new Picket { PicketId = 4, Latitude = 48.856613m, Longitude = 2.352222m, SurveyLineId = 2 },
				new Picket { PicketId = 5, Latitude = 68.856613m, Longitude = 1.812426m, SurveyLineId = 3 }
			};
			_entityDictionary.Add(nameof(Pickets), new ObservableCollection<object>(Pickets));
			var anyPicket = _pickets.First();
			_typeToId.Add(nameof(Pickets), anyPicket.GetType());

			_projects = new List<Project>()
			{
				new Project { ProjectId = 1, CustomerId = 1, Description = "Geophysical survey for underground utilities",
					EndDate = new DateTime(2024, 8, 31), Name = "Utility Survey Project", StartDate = new DateTime(2024, 8, 1), Status = "Ongoing" },
				new Project { ProjectId = 2, CustomerId = 2, Description = "Seismic data collection for geological analysis",
					EndDate = new DateTime(2024, 12, 31), Name = "Seismic Analysis Project", StartDate = new DateTime(2024, 9, 1), Status = "Planned" },
				new Project { ProjectId = 3, CustomerId = 1, Description = "Magnetic anomaly mapping for archaeological study",
					EndDate = new DateTime(2025, 3, 31), Name = "Archaeological Mapping Project", StartDate = new DateTime(2025, 1, 1), Status = "In Progress" },
				new Project { ProjectId = 4, CustomerId = 3, Description = "Electrical resistivity profiling for environmental research",
					EndDate = new DateTime(2024, 11, 30), Name = "Environmental Profiling Project", StartDate = new DateTime(2024, 10, 1), Status = "Completed" }
			};
			_entityDictionary.Add(nameof(Projects), new ObservableCollection<object>(Projects));
			var anyProject = _projects.First();
			_typeToId.Add(nameof(Projects), anyProject.GetType());

			_customers = new List<Customer>()
			{
				new Customer { CustomerId = 1, Name = "John Smith", Address = "123 Main St.", City = "Los Angeles", Phone = "+1-323-456-7890" },
				new Customer { CustomerId = 2, Name = "Jane Doe", Address = "456 Oak Ave.", City = "New York", Phone = "+1-646-123-4567" },
				new Customer { CustomerId = 3, Name = "Mary Johnson", Address = "789 Pine St.", City = "Chicago", Phone = "+1-773-234-5678" }
			};
			_entityDictionary.Add(nameof(Customers), new ObservableCollection<object>(Customers));
			var anyCustomer = _customers.First();
			_typeToId.Add(nameof(Customers), anyCustomer.GetType());

			_measurements = new List<Measurement>()
			{
				new Measurement { MeasurementId = 1, MeasurementDate = new DateTime(2024, 3, 15),
					MeasurementTime = new TimeSpan(14, 30, 0), PicketId = 1, Notes = "Detailed notes for Measurement 1." },
				new Measurement { MeasurementId = 2, MeasurementDate = new DateTime(2024, 3, 16),
					MeasurementTime = new TimeSpan(15, 45, 0), PicketId = 2, Notes = "Detailed notes for Measurement 2." },
				new Measurement { MeasurementId = 3, MeasurementDate = new DateTime(2024, 3, 17),
					MeasurementTime = new TimeSpan(11, 20, 0), PicketId = 3, Notes = "Detailed notes for Measurement 3." },
				new Measurement { MeasurementId = 4, MeasurementDate = new DateTime(2024, 3, 18),
					MeasurementTime = new TimeSpan(10, 0, 0), PicketId = 4, Notes = "Detailed notes for Measurement 4." },
				new Measurement { MeasurementId = 5, MeasurementDate = new DateTime(2024, 3, 19),
					MeasurementTime = new TimeSpan(12, 15, 0), PicketId = 5, Notes = "Detailed notes for Measurement 5." }
			};
			_entityDictionary.Add(nameof(Measurements), new ObservableCollection<object>(_measurements));
			var anyMeasurement = _measurements.First();
			_typeToId.Add(nameof(Measurements), anyMeasurement.GetType());

			_data = new List<Datum>()
			{
				new Datum { DataId = 1, MeasurementId = 1, ApparentResistivity = 823456789012.275678m, EffectiveThickness = 983056789012.465698m },
				new Datum { DataId = 2, MeasurementId = 1, ApparentResistivity = 968260789096.135970m, EffectiveThickness = 235928785428.346638m },
				new Datum { DataId = 3, MeasurementId = 1, ApparentResistivity = 146704889063.141658m, EffectiveThickness = 123456756039.215608m },
				new Datum { DataId = 4, MeasurementId = 1, ApparentResistivity = 783545778764.783123m, EffectiveThickness = 456287638910.892145m },
				new Datum { DataId = 5, MeasurementId = 1, ApparentResistivity = 354678965428.912233m, EffectiveThickness = 876523987451.084456m }
			};
			_entityDictionary.Add(nameof(Datum), new ObservableCollection<object>(_data));

			var anyData = _data.First();
			_typeToId.Add(nameof(Datum), anyData.GetType());

			//_entityDictionary.FakeSubscribeToCollectionChangesInDictionary(provider);
		}

		public Dictionary<string, ObservableCollection<object>> EntityDictionary
		{
			get { return _entityDictionary; }
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

		public void SaveChanges() { }

		public void DiscardChanges() { }
	}
}
