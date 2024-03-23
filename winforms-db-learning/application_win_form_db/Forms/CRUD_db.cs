
namespace application_win_form_db
{
	public partial class CRUD_db : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private bool state_for_closing = false;

		public CRUD_db(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;

			dgv.DataSource = _worker.Users;

		}

		//main logic

		private void cmbBx_tables_SelectedValueChanged(object sender, EventArgs e)
		{


			//var tableName = cmbBx_tables.SelectedItem as string;
			//dgv.DataSource = ;
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			
		}

		// logic of those buttons

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
