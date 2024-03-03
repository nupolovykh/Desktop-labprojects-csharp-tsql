using Lab3.database;
using Lab3.Services.Implementations;
using Lab3.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lab3
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();
            services.AddTransient<Main>();
            services.AddTransient<MaterialForm>();
            services.AddTransient<ProductForm>();

            services.AddScoped<IDbWorker, DbWorker>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));

            _serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(_serviceProvider.GetService<Main>());
        }
    }
}