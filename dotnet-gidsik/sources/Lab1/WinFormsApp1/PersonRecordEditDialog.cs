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

    public partial class PersonRecordEditDialog : Form
    {

        //public String TextBoxValue // retrieving a value from
        //{
        //    get { return this.txtBoxEditId.Text; }
        //}

        public UserData newUser;

        public PersonRecordEditDialog(UserData currentUser)
        {
            InitializeComponent();

            txtBoxEditId.Text = currentUser.Id.ToString();
            txtBoxEditName.Text = currentUser.FirstName;
            txtBoxEditLN.Text = currentUser.LastName;
            txtBoxEditSN.Text = currentUser.Surname;
            txtBoxEditAge.Text = currentUser.Age.ToString();

        }

        private void btnSaving_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            newUser = new UserData(int.Parse(txtBoxEditId.Text), txtBoxEditName.Text,
                txtBoxEditLN.Text, txtBoxEditSN.Text, int.Parse(txtBoxEditAge.Text));

            this.Close();
        }
    }
}
