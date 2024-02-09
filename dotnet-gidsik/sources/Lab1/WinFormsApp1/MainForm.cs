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
    public partial class MainForm : Form
    {
        private List<PersonRecordUserControl> list = new List<PersonRecordUserControl>();

        [Category("Counter")]
        public int _AmountOfEntries
        {
            get => int.Parse(AmountOfEntries.Text);
            set => AmountOfEntries.Text = value.ToString();
        }

        public MainForm()
        {
            InitializeComponent();
            dataStorage.AutoScroll = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonRecordUserControl newControl = new PersonRecordUserControl();
            newControl.EditClicked += Edit_Event!;
            newControl.DeleteClicked += Subtract_Event!;

            dataStorage.Controls.Add(newControl);
            list.Add(newControl);

            _AmountOfEntries++;
            //Recalculate();
        }

        private void Edit_Event(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Subtract_Event(object sender, EventArgs e)
        {
            _AmountOfEntries--;
            Recalculate();
        }


        private void Recalculate()
        {
            int sum = 0;
            foreach (var userControl in list)
            {
                if(userControl.Age != null)
                {
                    sum += userControl.Age;
                }
            }
            SumOfAges.Text = sum.ToString();
        }
    }
}
