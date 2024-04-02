namespace application_win_form_db
{
	public partial class Entrance : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;
		private IUserIdentity _identity;

		public IUserIdentity Identity => _identity;

		public Entrance(IServiceProvider serviceProvider, IDbWorker worker, IUserIdentity identity)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_worker = worker;
			_identity = identity;

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

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
			entr.Identity.LogOut();
			entr.txtBx_login.Text = string.Empty;
			entr.txtBx_password.Text = string.Empty;

			entr.Show();
		}

	}
}