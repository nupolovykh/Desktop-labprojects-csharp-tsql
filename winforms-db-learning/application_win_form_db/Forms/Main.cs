
namespace application_win_form_db
{
    public partial class Main : Form
    {
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		public Main(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_worker = worker;

			

		}
	}
}
