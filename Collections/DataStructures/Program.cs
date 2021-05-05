using DataStructures.Arrays;
using DataStructures.SortingAlgos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //MultidimensionalArray marray = new MultidimensionalArray();
            //marray.GetTransportEnums();
            int[] array = new[] { -11, 11, 2, -2, 9, 8, 7, 6 };
            var returnedarray = QuickSortAlgo.QuickSortAlgorithm(array);

            var sortedList = new SortedList<int,string>();
            sortedList.Add(1, "one");
            sortedList.Add(2, "one");
            sortedList.Add(3, "one");
            sortedList.Add(4, "one");
            sortedList.Add(5, "one");

            var key = sortedList.ContainsKey(1);
            foreach(var item in sortedList)
            {
                Console.WriteLine(item.Value, key);
            }

       
        }
    }
}
