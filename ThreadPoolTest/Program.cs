using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolTest
{
    class Program
    {
        public static void TestMethod(object data)
        {
            string dataStr = data as string;
            Console.WriteLine(dataStr);
        }
        static void Main(string[] args)
        {
            //将工作项加入到线程池队列
            //线程池默认为后台运行
            ThreadPool.QueueUserWorkItem(TestMethod,"Hello");
            Console.ReadKey();
        }
    }
}
