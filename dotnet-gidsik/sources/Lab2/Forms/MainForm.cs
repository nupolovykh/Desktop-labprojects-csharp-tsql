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
using static System.Windows.Forms.DataFormats;

namespace Lab2
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void entc_Click(object sender, EventArgs e)
        {
            LoginDialog _LoginDialog = _serviceProvider.GetService<LoginDialog>()!;

            _LoginDialog.ShowDialog();

            if(_LoginDialog.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Успешно");
            }
            else if (_LoginDialog.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Неуспешно");
            }
        }

        private void rgst_Click(object sender, EventArgs e)
        {
            RegisterDialog _RigisterDialog = _serviceProvider.GetService<RegisterDialog>()!;
            _RigisterDialog.ShowDialog();

            if (_RigisterDialog.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Успешно");
            }
            else if (_RigisterDialog.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Неуспешно");
            }
        }
    }
}
