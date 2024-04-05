using Lab4.Database;
using Lab4.Services;
using System.Windows;

namespace Lab4.Windows
{
	/// <summary>
	/// Interaction logic for OneGrid.xaml
	/// </summary>
	public partial class OneGrid : Window
	{
		public OneGrid(IEnumerable<dynamic> values)
		{
			InitializeComponent();

			if (values?.Any() ?? false)
			{
				var type = values.FirstOrDefault()?.GetType();
				if (type == typeof(Product)) dgv.ItemsSource = values as IEnumerable<Product>;
				else if(type == typeof(Material)) dgv.ItemsSource = values as IEnumerable<Material>;
			}
		}
	}
}
