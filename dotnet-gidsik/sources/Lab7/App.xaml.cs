using Lab7.Services.ViewManager;
using Lab7.ViewModels;
using Lab7.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
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

namespace Lab7
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static IServiceProvider _serviceProvider = null!;
		private readonly IViewsManager _manager = null!;

		public App()
		{
			var services = new ServiceCollection();
			services.Init();

			_serviceProvider = services.BuildServiceProvider();
			_manager = _serviceProvider.GetRequiredService<IViewsManager>();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var context = _serviceProvider.GetRequiredService<LoginViewModel>();
			_manager.Open<Login>(context);

			base.OnStartup(e);
		}
	}
}
