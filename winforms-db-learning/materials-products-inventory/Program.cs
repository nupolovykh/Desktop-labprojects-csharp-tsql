using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp.Data;
using WinFormsApp.Forms;
using WinFormsApp.Services.Implementations;
using WinFormsApp.Services.Interfaces;

namespace WinFormsApp;

internal static class Program
{
	private static IServiceProvider _serviceProvider = null!;

	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.

		var services = new ServiceCollection();
		services.Init();
		_serviceProvider = services.BuildServiceProvider();

		ApplicationConfiguration.Initialize();
		Application.Run(_serviceProvider.GetRequiredService<MainForm>());
	}
}

internal static class DIExtensions
{
	internal static void Init(this ServiceCollection services)
	{
		services.AddForms();
		services.AddServices();
	}
	internal static void AddForms(this ServiceCollection services)
	{
		services.AddTransient<MainForm>();
		services.AddTransient<MaterialsDataGridForm>();
		services.AddTransient<ProductsDataGridForm>();
		services.AddTransient<ProductsCustomForm>();
	}
	internal static void AddServices(this ServiceCollection services)
	{
		services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=./app.db"));

		services.AddScoped<IDbWorker, DbWorker>();
	}
}