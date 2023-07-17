using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PR22.Infrastructure.Behaviors
{
    class MinimizeWindow :Behavior<Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
         ;
            if (!(AssociatedObject.FindVisualRoot() is  Window window)) return;
            //switch(window.WindowState)
            //{
            //    case WindowState.Normal:
            //        window.WindowState = WindowState.Maximized;
            //        break;
            //    case WindowState.Maximized:
            //        window.WindowState = WindowState.Normal;
            //        break;

            //}
            window.WindowState = window.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => window.WindowState
            };
        }
    }
}
