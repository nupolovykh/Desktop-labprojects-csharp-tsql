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
    public partial class RegisterDialog : Form
    {
        private readonly IDbWorker _worker;

        public RegisterDialog(IDbWorker worker)
        {
            InitializeComponent();
            _worker = worker;
        }

        private void apl_Click(object sender, EventArgs e)
        {
            string login = txtBxLg.Text, password = txtBxPswd.Text, repeat_password = txtBxRPswd.Text;

            if (!_worker.Validation(login))
            {

                if (password == repeat_password)
                {
                    _worker.Registration(login, password);
                    _worker.Entrance(login, password);

                    this.DialogResult = DialogResult.OK;
                }
                else this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
