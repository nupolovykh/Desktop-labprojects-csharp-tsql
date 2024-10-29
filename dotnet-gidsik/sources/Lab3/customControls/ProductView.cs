using Lab3.database;
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

namespace Lab3.customControls
{
    public partial class ProductView : UserControl
    {
        IDbWorker _db;
        public ProductView(Product product, IEnumerable<Material> materials, IDbWorker db)
        {
            InitializeComponent();
            _db = db;

            cmbox_Material.DataSource = _db.Materials;
            cmbox_Material.DisplayMember = "Name";
            cmbox_Material.ValueMember = "Id";

            tb_Id.DataBindings.Add(new Binding("Text", product, "Id"));
            tb_Name.DataBindings.Add("Text", product, "Name");
            tb_Price.DataBindings.Add("Text", product, "Price");
            cmbox_Material.DataBindings.Add("SelectedItem", product, "Material");
        }
    }
}
