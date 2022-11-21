using PR22.Services;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.ViewModels
{
    internal class CountriesStatisticViewModel:ViewModel

    {

        private DataService _DataSerive;

        private MainWindowViewModel MainModel { get;}

        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
             MainModel = MainModel;

            _DataSerive = new DataService();
        }
    }
}
