using PR22.Infrastructure.Commands.Base;
using PR22.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR22.Infrastructure.Commands
{
    class ManageStudentsCommand : Command
    {
        private StudentsManagmentWindow _Window;
        public override bool CanExecute(object? parameter)
        {
            return _Window == null;
        }

        public override void Execute(object? parameter)
        {
            var window = new StudentsManagmentWindow {
             Owner = Application.Current.MainWindow
            };
            var owner = Application.Current.MainWindow;
            owner.Hide();
            _Window = window;
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }

        private void OnWindowClosed(object Sender, EventArgs e)
        {
            ((Window)Sender).Closed -= OnWindowClosed!;
            _Window = null!;
            var owner = Application.Current.MainWindow;
            owner.Show();
        }
    }
}
