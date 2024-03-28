using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;

namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private bool state_for_closing = false;

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

		private void PopulationOfTheTablesComboBox()
		{
			foreach (var name in _dictionaryEntity.Keys)
			{
				cmbBx_tables.Items.Add(name);
			}
			cmbBx_tables.SelectedIndex = 0;
		}

		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if (_dictionaryEntity.ContainsKey(key!))
			{
				dgv.DataSource = _dictionaryEntity[key!];
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
			//dict[key].OnCollectionChanged(new CollectionChangedEventArgs(/* your arguments */));
			//var key = cmbBx_tables.SelectedItem as string;
			//MessageBox.Show(_dictionaryEntity[key!].Count.ToString());
			_worker.SaveChanges();
		}

		private void btn_c_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;

			if(key is null) return;

			var entity = CreateInstanceWithId(key, _dictionaryEntity[key].Count + 1);
			if (entity is not null) _dictionaryEntity[key].Add(entity);

			UpdataTheDataGrid(key);
		}

		private object CreateInstanceWithId(string key, int nextId)
		{
			var type = _dictionaryType[key];
			var idName = type.GetProperties().FirstOrDefault(p => p.Name.EndsWith("Id"))?.Name;

			if (string.IsNullOrEmpty(idName)) return null!;

			var instance = Activator.CreateInstance(type);

			var property = type.GetProperty(idName);

			if(property != null && property.PropertyType == typeof(int))
			{
				property.SetValue(instance, nextId);
				return instance!;
			}
            return null!;
		}

		private void button_d_Click(object sender, EventArgs e)
		{
			var key = cmbBx_tables.SelectedItem as string;
			var index = _dictionaryEntity[key!].Count;

			if (index == 0 || key is null) return;

			_dictionaryEntity[key].RemoveAt(index - 1);

			UpdataTheDataGrid(key);
		}

		private void UpdataTheDataGrid(string key)
		{
			dgv.DataSource = null;
			dgv.DataSource = _dictionaryEntity[key!];
			HidingOfNavigationFields();
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
