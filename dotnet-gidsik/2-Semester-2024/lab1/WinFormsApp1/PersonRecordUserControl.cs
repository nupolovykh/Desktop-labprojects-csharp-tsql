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

    public partial class PersonRecordUserControl : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public int Age { get; set; }

        public PersonRecordUserControl()
        {
            InitializeComponent();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) // Check if the control is a TextBox
                {
                    ((TextBox)ctrl).ReadOnly = true; // Set the ReadOnly property to true
                    ((TextBox)ctrl).Text = "null";
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserData user = new UserData(1, "John", "Doe", "Smith", 25);

            var dialogForm = new PersonRecordEditDialog(user);
            dialogForm.ShowDialog(this);

            if(dialogForm.DialogResult == DialogResult.OK)
            {
                txtBoxId.Text = dialogForm.newUser.Id.ToString();
                txtBoxName.Text = dialogForm.newUser.FirstName;
                txtBoxLN.Text = dialogForm.newUser.LastName;
                txtBoxSN.Text = dialogForm.newUser.Surname;
                txtBoxAge.Text = dialogForm.newUser.Age.ToString();
            }
            Age = int.Parse(txtBoxAge.Text);

            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class UserData
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get;  }
        public string Surname { get; }
        public int Age { get; }

        public UserData(int id, string firstName, string lastName, string surname, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            Age = age;
        }
    }
}
