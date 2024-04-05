using Lab4.Database;
using Lab4.Services;
using System.ComponentModel;
using System.Windows.Controls;

namespace Lab4.CustomControls
{
	/// <summary>
	/// Interaction logic for ProductView.xaml
	/// </summary>
	public partial class ProductView : UserControl
	{
		private readonly IDbWorker _worker;
		private Product _product;

		public ProductView(Product product, IDbWorker worker)
		{
			InitializeComponent();
			_product = product;
			_worker = worker;

			this.DataContext = _product;
			cmbMaterialId.ItemsSource = _worker.Materials;
		}

	}
}
