using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashSets
{
    public class SortedSetDemo
    {
        public static void SortedSetDemoMain()
        {
            var names = new List<string>()
            {
                "umair",
                "zubair",
                "bilal",
                "marcin",
                 "Zubair",
                 "Umair"

            };

            var sortednames = new SortedSet<string>(names, Comparer<string>.Create((a, b) => a.ToLower().CompareTo(b.ToLower())));
            foreach(var name in sortednames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
