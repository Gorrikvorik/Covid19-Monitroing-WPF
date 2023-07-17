using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PR22.Infrastructure.Behaviors
{
    internal class CloseWindow : Behavior<Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;

            var window = FindVisuialRoot(button) as System.Windows.Window;
            window?.Close();

           
        }

        private static DependencyObject FindVisuialRoot(DependencyObject obj)
        {
 
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);
                if (parent is null) return obj;
                obj = parent;
            }
            while (true);
        }
    }
}
