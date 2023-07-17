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
            if (e.ClickCount > 1) return;
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;

            window?.DragMove();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            _Window = null;
        }

    }
}
