using PR22.Services;
using System.Linq;
using System.Windows;

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


            var countries = service_test.
                GetData().
                ToArray();
        }
    }
}
