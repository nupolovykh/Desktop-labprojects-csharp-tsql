using Lab4.CustomControls;
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
	/// Interaction logic for MaterialsCustom.xaml
	/// </summary>
	public partial class MaterialsCustom : Window
	{
		private readonly IDbWorker _worker;

		public MaterialsCustom(IDbWorker worker)
		{
			_worker = worker;
			InitializeComponent();

			PopulationOfStackPanel();
		}

		private void PopulationOfStackPanel()
		{
			foreach (var material in _worker.Materials)
			{
				pane.Children.Add(new MaterialView(material, _worker));
			}
		}

		private void Saving_Click(object sender, RoutedEventArgs e)
		{
			_worker.SaveChanges();
		}
	}
}
