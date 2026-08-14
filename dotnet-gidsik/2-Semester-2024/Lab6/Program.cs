using Lab6.Models;
using Lab6.ViewModels;
using Lab6.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6
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
            PeopleView view = _serviceProvider.GetService<PeopleView>()!;

            //view.DataContext = new PeopleViewModelSimple();
            view.DataContext = new PeopleViewModelMVVM();

            view.Show();
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
            services.AddTransient<PeopleView>();

            //services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));

        }
    }
}
