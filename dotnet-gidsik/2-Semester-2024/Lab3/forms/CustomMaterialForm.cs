using Lab3.customControls;
using Lab3.database;
using Lab3.Services.Interface;
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

namespace Lab3.forms
{
    public partial class CustomMaterialForm : Form
    {
        private IDbWorker _db;
        public CustomMaterialForm(IDbWorker db)
        {
            InitializeComponent();

            _db = db;
            NestingMaterials();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _db.SaveChanges();
        }

        private void NestingMaterials()
        {
            var materials = _db.Materials;
            foreach (var m in materials)
            {
                flowLayoutPanel.Controls.Add(new MaterialView(m, _db));
            }
        }
    }
}
