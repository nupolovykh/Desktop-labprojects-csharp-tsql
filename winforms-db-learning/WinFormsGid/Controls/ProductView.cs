using WinFormsApp.Data.Entities;
using WinFormsApp.Services.Interfaces;

namespace WinFormsApp.Controls;

internal partial class ProductView : UserControl
{
	private readonly IDbWorker _dbWorker;
	private readonly Product _product;
	public ProductView(IDbWorker dbWorker, Product product)
	{
		InitializeComponent();
		_dbWorker = dbWorker;
		_product = product;

		cbMaterial.DataSource = _dbWorker.Materials;
		cbMaterial.DisplayMember = "Name";
		cbMaterial.ValueMember = "Id";

		tbId.DataBindings.Add(new Binding("Text", _product, "Id"));
		tbName.DataBindings.Add("Text", _product, "Name");
		tbPrice.DataBindings.Add("Text", _product, "Price");
		cbMaterial.DataBindings.Add("SelectedItem", _product, "Material");
	}
}
