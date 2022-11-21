using PR22.Infrastructure.Commands;
using PR22.Models;
using PR22.Services;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PR22.ViewModels
{
    internal class CountriesStatisticViewModel:ViewModel

    {

        private DataService _DataSerive;

        private MainWindowViewModel MainModel { get;}



        #region Countries : Ienumerable<CountryInfo> - Статистика по странам

        private IEnumerable<CountryInfo> _Countries;

        public IEnumerable<CountryInfo> Countries
        {
            get => _Countries;
            private set => Set(ref _Countries, value);
        }

        #endregion


        #region Команды
        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataSerive.GetData();
        }
        #endregion

        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
             this.MainModel = MainModel;

            _DataSerive = new DataService();

            #region Команды
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion
        }
    }
}
