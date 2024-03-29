﻿using Microsoft.Extensions.DependencyInjection;
using PR22.Services.Interfaces;
using PR22.Services.Students;

namespace PR22.Services
{
    internal static class Registatror
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>(); // временный объект, при запросе создается новый
            services.AddTransient<IAsyncDataService,AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();
            services.AddSingleton<StudentRepository>();
            services.AddSingleton<GroupRepository>();
            services.AddSingleton<_StudentManager>();
            services.AddSingleton<IUserDialogService, WindowsUserDialogService>();



            return services;

        }
    }
}
