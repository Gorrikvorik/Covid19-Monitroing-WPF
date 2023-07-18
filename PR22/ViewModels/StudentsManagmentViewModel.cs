using PR22.Models.Decanat;
using PR22.Services.Students;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.ViewModels
{
    internal class StudentsManagmentViewModel : ViewModel
    {
        public IEnumerable<Student> Students => _StudentManager.Students;
        public IEnumerable<Group> Groups => _StudentManager.Groups;
        public StudentsManagmentViewModel(StudentManager studentManager) => this._StudentManager = studentManager;

        private readonly StudentManager _StudentManager;
        #region Заголовок Окна
        private string _Title = "Управление стуеднтами";


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

        #region _SelectedGroup : Group - выбранная группа студентов
        /// <summary>
        /// номер вкладки
        /// </summary>
        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }
        #endregion
    }
}
