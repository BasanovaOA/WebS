using Microsoft.Extensions.DependencyInjection;
using FreeMedHelp.ApplicationServices.GetMedPointListUseCase;
using FreeMedHelp.ApplicationServices.Ports.Cache;
using FreeMedHelp.ApplicationServices.Repositories;
using FreeMedHelp.DesktopClient.InfrastructureServices.ViewModels;
using FreeMedHelp.DomainObjects;
using FreeMedHelp.DomainObjects.Ports;
using FreeMedHelp.InfrastructureServices.Cache;
using FreeMedHelp.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FreeMedHelp.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<MedPoint>, DomainObjectsMemoryCache<MedPoint>>();
            services.AddSingleton<NetworkMedPointRepository>(
                x => new NetworkMedPointRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<MedPoint>>())
            );
            services.AddSingleton<CachedReadOnlyMedPointRepository>(
                x => new CachedReadOnlyMedPointRepository(
                    x.GetRequiredService<NetworkMedPointRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<MedPoint>>()
                )
            );
            services.AddSingleton<IReadOnlyMedPointRepository>(x => x.GetRequiredService<CachedReadOnlyMedPointRepository>());
            services.AddSingleton<IGetMedPointListUseCase, GetMedPointListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
