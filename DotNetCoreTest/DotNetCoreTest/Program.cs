using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object lockObj = new object();
            //dynamic obj = new System.Dynamic.ExpandoObject();
            //Program p = new Program();
            //MyDelegate d1 = new MyDelegate(p.Test1);
            //d1 += new MyDelegate(p.Test2);
            //d1 += new MyDelegate(p.Test3);
            //d1("XIXI");
            //Test(obj);
            //List<int> list1 = new List<int>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    list1.Add(new Random().Next(0, 10000));
            //}
            //List<int> list2 = new List<int>(list1.ToArray());
            //Stopwatch stopwatch1 = new Stopwatch();
            //stopwatch1.Start();
            //foreach (var item in list1)
            //{
            //    Console.WriteLine("不平行" + item);
            //}
            //stopwatch1.Stop();
            //Stopwatch stopwatch2 = new Stopwatch();
            //stopwatch2.Start();
            //Parallel.ForEach(list2, item =>
            // {
            //     lock (lockObj)
            //     {
            //         Console.WriteLine("平行" + item);
            //     }
            // });
            //stopwatch2.Stop();
            //Console.WriteLine("非平行" + stopwatch1.Elapsed);

            //Console.WriteLine("平行" + stopwatch2.Elapsed);
          
        }

        


        //delegate void MyDelegate(string name);
        //public void Test1(string name)
        //{
        //    Console.WriteLine(name);
        //}
        //public void Test2(string name)
        //{
        //    Console.WriteLine(name);
        //}
        //public void Test3(string name)
        //{
        //    Console.WriteLine(name);
        //}
        //public static void Test<T>(T parm)
        //{
        //    Console.WriteLine(parm.GetType());
        //}

    }
}
