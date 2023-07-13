using System;
using System.Threading;

namespace PR22Consol
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.CurrentThread.Name = "Main thread";
            var thread = new Thread(ThreadMethod!);
            thread.Name = "Other thread";

            thread.Start(321);
            CheckThread();
            Console.ReadLine();
        }

        private static void ThreadMethod(object parametr) 
        {
            var value = (int)parametr;
            Console.WriteLine(value);
            CheckThread();
            while(true)
            {
                Thread.Sleep(1000);
                Console.Title = DateTime.Now.ToString();
            }
        }

        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("id:{0}:name:{1}",thread.ManagedThreadId,thread.Name);
        }
    }

}
