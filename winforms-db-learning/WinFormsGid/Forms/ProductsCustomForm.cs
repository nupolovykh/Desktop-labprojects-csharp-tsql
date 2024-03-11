using WinFormsApp.Controls;
using WinFormsApp.Services.Interfaces;

namespace WinFormsApp.Forms;

internal partial class ProductsCustomForm : Form
{
	private readonly IDbWorker _db;

	public ProductsCustomForm(IDbWorker db)
	{
		InitializeComponent();
		_db = db;
	}

	private void ProductsDataGridForm_Load(object sender, EventArgs e)
	{
		foreach (var item in _db.Products)
		{
			flpnlProducts.Controls.Add(new ProductView(_db, item));
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_db.SaveChanges();
	}
}
