namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;
		private IUserIdentity _identity;

		private enum statesForSaving { AllReadySaved, YouHaveSomeUnappliedChanges }

		private enum statesForCancelEditting { DataBaseError, SimpleCancel }

		private enum Actions
		{
			EditElement,
			RemoveElement,
			AddElement
		}

		private statesForSaving state_for_saving = statesForSaving.AllReadySaved;
		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;
		private statesForCancelEditting states_for_cancel = statesForCancelEditting.SimpleCancel;

		private Dictionary<string, ObservableCollection<object>> _dictionaryEntity;
		private Dictionary<string, Type> _dictionaryType;

		private Dictionary<string, Dictionary<Actions, List<object>>> _booferDictionary = new();

		private List<string> _tableNames = new();

		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;
			_identity = serviceProvider.GetService<IUserIdentity>()!;
			_dictionaryEntity = _worker.EntityDictionary;
			_dictionaryType = worker.TypeToId;

			PopulationOfBoofer();

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			dgv.DataError += DataGridView_DataError;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

			Personalization();
			PopulationOfTheTablesComboBox();
		}

		//main logic

		private void PopulationOfBoofer() 
		{
			foreach (var key in _dictionaryEntity.Keys)
			{
				_booferDictionary[key] = new Dictionary<Actions, List<object>>();
				_booferDictionary[key][Actions.AddElement] = new List<object>();
				_booferDictionary[key][Actions.EditElement] = new List<object>();
				_booferDictionary[key][Actions.RemoveElement] = new List<object>();
			}
		}

		private void PopulationOfTheTablesComboBox()
		{
			foreach (var name in _tableNames)
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
			dgv.CurrentCell = null;
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

		private async Task UpdataTheDataGrid(string key)
		{
			ObservableCollection<object> source = await UpdateDataAsync(new ObservableCollection<object>(_dictionaryEntity[key]));

			dgv.DataSource = null;
			dgv.DataSource = source;

			HidingOfNavigationFields();
			PopulationOfTheColumnsComboBox();
		}

		private void UpdataTheDataGridAfterOrderBy(List<object> source)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key == null) return;

			foreach (var item in _booferDictionary[key!][Actions.AddElement]) source.Add(item);
			foreach (var item in _booferDictionary[key!][Actions.RemoveElement]) source.Remove(item);

			dgv.DataSource = null;
			dgv.DataSource = source;

			HidingOfNavigationFields();
		}

		private async Task<ObservableCollection<object>> UpdateDataAsync(ObservableCollection<object> source)
		{
			var key = cmbBx_tables.SelectedItem as string;

			await Task.Run(() =>
			{
				foreach (var item in _booferDictionary[key!][Actions.RemoveElement]) source.Remove(item);
				foreach (var item in _booferDictionary[key!][Actions.AddElement]) source.Add(item);
			});

			return source;
		}

		private async Task EditTheMainDictionary(string key)
		{
			await Task.Run(() =>
			{
				foreach (CustomCell cell in _booferDictionary[key][Actions.EditElement])
				{
					int index = cell.ItemIndex;

					string? columnName = cell.ColumnName, id = cmbBx_columns.Items[0] as string;
					object obj;

					if (states_for_cancel.Equals(statesForCancelEditting.DataBaseError)
						&& !columnName.EndsWith("Id")) continue;

					try { obj = _dictionaryEntity[key].FirstOrDefault(obj => 
						(int)FindTheObjectInAbstractObservableCollection(obj, id!) == index)!; }
					catch { continue; }

					if (obj is null) continue;

					obj.GetType().GetProperty(columnName)!.SetValue(obj, cell.PreviousValue);

					if(states_for_cancel.Equals(statesForCancelEditting.DataBaseError))
					{
						if (!TryToSaveChanges()) continue;
						else break;
					}
				}
			});
		}

		private bool TryToSaveChanges() 
		{
			try {
				_worker.SaveChanges();
				states_for_cancel = statesForCancelEditting.SimpleCancel;
				return true;
			}
			catch { return false; }
		}

		private void DiscardTheChangesFromBoofer()
		{
			foreach (var subdict in _booferDictionary.Values)
			{
				subdict[Actions.AddElement].Clear();
				subdict[Actions.RemoveElement].Clear();
				subdict[Actions.EditElement].Clear();
			}
		}

		private List<object> LogicOrderByASC(string key, string column, Type type) =>
			_dictionaryEntity[key].ToList().OrderBy(obj =>
				type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
					!.GetValue(obj, null)).ToList();

		private List<object> LogicOrderByDESC(string key, string column, Type type) =>
			_dictionaryEntity[key].ToList().OrderByDescending(obj =>
				type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
					!.GetValue(obj, null)).ToList();

		private object FindLastId(Type type, ObservableCollection<object> source) => type.GetProperties().
				FirstOrDefault(p => p.Name.Equals(cmbBx_columns.Items[0]))!.
					GetValue(source.LastOrDefault())!;

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

		private bool FindingTheSameCell(string key, string columnName, int itemIndex) => 
			(_booferDictionary[key!][Actions.EditElement].Any(obj =>
				(obj.GetType().GetProperties().FirstOrDefault(p => p.GetValue(obj)?.ToString() == columnName)
					is not null) && (obj.GetType().GetProperties().FirstOrDefault(p => p.GetValue(obj)?.ToString() == itemIndex.ToString())
						is not null)));

		//popUps for each accident

		private void PopUpSaveOrCancelChanges() => MessageBox.Show($"Save or cancel changes", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		private void PopUpErrorWithData() => MessageBox.Show("Try to input data in another format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		//logic of crud_buttons

		private async void btn_save_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key is null) return;

			try {
				await UpdateDataAsync(_dictionaryEntity[key]!);
				_worker.SaveChanges();
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message + " Some data will had disposed");
				states_for_cancel = statesForCancelEditting.DataBaseError;
				await EditTheMainDictionary(key!);
			}

			DiscardTheChangesFromBoofer();
			await UpdataTheDataGrid(key!);

			state_for_saving = statesForSaving.AllReadySaved;
		}

		private async void btn_c_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key is null) return;

			ObservableCollection<object> source = new(_dictionaryEntity[key]);

			await UpdateDataAsync(source);
			var nextId = FindLastId(_dictionaryType[key], source);

			if (nextId is null) return;

			var entity = CreateInstanceWithId(key, (int)nextId + 1);

			if (entity is not null) _booferDictionary[key][Actions.AddElement].Add(entity);

			state_for_saving = statesForSaving.YouHaveSomeUnappliedChanges;
			await UpdataTheDataGrid(key);
		}

		private async void btn_d_Click(object sender, EventArgs e)  //Warning
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

			if (sortedIndexes.Count == 0) return;

			foreach (var index in sortedIndexes)
			{
				var objForDelete = _dictionaryEntity[key].FirstOrDefault(obj =>
					(int)FindTheObjectInAbstractObservableCollection(obj, column!) == index); //Warning

				_booferDictionary[key][Actions.RemoveElement].Add(objForDelete!);
			}
			state_for_saving = statesForSaving.YouHaveSomeUnappliedChanges;

			await UpdataTheDataGrid(key);
		}

		private async void rtn_cancel_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			await EditTheMainDictionary(key!);
			DiscardTheChangesFromBoofer();
			_worker.DiscardChanges();

			state_for_saving = statesForSaving.AllReadySaved;
			await UpdataTheDataGrid(key!);
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
			if (state_for_saving == statesForSaving.YouHaveSomeUnappliedChanges)
			{
				PopUpSaveOrCancelChanges();
				return;
			}

			var main = _serviceProvider.GetService<Main>();
			main!.Show();

			states_for_closing_window = statesForClosingWindow.ClosingByTheReturn;

			btn_save.PerformClick();
			this.Close();
		}

		//another logic of the form

		private async void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if (_dictionaryEntity.ContainsKey(key!)) await UpdataTheDataGrid(key!);
		}

		private void CRUD_db_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && states_for_closing_window.Equals(statesForClosingWindow.ClosingByTheShutDownWindow))
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				Entrance.ReopenForm(entrance!);
			}
		}

		private void DataGridView_DataError(object? sender, DataGridViewDataErrorEventArgs e)
		{
			PopUpErrorWithData();
			e.ThrowException = false;
			e.Cancel = true;
		}

		private void btn_search_Click(object sender, EventArgs e)
		{
			dgv.CurrentCell = null;
			string search = txtBx_search.Text.Trim();

			foreach (DataGridViewRow row in dgv.Rows)
			{
				bool visible = false;
				foreach (DataGridViewCell cell in row.Cells)
				{
					if (cell.Value is null) continue;

					if (cell.Value.ToString()!.Trim().Contains(search))
					{
						row.Visible = true;
						visible = true;
						break;
					}
				}
				if (!visible) row.Visible = false;
			}
		}

		private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

			var itemIndex = (int)FindTheIndexOfRightCell(dgv.Rows[e.RowIndex]).Value;
			string columnName = dgv.Columns[e.ColumnIndex].Name;

			if (FindingTheSameCell(key!, columnName, itemIndex)) return;

			var customCell = new CustomCell(cell.Value, itemIndex, columnName);

			_booferDictionary[key!][Actions.EditElement].Add(customCell);

			state_for_saving = statesForSaving.YouHaveSomeUnappliedChanges;
		}

		//usefull class

		private class CustomCell
		{
			private object? _previousValue;
			private int _itemIndex;
			private string _columnName;

			public CustomCell(object Value, int itemIndex, string columnName)
			{
				_previousValue = Value;
				_itemIndex = itemIndex;
				_columnName = columnName;
			}

			public object? PreviousValue => _previousValue;// ?? DBNull.Value;
			public int ItemIndex => _itemIndex;
			public string ColumnName => _columnName;
		}
	}
}
