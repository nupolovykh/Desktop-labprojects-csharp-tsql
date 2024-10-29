using Lab4.Services;
using System.Windows;

namespace Lab4.Windows
{
	/// <summary>
	/// Interaction logic for MaterialsGrid.xaml
	/// </summary>
	public partial class MaterialsGrid : Window
	{
		private readonly IDbWorker _worker;

		public MaterialsGrid(IDbWorker worker)
		{
			_worker = worker;
			InitializeComponent();

			dgv.ItemsSource = _worker.Materials;
		}

		private void Saving_Click(object sender, RoutedEventArgs e)
		{
			_worker.SaveChanges();
		}
	}
}
