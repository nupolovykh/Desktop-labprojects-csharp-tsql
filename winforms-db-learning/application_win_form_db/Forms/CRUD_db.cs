
namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;

			dgv.DataSource = _worker.Users;
		}

		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{
			//var tableName = cmbBx_tables.SelectedItem as string;
			//dgv.DataSource = ;
		}
	}
}
