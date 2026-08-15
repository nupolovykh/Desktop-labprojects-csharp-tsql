using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class LoginDialog : Form
    {
        private readonly IDbWorker _worker;

        public LoginDialog(IDbWorker Worker)
        {
            InitializeComponent();
            _worker = Worker;
        }

        private void apl_Click(object sender, EventArgs e)
        {
            string password = txtBxPswd.Text, login = txtBxLg.Text;
            if (_worker.Entrance(login, password))
            {
                this.DialogResult = DialogResult.OK;
            }
            else this.DialogResult = DialogResult.Cancel;
        }
    }
}
