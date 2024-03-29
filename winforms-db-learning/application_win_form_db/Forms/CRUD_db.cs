namespace application_win_form_db{	public partial class CRUD_db : Form	{		private IServiceProvider _serviceProvider;		private IDbWorker _worker;		private bool state_for_closing = false;		private bool state_for_saving = true;		private Dictionary<string, ObservableCollection<object>> _dictionaryEntity;		private Dictionary<string, Type> _dictionaryType;		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)		{			InitializeComponent();			_serviceProvider = serviceProvider;			_worker = worker;			_dictionaryEntity = _worker.EntityDictionary;			_dictionaryType = worker.TypeToId;			this.MaximumSize = this.Size;			this.MinimumSize = this.Size;			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;			PopulationOfTheTablesComboBox();		}		//main logic		private void PopulationOfTheTablesComboBox()		{			foreach (var name in _dictionaryEntity.Keys)			{				cmbBx_tables.Items.Add(name);			}			cmbBx_tables.SelectedIndex = 0;		}		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)		{			var key = cmbBx_tables.SelectedItem as string;			if (_dictionaryEntity.ContainsKey(key!))			{				dgv.DataSource = _dictionaryEntity[key!];			}			HidingOfNavigationFields();		}		private void HidingOfNavigationFields()		{			foreach (DataGridViewColumn column in dgv.Columns)			{				if (column.ValueType.IsInterface || (column.ValueType.IsClass && column.ValueType != typeof(string)))				{					column.Visible = false;				}				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;			}		}		private object FindLastId(string key) => _dictionaryType[key].GetProperties()			.FirstOrDefault(p => p.Name.EndsWith("Id"))!.GetValue(_dictionaryEntity[key].LastOrDefault())!;		private object CreateInstanceWithId(string key, int nextId)		{			var type = _dictionaryType[key];			var property = type.GetProperties().FirstOrDefault(p => p.Name.EndsWith("Id"));			if (property is null) return null!;			if (property != null && property.PropertyType == typeof(int))			{				var instance = Activator.CreateInstance(type);				property.SetValue(instance, nextId);				return instance!;			}			return null!;		}

		private void UpdataTheDataGrid(string key)		{			dgv.DataSource = null;			dgv.DataSource = _dictionaryEntity[key!];			HidingOfNavigationFields();		}


		//logic of crud_buttons

		private void btn_save_Click(object sender, EventArgs e)		{			var key = cmbBx_tables.SelectedItem as string;			state_for_saving = true;
			//MessageBox.Show(_dictionaryEntity[key!].Count.ToString());

			_worker.SaveChanges();		}		private void btn_c_Click(object sender, EventArgs e)		{			var key = cmbBx_tables.SelectedItem as string;

			if (key is null) return;

			state_for_saving = false;			var nextId = FindLastId(key);

			if(nextId is null) return;
			var entity = CreateInstanceWithId(key, (int)nextId + 1);			if (entity is not null) _dictionaryEntity[key].Add(entity);

			UpdataTheDataGrid(key);		}
		private void btn_d_Click(object sender, EventArgs e)		{			var key = cmbBx_tables.SelectedItem as string;			var objects = dgv.SelectedRows;			if (key is null || !state_for_saving) 			{
				MessageBox.Show("Save shenges or choose the table");
				return;			}			state_for_saving = false;

			List<int> sortedIndexes = new();
			foreach (DataGridViewRow obj in objects) 			{				sortedIndexes.Add(obj.Index);			}			sortedIndexes.Sort();			sortedIndexes.Reverse();			foreach (var index in sortedIndexes) 
			{ 
				_dictionaryEntity[key].RemoveAt(index); 
			}

			UpdataTheDataGrid(key);		}		// logic of navigation buttons		private void btn_retrn_Click(object sender, EventArgs e)		{			var main = _serviceProvider.GetService<Main>();			main!.Show();			state_for_closing = true;			btn_save.PerformClick();			this.Close();		}		//another logic of the form		private void CRUD_db_FormClosing(object sender, FormClosingEventArgs e)		{			if (e.CloseReason == CloseReason.UserClosing && !state_for_closing)			{				var entrance = _serviceProvider.GetService<Entrance>();				entrance!.Show();			}		}	}}