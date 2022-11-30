using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PR22.Services;
using PR22.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace PR22
{
  
    public partial class App : Application
    {
        public static bool IsDesignModel { get; private set; } = true;

        

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignModel = false;
            base.OnStartup(e);
                 
 
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DataService>();
            services.AddSingleton<CountriesStatisticViewModel>();
        }
    }
}
