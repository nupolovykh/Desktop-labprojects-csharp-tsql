using Lab3.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class MaterialForm : Form
    {
        private IDbWorker _db;
        public MaterialForm(IDbWorker db)
        {
            InitializeComponent();

            _db = db;
            dataGridView.DataSource = _db.Materials;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _db.SaveChanges();
        }
    }
}
