using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //class adk
    //{
    //    public static int a = 2;
    //}
    class Program
    {
        static private object _obj = new object();
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 0; i < 50000; i++)
            {
                int x = 2;
                Task t1 = Task.Factory.StartNew(() => {  InterlockedMultiply(ref x, 10); });
                Task t2 = Task.Factory.StartNew(() => { lock (_obj) Interlocked.Increment(ref x); });
                Task.WaitAll(t1, t2);
                if (x != 21 && x != 30)
                {
                    Console.WriteLine(x);
                    count++;
                }
            }
            Console.WriteLine("值不为21且不为30的次数：" + count);
            Console.WriteLine("done!");
            Console.ReadLine();
        }
        static void InterlockedMultiply(ref int x, int y)
        {
            lock (_obj)
            {
                x = x * y;
            }
        }
    }
}
