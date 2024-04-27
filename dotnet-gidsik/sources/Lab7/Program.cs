using Lab7.Models.Database;
using Lab7.Services.Authorization;
using Lab7.Services.DbWorker;
using Lab7.ViewModels;
using Lab7.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Lab7
{
	class Program
	{
		private static IServiceProvider _serviceProvider = null!;

		[STAThread]
		private static void Main()
		{
			var services = new ServiceCollection();
			services.Init();

			_serviceProvider = services.BuildServiceProvider();

			var app = new MyApplication(_serviceProvider);
			app.Run();
		}

	}

	public class MyApplication : Application
	{
		private readonly IServiceProvider _serviceProvider = null!;

		public MyApplication(IServiceProvider serviceProvider) 
		{
			_serviceProvider = serviceProvider;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			Window window = _serviceProvider.GetRequiredService<Login>();
			window.DataContext = _serviceProvider.GetRequiredService<LoginViewModel>();
			window.Show();

			base.OnStartup(e);
		}
	}

	public static class Config
	{
		public static void Init(this ServiceCollection services)
		{
			services.AddSingleton<Login>();
			services.AddSingleton<Regis>();

			services.AddScoped<LoginViewModel>();
			services.AddScoped<RegisViewModel>();

			services.AddScoped<IDbWorker, DbWorker>();
			services.AddSingleton<IAuthorization, Authorization>();

			services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));
		}
	}
}
