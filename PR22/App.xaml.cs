using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PR22.Services;
using PR22.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace PR22
{
  
    public partial class App : Application
    {
        public static bool IsDesignModel { get; private set; } = true;


        private static IHost _Host;

        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignModel = false;
            var host = Host;
            base.OnStartup(e);

          await  host.StartAsync().ConfigureAwait(false);

                 
 
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;

            host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DataService>();
            services.AddSingleton<CountriesStatisticViewModel>();
        }
    }
}
