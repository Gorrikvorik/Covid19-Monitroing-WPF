using PR22.Models.Decanat;
using PR22.Services.Interfaces;
using PR22.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR22.Services
{
    class WindowsUserDialogService : IUserDialogService
    {
        public bool Confirm(string Message, string Caption, bool Exclamation = false)
        {
          return  MessageBox.Show(
                 Message
               , Caption
               , MessageBoxButton.YesNo, 
               Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        private static bool EditStudent(Student student) 
        
        {
            var dlg = new StudentEditorWindow()
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronymic = student.Patronymic,
                Rating = student.Rating,
                Birthday = student.Birthday,
                Owner = Application.Current.Windows.OfType<StudentsManagmentWindow>().FirstOrDefault(),
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (!dlg.ShowDialog() == true) return false;

            student.Name = dlg.FirstName;
            student.Surname = dlg.LastName;
            student.Patronymic = dlg.Patronymic;
            student.Rating = dlg.Rating;
            student.Birthday = dlg.Birthday;


            return true;
        }
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
          switch(item)
            {
                case Student student:
                    return EditStudent(student);
                default: throw new NotSupportedException($"Редактирование объекта {item.GetType().Name} не поддерживается");
            }
        }

        public void ShowError(string Message, string Caption)
        {
            MessageBox.Show(Message,Caption,MessageBoxButton.OK,MessageBoxImage.Error);
        }

        public void ShowInformation(string Information, string Caption)
        {
              MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarning(string Message, string Caption)
        {
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
