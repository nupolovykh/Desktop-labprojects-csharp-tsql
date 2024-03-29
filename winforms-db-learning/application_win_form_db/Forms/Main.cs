namespace application_win_form_db
{
	public partial class Main : Form
	{
		private IServiceProvider _serviceProvider;
		private IUserIdentity _identity;
		private IDbWorker _worker;

		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;

		public Main(IServiceProvider serviceProvider, IUserIdentity identity, IDbWorker worker)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_identity = identity;
			_worker = worker;

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			var current = _identity.GetUser();

			lbl_role2.Text = current.Role;
			txtBx_notes.DataBindings.Add("Text", current, "Notes");

			Hidings(current.Role!);
		}

		//main logic

		private void Hidings(string rolename)
		{
			switch (rolename)
			{
				case "Survey Operator":
					btn_anlytc.Visible = false;
					goto case "Analyst";

				case "Application Operator":
					btn_anlytc.Visible = false;
					btn_crud_db.Text = "Tables";
					break;

				case "Analyst":
					btn_crud_db.Text = "Page for surveys";
					break;

				default:
					break;
			}
		}

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

		private void txtBx_notes_TextChanged(object sender, EventArgs e)
		{
			//Interaction.InputBox("Are you sure to save changes? Yeah or No", "Confirm message", "Yeah");
			//if (input == "Yes") _worker.SaveChanges();
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
