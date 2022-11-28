using PR22.Services;
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

            var service_test = new DataService();

            var brush = new SolidColorBrush(Colors.Wheat);
            brush.Freeze();
            brush.Clone();
 

 
        }
    }
}
