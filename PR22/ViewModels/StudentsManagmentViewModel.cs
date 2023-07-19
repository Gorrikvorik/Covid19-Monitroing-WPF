using PR22.Infrastructure.Commands;
using PR22.Models.Decanat;
using PR22.Services.Interfaces;
using PR22.Services.Students;
using PR22.ViewModels.Base;
using PR22.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PR22.ViewModels
{
    internal class StudentsManagmentViewModel : ViewModel
    {
        public IEnumerable<Student> Students => _StudentManager.Students;
        public IEnumerable<Group> Groups => _StudentManager.Groups;
        public StudentsManagmentViewModel(_StudentManager studentManager, IUserDialogService userDialog)
        {
            _StudentManager = studentManager;
            this._UserDialog = userDialog;
        }

        private readonly _StudentManager _StudentManager;
        private readonly IUserDialogService _UserDialog;
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
        ///Group - выбранная группа студентов
        /// </summary>
        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }
        #endregion

        #region SelectedStudent : Student - выбранная группа студентов
        /// <summary>
        ///Student - выбранный студент
        /// </summary>
        private Student _SelectedStudent;
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }
        #endregion

        #region Команды


        #region _EditStudentCommand - Команда изменить студента

        private ICommand _EditStudentCommand;

        public ICommand EditStudentCommand => _EditStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecuted,CanEditStudentCommandExecute);

        private bool CanEditStudentCommandExecute(object p) => p is Student;

        private  void OnEditStudentCommandExecuted(object p)
        {
            if (_UserDialog.Edit(p))
            {
                _StudentManager.Update((Student)p);

                _UserDialog.ShowInformation("Студент отредактирован", "Менеджерр студентов");

            }
            else
                _UserDialog.ShowWarning("Отказ от редактирования", "Менеджер студентов");


        }

        #endregion


        #region _AddStudentCommand - Команда добавить студента

        private ICommand _AddStudentCommand;

        public ICommand AddStudentCommand => _AddStudentCommand ??= new LambdaCommand(OnAddStudentCommandCommandExecuted, CanAddStudentCommandCommandExecute);

        private bool CanAddStudentCommandCommandExecute(object p) =>p is Group;

        private void OnAddStudentCommandCommandExecuted(object p)
        {
            var group = (Group)p;

            var student = new Student();

            if (!_UserDialog.Edit(student) || _StudentManager.Create(student, group.Name))
            {
                OnPropertyChanged(nameof(Students));
                return;
            }
                  if (_UserDialog.Confirm("Не удалось создать сутдента. Повторить?", "Менеджер студентов"))
                        OnAddStudentCommandCommandExecuted(p);
     }



        #endregion


        #region _TestCommand - Тестовая команда

        private ICommand _TestCommand;

        public ICommand TestCommand => _TestCommand ??= new LambdaCommand(OnTestCommandExecuted, CanTestCommandExecute);

        private bool CanTestCommandExecute(object p) => true;

        private void OnTestCommandExecuted(object p)
        {
            var value = _UserDialog.GetStringValue("Введите строку", "123", "Значение по умолчанию");

            _UserDialog.ShowInformation($"Введено: {value}", "123");

        }

        #endregion

        #endregion
    }
}
