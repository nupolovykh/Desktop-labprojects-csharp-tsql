namespace application_win_form_db
{
	public partial class Analytics : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;

		public Analytics(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;
		}

		//main logic

		// logic of navigation buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			var main = _serviceProvider.GetService<Main>();
			main!.Show();
			states_for_closing_window = statesForClosingWindow.ClosingByTheReturn;

			this.Close();
		}

		//another logic of the form

		private void Analytics_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && states_for_closing_window == statesForClosingWindow.ClosingByTheShutDownWindow)
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				Entrance.ReopenForm(entrance!);
			}
		}
	}
}
