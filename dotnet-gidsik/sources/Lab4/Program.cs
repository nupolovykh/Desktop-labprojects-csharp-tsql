using Lab4.Database;
using Lab4.Services;
using Lab4.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Lab4
{
    class MyApplication : Application
    {
		private readonly IServiceProvider _serviceProvider;

		public MyApplication(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            this.Startup += MyOnStartup;
        }

        protected void MyOnStartup(object sender, StartupEventArgs e)
        {
            MainWindow main = _serviceProvider.GetService<MainWindow>()!;
			main.Show();
        }
    }

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

    public static class Config 
    {
		public static void Init(this ServiceCollection services)
		{
			services.AddTransient<MainWindow>();
			services.AddTransient<ProductsGrid>();
			services.AddTransient<MaterialsGrid>();
			services.AddTransient<ProductsCustom>();
			services.AddTransient<MaterialsCustom>();
			services.AddTransient<OneGrid>();

			services.AddScoped<IDbWorker, DbWorker>();

			services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));

		}
	}
}
