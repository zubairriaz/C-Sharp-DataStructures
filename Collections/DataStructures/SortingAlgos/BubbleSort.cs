using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgos
{
    public class BubbleSort
    {

        public static T[] BubbleSortAlgo<T>(T[] array) where T : IComparable
        {
            for(int i = 0; i<= array.Length; i++)
            {
                var swapped = false;
                for (int j = 0; j<array.Length - 1; j++)
                {
                    if(array[j].CompareTo(array[j+1]) > 0)
                    {
                        swap(array, j, j + 1);
                        swapped = true;
                    }
                  
                }

                if (!swapped)
                {
                    break;
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
