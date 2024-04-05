using Lab4.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private readonly IServiceProvider _serviceProvider;

		public MainWindow(IServiceProvider serviceProvider)
        {
			_serviceProvider = serviceProvider;
			InitializeComponent();
		}

		private void ProductsGrid_Click(object sender, RoutedEventArgs e)
		{
			var productGrid = _serviceProvider.GetService<ProductsGrid>();
			productGrid!.ShowDialog();
		}

		private void MaterialsGrid_Click(object sender, RoutedEventArgs e)
		{
			var productGrid = _serviceProvider.GetService<MaterialsGrid>();
			productGrid!.ShowDialog();
		}

		private void ProductsCustom_Click(object sender, RoutedEventArgs e)
		{
			var productGrid = _serviceProvider.GetService<ProductsCustom>();
			productGrid!.ShowDialog();
		}

		private void MaterialsCustom_Click(object sender, RoutedEventArgs e)
		{
			var productGrid = _serviceProvider.GetService<MaterialsCustom>();
			productGrid!.ShowDialog();
		}

		private void FirstWay_Click(object sender, RoutedEventArgs e)
		{
			//var productGrid = _serviceProvider.GetService<ProductsGrid>();
			//productGrid!.ShowDialog();
		}

		private void SecondWay_Click(object sender, RoutedEventArgs e)
		{
			//var productGrid = _serviceProvider.GetService<ProductsGrid>();
			//productGrid!.ShowDialog();
		}
	}
}