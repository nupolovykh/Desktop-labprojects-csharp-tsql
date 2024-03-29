namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private enum statesForSaving
		{
			AllReadySaved,
			YouHaveSomeUnappliedChanges
		}

		private statesForSaving state_for_saving = statesForSaving.AllReadySaved;
		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;

		private Dictionary<string, ObservableCollection<object>> _dictionaryEntity;
		private Dictionary<string, Type> _dictionaryType;

		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;
			_dictionaryEntity = _worker.EntityDictionary;
			_dictionaryType = worker.TypeToId;

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

			PopulationOfTheTablesComboBox();
		}

		//main logic

		private void PopUpSaveOrCancelChanges() => MessageBox.Show($"Save or cancel changes");

		private void PopulationOfTheTablesComboBox()
		{
			foreach (var name in _dictionaryEntity.Keys)
			{
				cmbBx_tables.Items.Add(name);
			}
			cmbBx_tables.SelectedIndex = 0;
		}

		private void PopulationOfTheColumnsComboBox()
		{
			cmbBx_columns.Items.Clear();

			foreach (DataGridViewColumn column in dgv.Columns)
			{
				if (column.Visible == false) continue;
				cmbBx_columns.Items.Add(column.Name);
			}
			cmbBx_columns.SelectedIndex = 0;
		}

		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if (_dictionaryEntity.ContainsKey(key!))
			{
				UpdataTheDataGrid(key!);
			}
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

		private object CreateInstanceWithId(string key, int nextId)
		{
			var type = _dictionaryType[key];
			var property = type.GetProperties().FirstOrDefault(p => p.Name.Equals(cmbBx_columns.Items[0]));

			if (property is null) return null!;

			if (property is not null && property.PropertyType == typeof(int))
			{
				var instance = Activator.CreateInstance(type);
				property.SetValue(instance, nextId);
				return instance!;
			}
			return null!;
		}

		private void UpdataTheDataGrid(string key)
		{
			dgv.DataSource = null;
			dgv.DataSource = _dictionaryEntity[key!];
			HidingOfNavigationFields();
			PopulationOfTheColumnsComboBox();
		}

		private void UpdataTheDataGridAfterOrderBy(List<object> list)
		{
			dgv.DataSource = null;
			dgv.DataSource = list;
			HidingOfNavigationFields();
		}

		private List<object> LogicOrderByASC(string key, string column, Type type) =>
			_dictionaryEntity[key].ToList().OrderBy(obj =>
				type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
					!.GetValue(obj, null)).ToList();

		private List<object> LogicOrderByDESC(string key, string column, Type type) =>
			_dictionaryEntity[key].ToList().OrderByDescending(obj =>
				type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
					!.GetValue(obj, null)).ToList();

		private object FindLastId(string key) => _dictionaryType[key].GetProperties()
			.FirstOrDefault(p => p.Name.Equals(cmbBx_columns.Items[0]))!.GetValue(_dictionaryEntity[key].LastOrDefault())!;

		private object FindTheObjectInAbstractObservableCollection(object obj, string column)
			=> obj.GetType().GetProperty(column)!.GetValue(obj)!;

		private List<int> SortedIndexexForDeleting(DataGridViewSelectedRowCollection objects)
		{
			List<int> sortedIndexes = new();

			foreach (DataGridViewRow obj in objects)
			{
				var index = (int)FindTheIndexOfRightCell(obj).Value;
				sortedIndexes.Add(index);
			}
			sortedIndexes.Sort((int1, int2) => int2 - int1);

			return sortedIndexes;
		}

		private DataGridViewCell FindTheIndexOfRightCell(DataGridViewRow row)
		{
			foreach (DataGridViewCell cell in row.Cells)
			{
				if (cell.OwningColumn.Name.Equals(cmbBx_columns.Items[0])) return cell;
			}
			return null!;
		}

		//logic of crud_buttons

		private void btn_save_Click(object sender, EventArgs e)
		{
			state_for_saving = statesForSaving.AllReadySaved;
			_worker.SaveChanges();
		}

		private void btn_c_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key is null) return;

			var nextId = FindLastId(key);
			if (nextId is null) return;

			var entity = CreateInstanceWithId(key, (int)nextId + 1);
			if (entity is not null) _dictionaryEntity[key].Add(entity);

			state_for_saving = statesForSaving.YouHaveSomeUnappliedChanges;
			UpdataTheDataGrid(key);
		}

		private void btn_d_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.Items[0] as string;

			var objects = dgv.SelectedRows;

			if (key is null || state_for_saving == statesForSaving.YouHaveSomeUnappliedChanges)
			{
				PopUpSaveOrCancelChanges();
				return;
			}
			List<int> sortedIndexes = SortedIndexexForDeleting(objects);

			foreach (var index in sortedIndexes)
			{
				var objForDelete = _dictionaryEntity[key].FirstOrDefault(obj => (int)FindTheObjectInAbstractObservableCollection(obj, column!) == index); //pizdec
				_dictionaryEntity[key].Remove(objForDelete!);
			}
			state_for_saving = statesForSaving.YouHaveSomeUnappliedChanges;

			UpdataTheDataGrid(key);
		}

		private void rtn_cancel_Click(object sender, EventArgs e)
		{

		}

		private void btn_sort_asc_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.SelectedItem as string;

			if (key is null || column is null) return;

			if (_dictionaryEntity[key].Count <= 1) return;

			var type = _dictionaryEntity[key].First().GetType();

			var sortedASC = LogicOrderByASC(key, column, type);

			UpdataTheDataGridAfterOrderBy(sortedASC);
		}

		private void btn_sort_desc_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.SelectedItem as string;

			if (key is null || column is null) return;

			if (_dictionaryEntity[key].Count <= 1) return;

			var type = _dictionaryEntity[key].First().GetType();

			var sortedDESC = LogicOrderByDESC(key, column, type);

			UpdataTheDataGridAfterOrderBy(sortedDESC);
		}

		// logic of navigation buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			if(state_for_saving == statesForSaving.YouHaveSomeUnappliedChanges) PopUpSaveOrCancelChanges();

			var main = _serviceProvider.GetService<Main>();
			main!.Show();
			states_for_closing_window = statesForClosingWindow.ClosingByTheReturn;

			btn_save.PerformClick();
			this.Close();
		}

		//another logic of the form

		private void CRUD_db_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && states_for_closing_window.Equals(statesForClosingWindow.ClosingByTheShutDownWindow))
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				Entrance.ReopenForm(entrance!);
			}
		}
	}
}
