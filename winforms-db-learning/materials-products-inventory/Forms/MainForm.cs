using Microsoft.Extensions.DependencyInjection;
using WinFormsApp.Forms;

namespace WinFormsApp;

internal partial class MainForm : Form
{
	private readonly IServiceProvider _serviceProvider;
	public MainForm(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		_serviceProvider = serviceProvider;
	}

	private void btnOpenMaterialDGForm_Click(object sender, EventArgs e)
	{
		var dialog = _serviceProvider.GetRequiredService<MaterialsDataGridForm>();
		dialog.ShowDialog();
	}

	private void btnOpenProductsDGForm_Click(object sender, EventArgs e)
	{
		var dialog = _serviceProvider.GetRequiredService<ProductsDataGridForm>();
		dialog.ShowDialog();
	}

	private void btnOpenProductsCustomForm_Click(object sender, EventArgs e)
	{

		var dialog = _serviceProvider.GetRequiredService<ProductsCustomForm>();
		dialog.ShowDialog();
	}
}
