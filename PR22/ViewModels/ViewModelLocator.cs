﻿using Microsoft.Extensions.DependencyInjection;

namespace PR22.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
