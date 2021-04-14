using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgos
{
    public class QuickSortAlgo
    {
        public static T[] QuickSortAlgorithm<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }

        private static T[] Sort<T>(T[] array, int v1, int v2) where T : IComparable
        {
            if (v1 < v2)
            {
                int partition = Partition(array, v1, v2);
                Sort(array, v1, partition);
                Sort(array, partition + 1, v2);
            }
            return array;
        }

        private static int Partition<T>(T[] array, int v1, int v2) where T : IComparable
        {
            T pivot = array[v1];
            // if array is sorted v2 moves backwards and eventually gets equal to v1 resulting in breaking out of the loop without swapping
            do
            {
                while(array[v1].CompareTo(pivot) < 0) { v1++; };
                while (array[v2].CompareTo(pivot) > 0) { v2--; };
                if(v1 >= v2) { break; }
                swap(array, v1, v2);
            }while(v1 <= v2) ;

            return v2;
        }

        private static void swap<T>(T[] array, int i, int indexToReplace) where T : IComparable
        {
            var temp = array[i];
            array[i] = array[indexToReplace];
            array[indexToReplace] = temp;
        }
    }
}
