using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.ViewModels
{
     internal class MainWindowViewModel : ViewModel
    {
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

        
    }
}
