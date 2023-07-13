using Microsoft.Extensions.DependencyInjection;
using OxyPlot;
using OxyPlot.Series;
using PR22.Infrastructure.Commands;
using PR22.Infrastructure.Commands.Base;
using PR22.Models;
using PR22.Models.Decanat;
using PR22.Services.Interfaces;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace PR22.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : ViewModel
    {


        /* ------------------------------------------------------------------------------------*/

        public   CountriesStatisticViewModel  CountriesStatistic { get; }
        public WebServerViewModel WebServer { get; }

        #region Старые коллекции
        public ObservableCollection<Group> Groups { get; }


        public object[] CompositeCollection { get; }

        #endregion

        #region SelectedCompositeValue: object - выбран непонятный компонент
        /// <summary>
        /// номер вкладки
        /// </summary>
        private object _SelectedCompositeValue;
        public object SelectedCompositeValue
        {
            get => _SelectedCompositeValue;
            set => Set(ref _SelectedCompositeValue, value);
        }
        #endregion

        #region SelectedGroup : Group - Выбранная группа
        /// <summary>Выбранная группа</summary>

        private Group _SelectedGroup;
        /// <summary>Выбранная группа</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {

                if (!Set(ref _SelectedGroup, value)) return;

                _SelectedGroupStudends.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudends)); // уведомление интерфейса об изменении второго свойства
                                                                  //  Тут можно уведомлять сколько угодно других свойств
            }


        }
        #endregion

        # region StudentFilterText : string - текст фильтра студентов

        /// <summary>
        ///  Текст фильтра студентов
        /// </summary>
        private string _StudentFilterText;

        /// <summary>
        /// Текст фильтра студентов
        /// </summary>
        public string StudentFilterText
        {
            get => _StudentFilterText;
            set
            {
                if (!Set(ref _StudentFilterText, value)) return;
                _SelectedGroupStudends.View.Refresh();
            }
        }

        #endregion

        #region SelectedGroupStudends

        private readonly CollectionViewSource _SelectedGroupStudends = new CollectionViewSource();
        private readonly IAsyncDataService asyncData;

        private void OnStudentFiltred(object sender, FilterEventArgs e)
        {
            if (e.Item is not Student student)
            {

                e.Accepted = false;
                return;
            }

            var filter_text = _StudentFilterText;
            if (string.IsNullOrEmpty(filter_text))
                return;
           
            if (student.Name is null || student.Surname is null || student.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }

            if (student.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return ;
            if (student.Surname.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return ;
            if (student.Patronymic.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return ;
            e.Accepted = false;
        }

        public ICollectionView SelectedGroupStudends => _SelectedGroupStudends?.View;

        #endregion


        #region SelectedPageIndex : Int - номер вкладки 
        /// <summary>
        /// номер вкладки
        /// </summary>
        private int _SelectedPageIndex = 1;
        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }
        #endregion


        #region TestDataPoints : IEnumerable - DESCRIPTION 
        /// <summary>
        /// Тестовый набор данных для визуализации
        /// </summary>
        private IEnumerable<Models.DataPoint> _TestDataPoints;
        public IEnumerable<Models.DataPoint> TestDataPoints 
        { get => _TestDataPoints;
          set => Set(ref _TestDataPoints, value);
        }
        #endregion

        #region Заголовок Окна
        private string _Title ="Анализ статистики CV19";
        /// <summary> /// Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();
            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }
        #endregion

        #region Status : string - Статус программы
        /// <summary>Статус программы</summary>

        private string _Status = "Готов!";
        /// <summary>Статус программы</summary>
        public string Status
        { 
            get => _Status; 
            set => Set(ref _Status, value); 
        }
        #endregion


        #region _FuelCount

      /// <summary>
      /// Количество топлива
      /// </summary>
      /// 

        private double _FuelCount;
      /// <summary>
      /// Количество топлива
      /// </summary>
      /// 
        public double FuelCount
        {
            get { return _FuelCount; }
            set { Set(ref _FuelCount, value); }
        }
        #endregion




        #region Coefficient

        /// <summary>
        /// Коэффициент
        /// </summary>
        /// 

        private double _Coefficient = 1;
        /// <summary>
        /// Коэффициент
        /// </summary>
        /// 
        public double Coefficient
        {
            get { return _Coefficient; }
            set { Set(ref _Coefficient, value); }
        }
        #endregion


        #region DataValue : string - Результат длительной асинхронной операции
        /// <summary>
        /// Результат длительной асинхронной операции
        /// </summary>
        private string _DataValue;

        public string DataValue
        {
            get => _DataValue;
            private set => Set(ref _DataValue, value);
        }


        #endregion






        /* ------------------------------------------------------------------------------------*/


        #region Команды


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void onCloseApplicationCommandExecuted(object p)
        {
            (RootObject as Window)?.Close();
            //Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }
        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecute(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }
        #endregion

        #region CreateNewGroupCommand

        public ICommand CreateNewGroupCommand { get; }

        private bool CanCreateNewGroupCommandExexuted(object p) => true;

        private void OnCreateNewGroupCommandExexuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_group = new Group
            {
                Name = $"Группа {group_max_index}",
                Students = new ObservableCollection<Student>()
            };

            Groups.Add(new_group);
        } 
        #endregion
 
        #region DeleteCommandGroup
        public ICommand DeleteGroupCommand { get; }
        private bool CanDeleteGroupCommandExecuted(object p) => p is Group group && Groups.Contains(group); 
        /// <summary>
        /// Проверели p - объект типа група ?? содержит группа объект 
        /// </summary>
        /// <param name="p"></param>

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (p is not Group group) return;
            var group_index = Groups.IndexOf(group);

            Groups.Remove((group));
            if(group_index < Groups.Count)
            {
                SelectedGroup = Groups[group_index];
            }
        }
        #endregion


        #region StartProcessCommandGroup Запуск процесса
        public ICommand StartProcessCommand { get; }
        private static bool CanStartProcessCommandExecuted(object p) => true;
        /// <summary>
        /// Запуск процесса
        /// </summary>
        /// <param name="p"></param>

        private void OnStartProcessCommandExecuted(object p)
        {
            new Thread(ComputeValue).Start();
        }

        private void ComputeValue()
        {
            DataValue = asyncData.GetResult(DateTime.Now);
        }
        #endregion

        #region StopProcessCommandGroup остановка процесса
        public ICommand StopProcessCommand { get; }
        private bool CanStopProcessCommandExecuted(object p) => true;
        /// <summary>
        /// остановка процесса
        /// </summary>
        /// <param name="p"></param>

        private void OnStopProcessCommandExecuted(object p)
        {

        }
        #endregion







        #endregion

        /* ------------------------------------------------------------------------------------*/
        public MainWindowViewModel(CountriesStatisticViewModel Statistic,IAsyncDataService asyncData, WebServerViewModel WebServer)
        {
            CountriesStatistic = Statistic;
            this.asyncData = asyncData;
            this.WebServer = WebServer;
            Statistic.MainModel = this;
            //CountriesStatistic = App.Host.Services.GetRequiredService<CountriesStatisticViewModel>();
            //CountriesStatistic = new CountriesStatisticViewModel(this);
            #region  Объекты Команд
            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecute,CanChangeTabIndexCommandExecute);
            CreateNewGroupCommand = new LambdaCommand(OnCreateNewGroupCommandExexuted, CanCreateNewGroupCommandExexuted);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecuted);
            StartProcessCommand = new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecuted);
            StopProcessCommand = new LambdaCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecuted);
            #endregion

            #region - создание точек

            var tmp = new PlotModel { Title = "Статистика" };
            var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Square };
            var data_points = new List<Models.DataPoint>((int)(360 / 0.1));
            for( var x=0d; x< 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin( x * to_rad);
                data_points.Add(new Models.DataPoint { XValue = x, YValue =y });
                
                series1.Points.Add(new OxyPlot.DataPoint(x,y));
               
            }
            
            TestDataPoints = data_points;
            //series1.ItemsSource = data_points;
            
 
            tmp.Series.Add(series1);
            
            Model = tmp;
            #endregion

            #region Создание студентов
            //#region создание студентов с группами
            //var student_index = 1;

            //var students = Enumerable.Range(1, 10).Select(i => new Student
            //{
            //    Name = $"Name {student_index}",
            //    Surname = $"Surname {student_index}",
            //    Patronymic = $"Patronymic {student_index++}",
            //    Birthday = DateTime.Now,
            //    Rating =0
            //});

            //var groups = Enumerable.Range(1, 20).Select(i => new Group
            //    {
            //    Name = $"Группа {i}",
            //    Students = new ObservableCollection<Student>(students)
            //});

            //Groups = new ObservableCollection<Group>(groups);


            //var dat_list = new List<object>();

            //dat_list.Add("Hello World");
            //dat_list.Add(42);
            //var groupp = Groups[1];
            //dat_list.Add(groupp);
            //dat_list.Add(groupp.Students[0]);

            //CompositeCollection = dat_list.ToArray();

            //_SelectedGroupStudends.Filter += OnStudentFiltred;

            //#endregion

            #endregion

        }


        /* ------------------------------------------------------------------------------------*/


        public PlotModel Model { get;  set; }

        /* ------------------------------------------------------------------------------------*/
    }
}
