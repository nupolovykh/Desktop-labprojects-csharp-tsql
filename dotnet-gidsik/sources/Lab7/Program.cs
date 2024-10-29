using Lab7.Models.Database;
using Lab7.Services.Authorization;
using Lab7.Services.DbWorker;
using Lab7.Services.ViewManager;
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
	class Program //just for second case
	{
		private static IServiceProvider _serviceProvider = null!;

		[STAThread]
		private static void Main2()
		{
			var services = new ServiceCollection();
			services.Init();

			_serviceProvider = services.BuildServiceProvider();

			var app = new MyApplication(_serviceProvider, _serviceProvider.GetRequiredService<IViewsManager>());
			app.Run();
		}

	}

	public class MyApplication : Application
	{
		private readonly IServiceProvider _serviceProvider = null!;
		private readonly IViewsManager _manager = null!;

		public MyApplication(IServiceProvider serviceProvider, IViewsManager manager)
		{
			_serviceProvider = serviceProvider;
			_manager = manager;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var context = _serviceProvider.GetRequiredService<LoginViewModel>();
			_manager.Open<Login>(context);

			base.OnStartup(e);
		}
	}

	public static class Config
	{
		public static void Init(this ServiceCollection services)
		{
			services.AddTransient<Login>();
			services.AddTransient<Regis>();
			services.AddTransient<UserInfoView>();
			services.AddTransient<UsersListView>();

			services.AddTransient<LoginViewModel>();
			services.AddTransient<RegisViewModel>();
			services.AddTransient<UserInfoViewModel>();
			services.AddTransient<UsersListViewModel>();

			services.AddScoped<IDbWorker, DbWorker>();
			services.AddSingleton<IAuthorization, Authorization>();
			services.AddSingleton<IViewsManager, ViewsManager>();

			services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));
		}
	}
}
