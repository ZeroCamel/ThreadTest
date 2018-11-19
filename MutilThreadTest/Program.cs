using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadTest
{
    class Program
    {
        /// <summary>
        /// 线程的创建和销毁需要耗费一定的开销，过多的使用线程会造成内存资源的浪费
        /// </summary>
        public static void TestMethod()
        {
            Console.WriteLine("不带参数的线程函数!");
        }
        public static void TestMethod(object data)
        {
            string dataStr = data as string;
            Console.WriteLine("带参数的线程函数{0}", dataStr);
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(TestMethod));
            Thread t2 = new Thread(new ParameterizedThreadStart(TestMethod));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Start();
            t2.Start("Hello");
            Console.ReadKey();
        }
    }
}
