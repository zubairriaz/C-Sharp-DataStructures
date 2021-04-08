using DataStructures.Arrays;
using DataStructures.SortingAlgos;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //MultidimensionalArray marray = new MultidimensionalArray();
            //marray.GetTransportEnums();
            int[] array = new[] { -11, 11, 2, -2, 9, 8, 7, 6 };
            var returnedarray = InsertionSortAlgorithm.InsertionSortAlgoMethod<int>(array);

           foreach(var item in returnedarray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
