﻿using System;
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
        }

        private static void S_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("aaa");
        }
    }
}
