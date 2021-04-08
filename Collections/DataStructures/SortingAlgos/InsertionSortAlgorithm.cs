using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgos
{
    public class InsertionSortAlgorithm
    {
        public static T[] InsertionSortAlgoMethod<T>(T[] array) where T : IComparable
        {
            for (var i = 1; i <= array.Length - 1; i++)
            {

                var j = i;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    swap(array, j, j - 1);
                    j--;
                }

                
            }
            return array;
        }


        private static void swap<T>(T[] array, int i, int indexToReplace) where T : IComparable
        {
            var temp = array[i];
            array[i] = array[indexToReplace];
            array[indexToReplace] = temp;
        }


    }
}