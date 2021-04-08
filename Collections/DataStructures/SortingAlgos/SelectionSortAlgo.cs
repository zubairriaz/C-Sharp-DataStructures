using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgos
{
   public class SelectionSortAlgo
    {
        public static T[] SelectionSortAlgoMethod<T>(T[] array) where T:IComparable
        {
            for(var i = 0; i<=array.Length-1; i++)
            {
                var minValue = array[i];
                var indexToReplace = i;
                for (var j = i+1; j<=array.Length -1;  j++)
                {
                    if(array[j].CompareTo(minValue) < 0)
                    {
                        minValue = array[j];
                        indexToReplace = j;
                    }
                }

                swap(array, i, indexToReplace);
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
