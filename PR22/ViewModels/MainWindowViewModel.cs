using OxyPlot;
using OxyPlot.Series;
using PR22.Infrastructure.Commands;
using PR22.Models;
using PR22.Models.Decanat;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PR22.ViewModels
{
     internal class MainWindowViewModel : ViewModel
    {


        /* ------------------------------------------------------------------------------------*/

        public ObservableCollection<Group> Groups { get; }


        public object[] CompositeCollection { get; }


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

        private Group _SelectedGroup  ;
        /// <summary>Выбранная группа</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }
        #endregion


        #region SelectedPageIndex : Int - номер вкладки 
        /// <summary>
        /// номер вкладки
        /// </summary>
        private int _SelectedPageIndex;
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


        /* ------------------------------------------------------------------------------------*/


        #region Команды


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void onCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
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

        #endregion


        /* ------------------------------------------------------------------------------------*/
        public MainWindowViewModel()
        {

            #region Команды
            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecute,CanChangeTabIndexCommandExecute);
            #endregion

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

            var student_index = 1;

            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating =0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
                {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);


            var dat_list = new List<object>();

            dat_list.Add("Hello World");
            dat_list.Add(42);
            var groupp = Groups[1];
            dat_list.Add(groupp);
            dat_list.Add(groupp.Students[0]);

            CompositeCollection = dat_list.ToArray();


        }
        public PlotModel Model { get; private set; }
    }
}
