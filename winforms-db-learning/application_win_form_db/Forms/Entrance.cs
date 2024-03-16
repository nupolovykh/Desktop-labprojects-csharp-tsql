using application_win_form_db.Services.Implementations;
using application_win_form_db.Services.Interfaces;

namespace application_win_form_db
{
	public partial class Entrance : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		public Entrance(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_worker = worker;

			txtBx_db.Text = serviceProvider.GetService<AppDbContext>()!.Database.GetDbConnection().Database;
		}

		private void btn_entrance_Click(object sender, EventArgs e)
		{
			if(txtBx_login.Text != "" && txtBx_login.Text != "") {

				var current = _worker.Users.Where(u => u.Login == txtBx_login.Text && u.Password == txtBx_password.Text).FirstOrDefault()!;

				if(current != null) {
					var main = _serviceProvider.GetService<Main>();
					main!.ShowDialog();
				}
			}
		}
	}
}