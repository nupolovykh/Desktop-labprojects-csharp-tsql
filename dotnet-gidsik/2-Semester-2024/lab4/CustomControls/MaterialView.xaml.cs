using Lab4.Database;
using Lab4.Services;
using Lab4.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Lab4.CustomControls
{
	/// <summary>
	/// Interaction logic for MaterialView.xaml
	/// </summary>
	public partial class MaterialView : UserControl
	{
		private readonly IDbWorker _worker;
		private Material _material;

		public MaterialView(Material material, IDbWorker worker)
		{
			InitializeComponent();
			_worker = worker;
			_material = material;

			this.DataContext = _material;
		}

		private void Link_Product(object sender, RoutedEventArgs e)
		{
			ProductsCustom productForm = new ProductsCustom(_worker, _material.Name);
			productForm.ShowDialog();
		}
	}
}
