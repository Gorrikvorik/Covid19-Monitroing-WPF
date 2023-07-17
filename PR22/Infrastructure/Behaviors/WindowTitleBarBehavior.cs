using Microsoft.Xaml.Behaviors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR22.Infrastructure.Behaviors
{
    class WindowTitleBarBehavior :  Behavior<UIElement>
    {

        private Window _Window;
        protected override void OnAttached()
        {
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

    }
}
