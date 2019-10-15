using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DotNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            Program p = new Program();
            MyDelegate d1, d2, d3;
            d1 = new MyDelegate(p.Test1);
            d2 = new MyDelegate(p.Test2);
            d3 = new MyDelegate(p.Test3);
            d1("HAHA");
            d2("XIXI");
            d3("xixi");
            Test(obj);
            int[] list1 = new int[10000] ;
            for (int i = 0; i < 10000; i++)
            {
                list1[i]=new Random().Next(0, 10000);
            }
            int[] list2 = (int[])list1.Clone();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            foreach (var item in list1)
            {
                Console.WriteLine("非平行"+item);
            }
            stopwatch1.Stop();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Parallel.ForEach(list2, item =>
            {
                Console.WriteLine("平行"+item);
            });
            stopwatch2.Stop();
            Console.WriteLine("非平行" + stopwatch1.Elapsed);

            Console.WriteLine("平行"+ stopwatch2.Elapsed);
        }

        delegate void MyDelegate(string name);
        public void Test1(string name)
        {
            Console.WriteLine(name);
        }
        public void Test2(string name)
        {
            Console.WriteLine(name);
        }
        public void Test3(string name)
        {
            Console.WriteLine(name);
        }



        public static void Test<T>(T parm)
        {
            Console.WriteLine(parm.GetType());
        }

    }
}
