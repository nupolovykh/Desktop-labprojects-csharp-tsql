using Lab4.CustomControls;
using Lab4.Database;
using Lab4.Services;
using System.Windows;

namespace Lab4.Windows
{
	/// <summary>
	/// Interaction logic for ProductsCustom.xaml
	/// </summary>
	public partial class ProductsCustom : Window
	{
		private readonly IDbWorker _worker;

		public ProductsCustom(IDbWorker worker, string? material = null)
		{
			_worker = worker;
			InitializeComponent();

			IEnumerable<Product> products;

			if (material is not null) products = _worker.Products.Where(p => p.Material!.Name == material);
			else products = _worker.Products;

			PopulationOfStackPanel(products);
		}

		private void PopulationOfStackPanel(IEnumerable<Product> products)
		{
            foreach (var product in products)
            {
				pane.Children.Add(new ProductView(product, _worker));
			}
        }

		private void Saving_Click(object sender, RoutedEventArgs e)
		{
			_worker.SaveChanges();
		}
	}
}
