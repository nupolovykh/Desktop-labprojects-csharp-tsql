using WinFormsApp.Services.Interfaces;

namespace WinFormsApp.Forms;

internal partial class ProductsDataGridForm : Form
{
	private readonly IDbWorker _db;

	public ProductsDataGridForm(IDbWorker db)
	{
		InitializeComponent();
		_db = db;
	}

	private void ProductsDataGridForm_Load(object sender, EventArgs e)
	{
		dgvProducts.DataSource = _db.Products;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_db.SaveChanges();
	}
}
