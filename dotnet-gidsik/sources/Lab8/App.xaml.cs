using Lab8.Services;
using Lab8.ViewModels;
using Lab8.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider = null!;

        public App()
        {
            var services = new ServiceCollection();

            services.Init();
            services.AddSetting();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<IMVVMNavigationService>().NavigateTo<LoginViewModel>();
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

    public static class Config
    {
        public static void Init(this ServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();

            services.AddTransient<MainWindow>(
                (provider) => new MainWindow(provider.GetRequiredService<MainViewModel>())
            );
            services.AddTransient<LoginView>();

            services.AddSingleton<IMVVMNavigationService, MVVMNavigationService>();
        }

        public static void AddSetting(this ServiceCollection services)
        {
            var build = new ConfigurationBuilder();

            build.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = build.Build();
            services.AddSingleton<IConfiguration>(config);
        }
    }

}
