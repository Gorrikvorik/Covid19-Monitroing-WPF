using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PR22.Infrastructure.Commands;
using PR22.Models;
using PR22.Services;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PR22.ViewModels
{
    internal class CountriesStatisticViewModel:ViewModel

    {

        private DataService _DataSerive;

        private MainWindowViewModel MainModel { get; }



        #region Countries : Ienumerable<CountryInfo> - Статистика по странам

        private IEnumerable<CountryInfo> _Countries;

        public IEnumerable<CountryInfo> Countries
        {
            get => _Countries;
            private set => Set(ref _Countries, value);
        }

        #endregion


        #region SelectedCountry : CountryInfo - Выбранная страна

        private CountryInfo _SelectedCountry;

        public  CountryInfo SelectedCountry
        {
            get => _SelectedCountry;
            set => Set(ref _SelectedCountry, value);
        }

        #endregion
        #region Команды
        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataSerive.GetData();
        }
        #endregion

        /// <summary>
        /// Отладочный конструктор, используемый в процессе разаботки в визуальном дизайнере
        /// </summary>
        public CountriesStatisticViewModel() :this(null)
        {
            if (!App.IsDesignModel)
            {
                throw new InvalidOperationException("Вызов констурктора непредназначенного для использования в обычном режиме");
            }
            _Countries = Enumerable.Range(1, 10)
                    .Select(i => new CountryInfo
                    {
                        Name = $"Country {i}",
                        Provinces = Enumerable.Range(1, 10).Select(j => new PlaceInfo
                        {
                            Name = $"Province {i}",
                            Location = new Point(i, j),
                            Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount
                            {
                                Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
                                Count = k
                            }).ToArray()
                        }).ToArray()
                    }).ToArray();
            
        }
        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
             this.MainModel = MainModel;

            _DataSerive = new DataService();

            #region Команды
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            #endregion




          //  #region - создание точек

          //  var tmp = new PlotModel { Title = "Статистика" };
          //  tmp.Axes.Add(new LinearAxis
          //  {
          //      Position = AxisPosition.Left,
          //      Title ="Число",
          //      MajorGridlineStyle = LineStyle.Solid,
          //      MinorGridlineStyle = LineStyle.Dash,
                
          //  });
          //  tmp.Axes.Add(new DateTimeAxis
          //  {
          //      Position = AxisPosition.Bottom,
          //      Title = "Дата",
          //      MajorGridlineStyle = LineStyle.Solid,
          //      MinorGridlineStyle = LineStyle.Dash
          //  });
          ////  RefreshDataCommand.Execute(this);
          //   foreach(var item in Countries )
          //  {
          //      tmp.Series.Add(new LineSeries
          //      {
          //          StrokeThickness = 2,
          //          Color = OxyColors.Red,
          //          ItemsSource = item?.Counts,
          //          DataFieldX = "Date",
          //          DataFieldY = "Count"
          //      });
          //  }
            
          //      var series1 = new LineSeries
          //  {
          //      StrokeThickness = 2,
          //      Color = OxyColors.Red,
          //      ItemsSource = SelectedCountry?.Counts,
          //      DataFieldX = "Date",
          //      DataFieldY = "Count"




          //  };
          //  //var series1 = new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)");
          
          //  tmp.Series.Add(series1);
 
 

          //  Model = tmp;


          //  #endregion
        }
        public PlotModel Model { get;  private set; }


    }
}
