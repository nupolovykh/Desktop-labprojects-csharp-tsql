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

namespace Lab3
{
    public partial class ProductForm : Form
    {
        private IDbWorker _db;

        public ProductForm(IDbWorker dbWorker)
        {
            InitializeComponent();

            _db = dbWorker;
            dataGridView.DataSource = _db.Products;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _db.SaveChanges();
        }
    }
}
