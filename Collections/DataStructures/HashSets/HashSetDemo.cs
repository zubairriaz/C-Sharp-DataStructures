using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.HashSets
{
    public class HashSetDemo
    {
        public enum PoolTypeEnum
        {
            RECREATION,
            COMPETITION,
            THERMAL,
            KIDS
        }
        public static void HashSetDemoMain()
        {
            var tickets = new Dictionary<PoolTypeEnum, HashSet<int>>()
            {
                {PoolTypeEnum.COMPETITION , new HashSet<int>() },
                {PoolTypeEnum.RECREATION , new HashSet<int>() },
                {PoolTypeEnum.THERMAL , new HashSet<int>() },
                {PoolTypeEnum.KIDS , new HashSet<int>() },

            };

            for (var i = 0; i<=100; i++)
            {
                foreach (var item in tickets)
                {
                    if (GetNextBoolean())
                    {
                        item.Value.Add(i);
                    }
                }
            }

            foreach(var ticket in tickets)
            {
                Console.WriteLine($"The pool of type {ticket.Key.ToString().ToLower()} contains {ticket.Value.Count}");
            }


            var maxVisitors = tickets.OrderByDescending(x => x.Value.Count).Select(x => x.Key).FirstOrDefault();
            Console.WriteLine($"Max visitors are in pool of type {maxVisitors}");

            HashSet<int> any = new HashSet<int>(tickets[PoolTypeEnum.THERMAL]);
            any.UnionWith(tickets[PoolTypeEnum.RECREATION]);
            any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
            any.UnionWith(tickets[PoolTypeEnum.KIDS]);

            Console.WriteLine($"These people visitd atleast one pool are {any.Count}");

            HashSet<int> all = new HashSet<int>(tickets[PoolTypeEnum.THERMAL]);
            any.IntersectWith(tickets[PoolTypeEnum.RECREATION]);
            any.IntersectWith(tickets[PoolTypeEnum.COMPETITION]);
            any.IntersectWith (tickets[PoolTypeEnum.KIDS]);
            Console.WriteLine($"These people visitd atleast one pool are {all.Count}");







        }

        public static bool GetNextBoolean()
        {
            Random rand = new Random();
            return rand.Next(2) == 1;
        }



    }
}
