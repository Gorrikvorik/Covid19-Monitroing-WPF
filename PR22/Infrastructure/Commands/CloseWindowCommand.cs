using PR22.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR22.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        public bool DialogRusult { get; set; }
        public override bool CanExecute(object? parameter)
        {
            return parameter is Window;
        }
        public override void Execute(object? parameter) 
        {
            if (!CanExecute(parameter)) return;

            var window = (Window)parameter;
            window.DialogResult = DialogRusult;
            window.Close();
        }

    }

    class CloseWDialogCommand : Command
    {
        public bool DialogRusult { get; set; }
        public override bool CanExecute(object? parameter)
        {
            return parameter is Window;
        }
        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (Window)parameter;
            window.DialogResult = DialogRusult;
            window.Close();
        }

    }
}
