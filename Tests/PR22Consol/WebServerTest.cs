using System;
using System.IO;
using PR22.Web;
namespace PR22Consol
{
    internal  static class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);
            server.RequestReceivied += OnReqestRecieved;

            server.Start();
            Console.WriteLine("Сервер запущен!");
            Console.ReadLine();
        }

        private static void OnReqestRecieved(object? sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;
            Console.WriteLine($"Connection {context.Request.UserHostAddress}");

        using var writer = new StreamWriter(context.Response.OutputStream);
        writer.WriteLine("Hello from Test Web Server!!!");
        }
    }
}
