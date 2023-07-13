using PR22.Services.Interfaces;
using PR22.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services
{
    internal class HttpListenerWebServer : IWebServerService
    {
        private WebServer _Server = new WebServer(8080);
        public bool Enabled { get => _Server.Enabled; set => _Server.Enabled = value; }

        public void Start() => _Server.Start();

        public void Stop() => _Server.Stop();

        public HttpListenerWebServer()
        {
            _Server.RequestReceivied += OnRequestReceived;
        }

        private static void OnRequestReceived(object? sender, RequestReceiverEventArgs e)
        {
            using var writer = new StreamWriter(e.Context.Response.OutputStream);
            writer.WriteLine($"PR=22 Application  {DateTime.Now}");
        }
    }
}
