namespace application_win_form_db
{
	public partial class Main : Form
	{
		private IServiceProvider _serviceProvider;
		private IUserIdentity _identity;
		private IDbWorker _worker;

		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;

		public Main(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;
			_identity = _serviceProvider.GetService<IUserIdentity>()!;

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			lbl_role2.Text = _identity.GetRole();
			txtBx_notes.DataBindings.Add("Text", _identity.GetUser(), "Notes");
			Personalization();
		}

		//main logic

		// logic of navigation buttons

		private void btn_logOut_Click(object sender, EventArgs e)
		{
			_identity.LogOut();

			this.Close();
		}

		private void btn_crud_db_Click(object sender, EventArgs e)
		{
			var crud = _serviceProvider.GetService<CRUD_db>();
			crud!.Show();
			states_for_closing_window = statesForClosingWindow.PassingToAnotherPage;

			this.Close();
		}

		private void btn_anlytc_Click(object sender, EventArgs e)
		{
			var anlt = _serviceProvider.GetService<Analytics>();
			anlt!.Show();
			states_for_closing_window = statesForClosingWindow.PassingToAnotherPage;

			this.Close();
		}

		//another logic of the form

		private void btn_save_Click(object sender, EventArgs e)
		{
			_worker.SaveChanges();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && states_for_closing_window == statesForClosingWindow.ClosingByTheShutDownWindow)
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				Entrance.ReopenForm(entrance!);
			}
		}
	}
}
