using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        public static void FirstThread()
        {
            Console.WriteLine("first thread created!");
            Thread currentThread = Thread.CurrentThread;
            string threadDetail = "thread name:" + currentThread.Name + "\r\nthread state:" + currentThread.ThreadState.ToString() + "\r\nthread priority level:" + currentThread.Priority.ToString();
            Console.WriteLine("the detail of the thread  are:" + threadDetail);
            Console.WriteLine("first thread terminated!");
            Console.ReadLine();
        }
        public static void Main(string[] args)
        {
            ThreadStart thStartFunc = new ThreadStart(FirstThread);
            Console.WriteLine("create the first thread!");
            Thread threadF = new Thread(thStartFunc);
            threadF.Name = "first_thread";
            threadF.Start();
        }
    }
}
