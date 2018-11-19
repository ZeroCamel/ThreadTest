using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMutilThreadTest
{
    class Program
    {
        //<!--委托和方法定义的参数必须一致>
        private delegate int NewTaskDelegate(int ms);
        private static int NewTask(int ms)
        {
            Console.WriteLine("任务开始");

            //模拟方法执行的时间
            Thread.Sleep(ms);
            Random random = new Random();
            int n = random.Next(10000);
            Console.WriteLine("任务完成");
            return n;
        }
        static void Main(string[] args)
        {
            NewTaskDelegate task = NewTask;
            //无回调函数和函数的参数-BeginInvoke 默认后台运行，使线程异步的调用委托所执行的方法
            IAsyncResult result = task.BeginInvoke(1000, null, null);

            //判断异步调用是否执行成功
            //1.
            while (!result.IsCompleted)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }
            
            //2.
            //while (!result.AsyncWaitHandle.WaitOne(100,false))
            //{
            //    Console.Write("*");
            //}

            //程序运行两秒输出结果
            int resultStr = task.EndInvoke(result);
            Console.WriteLine(resultStr);

            Console.ReadKey();
        }
    }
}
