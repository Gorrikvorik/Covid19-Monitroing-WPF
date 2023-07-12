using Microsoft.Extensions.DependencyInjection;
using PR22.Services.Interfaces;

namespace PR22.Services
{
    internal static class Registatror
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>(); // временный объект, при запросе создается новый
            services.AddTransient<IAsyncDataService,AsyncDataService>();

            return services;

        }
    }
}
