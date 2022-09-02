using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static void MainThread(object state)
        {
            while(true)
                Console.WriteLine("Hello Thread!");
        }

        static void Main(string[] args)
        {

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

            for(int i=0; i<5; i++)
            {
                Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning);
                t.Start();
            }

            //for (int i = 0; i < 5; i++)
            //    ThreadPool.QueueUserWorkItem((obj) => { while (true) { } });

            ThreadPool.QueueUserWorkItem(MainThread);

            //Thread t = new Thread(MainThread);
            //t.Name = "Test Thread";
            //t.IsBackground = true;
            //t.Start();
            //Console.WriteLine("Waiting for Thread");
            //t.Join();
            //Console.WriteLine("Hello World!");
        }
    }
}
