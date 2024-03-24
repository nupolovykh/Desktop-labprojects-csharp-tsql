using application_win_form_db.Services.Implementations;
using application_win_form_db.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

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

		//main logic

		private User Authorization(string login, string password) => _worker.Users.
			Where(u => u.Login == login && u.Password == password).FirstOrDefault()!;

		// logic of navigation buttons

		private void btn_entrance_Click(object sender, EventArgs e)
		{
			var current = Authorization(txtBx_login.Text, txtBx_password.Text);

			if (current is not null)
			{
				_identity.Login(current);

				var main = _serviceProvider.GetService<Main>();
				main!.Show();

				this.Hide();
			}

			else MessageBox.Show("Retry input the data");
		}

		//another logic of the form

		public static void ReopenForm(Entrance entr)
		{
			entr.Show();
			entr.txtBx_login.Text = "";
			entr.txtBx_password.Text = "";
		}

	}
}