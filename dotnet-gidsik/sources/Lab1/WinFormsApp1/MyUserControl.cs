using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MyUserControl : UserControl
    {
        [Category("Behavior")]
        [Browsable(false)]
        public string label
        {
            get => lblPsw.Text;
            set => lblPsw.Text = value;
        }

        [Category("Behavior")]
        public string password
        {
            get => tbPsw.Text;
            set => tbPsw.Text = value;
        }

        public MyUserControl()
        {
            InitializeComponent();

            tbPsw.PasswordChar = '*';
        }

        private void btnShowPsw_Click(object sender, EventArgs e)
        {
            if (tbPsw.PasswordChar == '\0')
            {
                tbPsw.PasswordChar = '*';
            }
            else
            {
                tbPsw.PasswordChar = '\0';
            }
        }
    }
}
