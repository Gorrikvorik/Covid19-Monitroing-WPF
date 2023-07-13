using PR22.Infrastructure.Commands;
using PR22.Services.Interfaces;
using PR22.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PR22.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        #region Enabled
      
        public bool Enabled { get => Server.Enabled; set
            {
                Server.Enabled = value;
                OnPropertyChanged();
            }
        }
        #endregion




        #region StartCommand
        private ICommand _StartCommand;

        public ICommand StartCommand => _StartCommand
            ?? new LambdaCommand(OnStartCommandExecuted,CanStartCommandExecute);

        private bool CanStartCommandExecute(object p) => !Enabled;

        private void OnStartCommandExecuted(object p)
        {
            Server.Start();
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion




        #region StopCommand
        private ICommand _StopCommand;

        public ICommand StopCommand => _StopCommand
            ?? new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);



        private bool CanStopCommandExecute(object p) => Enabled;

        private void OnStopCommandExecuted(object p)
        {
            Server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }
        #endregion

        public IWebServerService Server { get; }
        public WebServerViewModel(IWebServerService Server)
        {
            this.Server = Server;
        }
    }
}
