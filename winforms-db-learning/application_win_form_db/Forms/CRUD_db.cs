using System.Collections.ObjectModel;

namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private bool state_for_closing = false;

		private Dictionary<string, ObservableCollection<object>> dictionary = new Dictionary<string, ObservableCollection<object>>();

		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

			PopulationOfTheTablesComboBox();

		}

		//main logic

		private void PopulationOfTheTablesComboBox()
		{
			var tables = _serviceProvider.GetService<AppDbContext>()!
				.Model.GetEntityTypes().Select(x => x.GetTableName())
					.ToList();

			foreach (var tableName in tables)
			{
				if (tableName == "Data")
				{
					cmbBx_tables.Items.Add("Datum");
					PopulationOfDictionary("Datum");
					continue;
				}

				cmbBx_tables.Items.Add(tableName);
				PopulationOfDictionary(tableName!);
			}

			cmbBx_tables.SelectedIndex = 0;
		}

		private void PopulationOfDictionary(string tablename)
		{
			ObservableCollection<object> list = null!;

			switch (tablename)
			{
				case nameof(_worker.Customers):
					list = new ObservableCollection<object>(_worker.Customers);
					//list = (_worker.Customers.ToList<object>());
					break;

				case nameof(_worker.Equipment):
					list = new ObservableCollection<object>(_worker.Equipment);
					//list = _worker.Equipment.ToList<object>();
					break;

				case nameof(_worker.Projects):
					list = new ObservableCollection<object>(_worker.Projects);
					//list = _worker.Projects.ToList<object>();
					break;

				case nameof(_worker.Pickets):
					list = new ObservableCollection<object>(_worker.Pickets);
					//list = _worker.Pickets.ToList<object>();
					break;

				case nameof(_worker.Datum):
					list = new ObservableCollection<object>(_worker.Datum);
					//list = _worker.Datum.ToList<object>();
					break;

				case nameof(_worker.Operators):
					list = new ObservableCollection<object>(_worker.Operators);
					//list = _worker.Operators.ToList<object>();
					break;

				case nameof(_worker.Users):
					list = new ObservableCollection<object>(_worker.Users);
					//list = _worker.Users.ToList<object>();
					break;

				case nameof(_worker.SurveyLines):
					list = new ObservableCollection<object>(_worker.SurveyLines);
					//list = _worker.SurveyLines.ToList<object>();
					break;

				case nameof(_worker.Terrains):
					list = new ObservableCollection<object>(_worker.Terrains);
					//list = _worker.Terrains.ToList<object>();
					break;

				case nameof(_worker.Measurements):
					list = new ObservableCollection<object>(_worker.Measurements);
					//list = _worker.Measurements.ToList<object>();
					break;

				default:
					MessageBox.Show("Some problems with convertation");
					break;
			}

			if (list is not null)
			{
				dictionary!.Add(tablename, list);
			}
		}

		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if (dictionary.ContainsKey(key!))
			{
				dgv.DataSource = dictionary[key!];
			}

			HidingOfNavigationFields();
		}

		private void HidingOfNavigationFields()
		{
			foreach (DataGridViewColumn column in dgv.Columns)
			{
				if (column.ValueType.IsInterface || (column.ValueType.IsClass && column.ValueType != typeof(string)))
				{
					column.Visible = false;
				}
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
		}

		//logic of crud_buttons

		private void btn_save_Click(object sender, EventArgs e)
		{
			MessageBox.Show(dictionary["Customers"].Count.ToString());
			_worker.SaveChanges();
		}

		private void btn_c_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if(dictionary[key!].Count == 0 || key is null) return;

			var type = dictionary[key].First().GetType()!;
			var entity = AddObjectWithSevereType(type, key);
			if (entity is not null) dictionary[key].Add(entity);

			///maybe it must be disposed
			dgv.DataSource = null;
			dgv.DataSource = dictionary[key!];
			HidingOfNavigationFields();
		}

		private object AddObjectWithSevereType(Type type, string key)
		{
			object entity = null!;
			int nextId = dictionary[key].Count + 1;

			if (type == typeof(User))
			{
				entity = new User() { UserId = nextId };
			}
			else if(type == typeof(Customer)) 
			{
				entity = new Customer() { CustomerId = nextId };
			}
			else if (type == typeof(Datum))
			{
				entity = new Datum() { DataId = nextId };
			}
			else if (type == typeof(Equipment))
			{
				entity = new Equipment() { EquipmentId = nextId };
			}
			else if (type == typeof(Measurement))
			{
				entity = new Measurement() { MeasurementId = nextId };
			}
			else if (type == typeof(Operator))
			{
				entity = new Operator() { OperatorId = nextId };
			}
			else if (type == typeof(Picket))
			{
				entity = new Picket() { PicketId = nextId };
			}
			else if (type == typeof(Project))
			{
				entity = new Project() { ProjectId = nextId };
			}
			else if (type == typeof(SurveyLine))
			{
				entity = new SurveyLine() { SurveyLineId = nextId };
			}
			else if (type == typeof(Terrain))
			{
				entity = new Terrain() { TerrainId = nextId };
			}
			return entity;
		}

		private void button_d_Click(object sender, EventArgs e)
		{
			
		}

		// logic of navigation buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			var main = _serviceProvider.GetService<Main>();
			main!.Show();
			state_for_closing = true;

			this.Close();
		}

		//another logic of the form

		private void CRUD_db_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !state_for_closing)
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				entrance!.Show();
			}
		}
	}
}
