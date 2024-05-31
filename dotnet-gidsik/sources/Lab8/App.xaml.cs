using Lab8.Services.Implementations;
using Lab8.Services.Interfaces;
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
            services.AddHttpClient();

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
            services.AddTransient<ExplorerViewModel>();

            services.AddTransient<MainWindow>(
                (provider) => new MainWindow(provider.GetRequiredService<MainViewModel>())
            );
            services.AddTransient<LoginView>();
            services.AddTransient<ExplorerView>();

            services.AddSingleton<IMVVMNavigationService, MVVMNavigationService>();
            services.AddSingleton<IDropBoxReferModule, DropBoxReferModule>();
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
