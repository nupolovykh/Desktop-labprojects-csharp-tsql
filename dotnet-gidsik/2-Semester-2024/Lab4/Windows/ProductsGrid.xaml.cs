using Lab4.Services;
using System.Windows;

namespace Lab4.Windows
{
	/// <summary>
	/// Interaction logic for ProductGrid.xaml
	/// </summary>
	public partial class ProductsGrid : Window
	{
		private readonly IDbWorker _worker;

		public ProductsGrid(IDbWorker worker)
		{
			_worker = worker;
			InitializeComponent();

			dgv.ItemsSource = _worker.Products;
		}

		private void Saving_Click(object sender, RoutedEventArgs e)
		{
			_worker.SaveChanges();
		}
	}
}
