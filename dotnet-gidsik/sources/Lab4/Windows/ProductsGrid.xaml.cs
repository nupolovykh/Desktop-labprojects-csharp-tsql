using Lab4.Database;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
