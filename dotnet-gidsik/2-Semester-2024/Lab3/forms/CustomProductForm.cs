using Lab3.customControls;
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

namespace Lab3.forms
{
    public partial class CustomProductForm : Form
    {
        private IDbWorker _db;

        public CustomProductForm(IDbWorker db, string? search = null)
        {
            InitializeComponent();

            _db = db;

            IEnumerable<Product> products;
            if (search is not null) products = _db.Products.Where(p => p.Material.Name == search);
            else products = _db.Products;

            NestingProducts(products);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _db.SaveChanges();
        }

        private void NestingProducts(IEnumerable<Product> products)
        {
            var materials = _db.Materials;

            foreach (var p in products)
            {
                flowLayoutPanel.Controls.Add(new ProductView(p, materials, _db));
            }
        }
    }
}
