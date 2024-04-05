using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IDbWorker _worker;
		private readonly IUserIdentity _identity;

		private enum StatesForSaving { AllReadySaved, YouHaveSomeUnappliedChanges }

		private enum StatesForCancelEditting { DataBaseError, SimpleCancel }

		private enum Actions
		{
			EditElement,
			RemoveElement,
			AddElement
		}

		private StatesForSaving state_for_saving = StatesForSaving.AllReadySaved;
		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;
		private StatesForCancelEditting states_for_cancel = StatesForCancelEditting.SimpleCancel;

		private readonly Dictionary<string, ObservableCollection<object>> _dictionaryEntity;
		private readonly Dictionary<string, Type> _dictionaryType;

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

		private async Task UpdataTheDataGrid(string? key = null, List<object>? list = null)
		{
			ObservableCollection<object> source = null!;

			if (list is null && key is not null) source = await UpdateDataAsync<ObservableCollection<object>, object>
				(new ObservableCollection<object>(_dictionaryEntity[key]));

			dgv.DataSource = null;
			dgv.DataSource = source is null ? list : source;

			HidingOfNavigationFields();
			PopulationOfTheColumnsComboBox();
		}

		private async Task<TCollection> UpdateDataAsync<TCollection, TObject>(TCollection source) where TCollection : ICollection<TObject>
		{
			var key = cmbBx_tables.SelectedItem as string;

			await Task.Run(() =>
			{
				foreach (var item in _booferDictionary[key!][Actions.RemoveElement]) source.Remove((TObject)item);
				foreach (var item in _booferDictionary[key!][Actions.AddElement]) source.Add((TObject)item);
			});

			return source;
		}

		private async Task EditTheMainDictionary(string key)
		{
			await Task.Run(() =>
			{
				foreach (CustomCell cell in _booferDictionary[key][Actions.EditElement].Cast<CustomCell>())
				{
					int index = cell.ItemIndex;

					string? columnName = cell.ColumnName, id = cmbBx_columns.Items[0] as string;
					object obj;

					if (states_for_cancel.Equals(StatesForCancelEditting.DataBaseError)
						&& !columnName.EndsWith("Id")) continue;

					try { obj = _dictionaryEntity[key].FirstOrDefault(obj => 
						(int)FindTheObjectInAbstractObservableCollection(obj, id!) == index)!; }
					catch { continue; }

					if (obj is null) continue;

					obj.GetType().GetProperty(columnName)!.SetValue(obj, cell.PreviousValue);

					if(states_for_cancel.Equals(StatesForCancelEditting.DataBaseError))
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
				states_for_cancel = StatesForCancelEditting.SimpleCancel;
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

		private static List<object> LogicOrderByASC(List<object> list, string column, Type type) =>
			list.OrderBy(obj => type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
				!.GetValue(obj, null)).ToList();

		private static List<object> LogicOrderByDESC(List<object> list, string column, Type type) =>
			list.OrderByDescending(obj => type.GetProperties().FirstOrDefault(p => p.Name.Equals(column))
				!.GetValue(obj, null)).ToList();

		private object FindLastId(Type type, ObservableCollection<object> source) => type.GetProperties().
				FirstOrDefault(p => p.Name.Equals(cmbBx_columns.Items[0]))!.
					GetValue(source.LastOrDefault())!;

		private static object FindTheObjectInAbstractObservableCollection(object obj, string column)
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

		//popUps for each accident

		private static void PopUpSaveOrCancelChanges() => MessageBox.Show($"Save or cancel changes", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		private static void PopUpErrorWithData() => MessageBox.Show("Try to input data in another format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		//logic of crud_buttons

		private async void btn_save_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key is null) return;

			try {
				await UpdateDataAsync<ObservableCollection<object>, object>(_dictionaryEntity[key]!);
				_worker.SaveChanges();
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message + " Some data will had disposed");
				states_for_cancel = StatesForCancelEditting.DataBaseError;
				await EditTheMainDictionary(key!);
			}

			DiscardTheChangesFromBoofer();

			if (!states_for_closing_window.Equals(statesForClosingWindow.ClosingByTheReturn))
			{
				await UpdataTheDataGrid(key!);
			}

			state_for_saving = StatesForSaving.AllReadySaved;
		}

		private async void btn_c_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			if (key is null) return;

			ObservableCollection<object> source = new(_dictionaryEntity[key]);

			await UpdateDataAsync<ObservableCollection<object>, object>(source);
			var nextId = FindLastId(_dictionaryType[key], source);

			if (nextId is null) return;

			var entity = CreateInstanceWithId(key, (int)nextId + 1);

			if (entity is not null) _booferDictionary[key][Actions.AddElement].Add(entity);

			state_for_saving = StatesForSaving.YouHaveSomeUnappliedChanges;
			await UpdataTheDataGrid(key);
		}

		private async void btn_d_Click(object sender, EventArgs e)  //Warning
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.Items[0] as string;

			var objects = dgv.SelectedRows;

			if (key is null || state_for_saving == StatesForSaving.YouHaveSomeUnappliedChanges || column is null)
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
			state_for_saving = StatesForSaving.YouHaveSomeUnappliedChanges;

			await UpdataTheDataGrid(key);
		}

		private async void rtn_cancel_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if (key is null) return;

			await EditTheMainDictionary(key!);
			DiscardTheChangesFromBoofer();
			_worker.DiscardChanges();

			state_for_saving = StatesForSaving.AllReadySaved;
			await UpdataTheDataGrid(key!);
		}

		private async void btn_sort_asc_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.SelectedItem as string;

			if (key is null || column is null) return;

			if (_dictionaryEntity[key].Count <= 1) return;

			var type = _dictionaryEntity[key].First().GetType();

			List<object> allEntries = await UpdateDataAsync<List<object>, object>(new List<object>(_dictionaryEntity[key]));
			var sortedASC = LogicOrderByASC(allEntries, column, type);

			await UpdataTheDataGrid(null, sortedASC);
		}

		private async void btn_sort_desc_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var column = cmbBx_columns.SelectedItem as string;

			if (key is null || column is null) return;

			if (_dictionaryEntity[key].Count <= 1) return;

			var type = _dictionaryEntity[key].First().GetType();

			List<object> allEntries = await UpdateDataAsync<List<object>, object>(new List<object>(_dictionaryEntity[key]));
			var sortedDESC = LogicOrderByDESC(allEntries, column, type);

			await UpdataTheDataGrid(null, sortedDESC);
		}

		// logic of navigation buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			if (state_for_saving == StatesForSaving.YouHaveSomeUnappliedChanges)
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

			state_for_saving = StatesForSaving.YouHaveSomeUnappliedChanges;
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
