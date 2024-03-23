using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application_win_form_db
{
	public partial class Analytics : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private bool state_for_closing = false;

		public Analytics(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;
		}

		//main logic

		// logic of those buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			var main = _serviceProvider.GetService<Main>();
			main!.Show();
			state_for_closing = true;

			this.Close();
		}

		//another logic of the form

		private void Analytics_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !state_for_closing)
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				entrance!.Show();
			}
		}
	}
}
