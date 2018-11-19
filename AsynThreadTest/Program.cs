using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynThreadTest
{
    public delegate string MyDelegate(object data);
    class Program
    {
        //线程函数
        public static string TestMethod(object data)
        {
            string dataStr = data as string;
            return dataStr;
        }
        //异步回调函数-验证函数
        public static void TestCallBack(IAsyncResult data)
        {
            Console.WriteLine(data.AsyncState);
        }
        //异步调用不阻塞线程，而是把调用塞到线程池中，程序主线程或UI线程可以继续执行。委托的异步调用通过BeginInvoke和EndInvoke来实现。(Invoke 是同步 )
        // BeginInvoke方法可以使用线程异步地执行委托所指向的方法
        //然后通过EndInvoke方法获得方法的返回值（EndInvoke方法的返回值就是被调用方法的返回值），或是确定方法已经被成功调用
        static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(TestMethod);
            IAsyncResult result = myDelegate.BeginInvoke("Thread Param", TestCallBack, "Callback Param");
            Console.WriteLine(result);
            string resultStr = myDelegate.EndInvoke(result);
            Console.WriteLine(resultStr);
            Console.ReadKey();
        }
    }
}
