using System;

namespace DotNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
