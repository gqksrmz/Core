using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTest
{
    class ObservableCollectionTest
    {
        public static void Main(string[] args)
        {
            ObservableCollection<int> s = new ObservableCollection<int>();

            s.CollectionChanged += S_CollectionChanged;

            s.Add(1);

            Task task = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("bbb");
                });
            ParallelLoopResult result = Parallel.For(0, 10, i =>
            {
                //并行循环
            });


            List<Tuple<string, string, int, int, int>> listPerson = new List<Tuple<string, string, int, int, int>>()
            {
                new Tuple<string, string, int, int, int>("菲菲","女",23,161,50),
                new Tuple<string, string, int, int, int>("张三","男",25,171,66),
                Tuple.Create<string,string,int,int,int>("李四","男",25,178,78)
            };
            foreach (var item in listPerson)
            {
                Console.WriteLine($"{item.Item1}  {item.Item2}  {item.Item3}  {item.Item4}  {item.Item5}");
            }
        }

        private static void S_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("aaa");
        }
        

    }
}
