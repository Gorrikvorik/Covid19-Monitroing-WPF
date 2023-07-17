using Accessibility;
using Microsoft.Xaml.Behaviors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PR22.Infrastructure.Behaviors
{
    class WindowTitleBarBehavior :  Behavior<UIElement>
    {

        private Window _Window;
        protected override void OnAttached()
        {
            _Window = AssociatedObject as Window ?? AssociatedObject.FindLogicalParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;
            
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ClickCount)
            {
                case 1:
                    Dragmove();
                    break;
                default:
                    Maximize();
                    break;  
            }
         
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            _Window = null;
        }

        private  void Dragmove()
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;

            window?.DragMove();
        }

        private void Maximize()
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
            window.WindowState = window.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => window.WindowState
            };
        }
        
    }
}
