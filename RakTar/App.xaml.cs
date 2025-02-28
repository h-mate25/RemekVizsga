using Microsoft.Extensions.DependencyInjection;
using Model;
using System.Configuration;
using System.Data;
using System.Windows;
using Model.Implemantations;
using Microsoft.EntityFrameworkCore;

namespace RakTar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WarehouseDbContext>(options =>
               options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RakKezelo_Database"));

            services.AddSingleton<ProcessManagerInterface, ProcessDatabaseManager>(); // A megfelelő implementációval
            services.AddSingleton<MainWindow>(); // MainWindow regisztrálása
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}

