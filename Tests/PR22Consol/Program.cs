using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace PR22Consol
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var values = new List<int>();

            var threads = new Thread[10];
            object lock_obj = new object();
             
            for (int i =0; i< threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        lock(lock_obj)
                        values.Add(Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1);
                    }
                });
            }

 

          foreach (var thread in threads)
            {
                thread.Start();
            }
            Console.ReadLine();
            Console.WriteLine( String.Join(",",values));
            Console.ReadLine();
        }




    }

}
