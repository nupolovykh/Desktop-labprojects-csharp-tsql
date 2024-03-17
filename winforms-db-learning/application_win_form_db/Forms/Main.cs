
namespace application_win_form_db
{
	public partial class Main : Form
	{
		private IServiceProvider _serviceProvider;
		private IUserIdentity _identity;

		public Main(IServiceProvider serviceProvider, IUserIdentity identity)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_identity = identity;


			var current = _identity.GetUser();

			lbl_role2.Text = current.Role;
			//listBox_notes.Text = current.Notes;
			Hiding(current.Role!);
		}

		private void btn_crud_db_Click(object sender, EventArgs e)
		{
			var crud = _serviceProvider.GetService<CRUD_db>();
			crud!.ShowDialog();
		}

		private void Hiding(string rolename)
		{
			switch (rolename)
			{
				case "Survey Operator":
					btn_anlytc.Hide();
					goto case "Analyst";

				case "Application Operator":
					btn_anlytc.Hide();
					btn_crud_db.Text = "Tables";
					break;

				case "Analyst":
					btn_crud_db.Text = "Page for surveys"; 
					break;

				default:
					break;
			}
		}

		private void btn_logOut_Click(object sender, EventArgs e)
		{
			_identity.LogOut();

			var entrance = _serviceProvider.GetService<Entrance>();
			entrance!.Show();

			this.Close();
		}
	}
}
