using Lab3.database;
using Lab3.forms;
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

namespace Lab3.customControls
{
    public partial class MaterialView : UserControl
    {
        private IDbWorker _db;
        public MaterialView(Material material, IDbWorker db)
        {
            InitializeComponent();
            _db = db;

            tb_Id.Text = material.Id.ToString();
            tb_Name.Text = material.Name.ToString();

            tb_Id.DataBindings.Add(new Binding("Text", material, "Id"));
            tb_Name.DataBindings.Add(new Binding("Text", material, "Name"));
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            CustomProductForm customMaterialForm = new CustomProductForm(_db, tb_Name.Text);
            customMaterialForm.ShowDialog();
        }
    }
}
