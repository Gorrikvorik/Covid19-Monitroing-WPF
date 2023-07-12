using System;
using Microsoft.Extensions.DependencyInjection;
using PR22.ViewModels;

namespace PR22.ViewModels
{
    internal  static class Registatror
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();// объект живет все время приложения
            services.AddSingleton<CountriesStatisticViewModel>();
            return services;
        }
    }
}
