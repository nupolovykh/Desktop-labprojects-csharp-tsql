using application_win_form_db.Services.Implementations;
using application_win_form_db.Services.Interfaces;

namespace application_win_form_db
{
	public partial class Entrance : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;
		private IUserIdentity _identity;

		public Entrance(IServiceProvider serviceProvider, IDbWorker worker, IUserIdentity identity)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_worker = worker;
			_identity = identity;

			txtBx_db.Text = serviceProvider.GetService<AppDbContext>()!
				.Database.GetDbConnection().Database;
		}

		private void btn_entrance_Click(object sender, EventArgs e)
		{
			if(txtBx_login.Text != "" && txtBx_login.Text != "") 
			{
				var current = _worker.Users.
					Where(u => u.Login == txtBx_login.Text && u.Password == txtBx_password.Text).FirstOrDefault()!;

				if(current != null) 
				{
					_identity.Login(current);
					var main = _serviceProvider.GetService<Main>();

					main!.Show();
					this.Hide();
				}
			}
		}
	}
}