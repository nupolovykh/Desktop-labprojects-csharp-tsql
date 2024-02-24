using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Lab2
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainForm>();
            services.AddTransient<LoginDialog>();
            services.AddTransient<RegisterDialog>();

            services.AddScoped<IDbWorker, ListDbWorker>();

            _serviceProvider = services.BuildServiceProvider();

            //services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));

            // To customize application configuration such as set high DPI settings or default font,

            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(_serviceProvider.GetService<MainForm>());
        }
    }
}