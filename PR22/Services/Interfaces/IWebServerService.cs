using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services.Interfaces
{
    internal interface IWebServerService
    {
        bool Enabled { get; set; }
        void Start();

        void Stop();
    }
}
