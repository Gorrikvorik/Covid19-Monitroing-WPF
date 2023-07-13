using System;
using System.Threading;

namespace PR22Consol
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var count = 5;
            var msg = "Hello World";
            var timeout = 150;

            new Thread(() => PrintMethod(msg, count, timeout)).Start();
        }

        private static void PrintMethod(string message,int count,int timeout)
        {
            for(int i =0; i< count; i++)
            {
                Console.WriteLine(message);
                Thread.Sleep(timeout);
            }
        }


    }

}
