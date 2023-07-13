using System.Net;
using System.Net.Sockets;

namespace PR22.Web
{
  
    public class WebServer
    {
        public event EventHandler<RequestReceiverEventArgs> RequestReceivied;

        //  private readonly TcpListener _Listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080)); работает с драйвером сетеовй карты
        private HttpListener _Listener; // работает с операционной системой ( меньше возможностей, но проще реализовать)
        private readonly int _Port;
        private bool _Enabled;
        private  readonly object _SyncRoot = new object();

        public int Port => _Port;
        public bool Enabled { get => _Enabled; set
            {
                if (value) Start(); else Stop();
            }
        }
        public WebServer(int Port) => _Port = Port;

        public void Start() 
        {
            if (_Enabled) return;
            lock(_SyncRoot)
            {
                if (_Enabled) return;
                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{ _Port}/"); //netsh http add urlacl url=http://*:8080/ user=user_name
                _Listener.Prefixes.Add($"http://+:{ _Port}/");
                _Enabled = true;
                ListenAsync();

            }

        }

        public void Stop() 
        {
            if(!_Enabled) return;
            lock(_SyncRoot)
            {  
                if (!_Enabled) return;
                _Listener = null;
                _Enabled = false;
            }

        }

        private async void ListenAsync()
        {
            var listener = _Listener;
            listener.Start();
            while (_Enabled)
            {
                var context = await listener.GetContextAsync().ConfigureAwait(false);
                ProcessRequest(context);
            }


            listener.Stop();

        }

        private void ProcessRequest(HttpListenerContext context)
        {
            RequestReceivied?.Invoke(this, new RequestReceiverEventArgs(context));
        }
    }
    public class RequestReceiverEventArgs : EventArgs 
    {
        public RequestReceiverEventArgs(HttpListenerContext context)
        {
            Context = context;
        }

        public HttpListenerContext Context { get; }
    }
}
