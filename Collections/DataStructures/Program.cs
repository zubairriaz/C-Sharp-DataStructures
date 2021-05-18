using DataStructures.Arrays;
using DataStructures.BinarySearchTrees;
using DataStructures.Graphs;
using DataStructures.HashSets;
using DataStructures.HashtablePractises;
using DataStructures.LinkedList;
using DataStructures.SortingAlgos;
using DataStructures.Stack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //MultidimensionalArray marray = new MultidimensionalArray();
            //marray.GetTransportEnums();
            // int[] array = new[] { -11, 11, 2, -2, 9, 8, 7, 6 };
            // var returnedarray = QuickSortAlgo.QuickSortAlgorithm(array);

            //foreach(var item in returnedarray)
            // {
            //     Console.WriteLine(item);
            // }

            //LinkedListPractise.LinkedListMethod();
            //var reversed = StackPractise.ReverseWord("Zubair");

            //Console.WriteLine(reversed);

            //var towerofHinoi = new Hinoitower(2);
            //towerofHinoi.Start();
            //Console.WriteLine(towerofHinoi.getStats());
            //HashTablePractise.HashTableFunctions();
            //HashSetDemo.HashSetDemoMain();
            //BST_Visualization.BST_Visualization_Main();

            var graph = new Graph<int>(true, true);
            var n1 = graph.AddNode(2);
            var n2 = graph.AddNode(3);
            var n3 = graph.AddNode(4);
            var n5 = graph.AddNode(7);
            var n6 = graph.AddNode(4);
            var n7 = graph.AddNode(3);

            graph.AddEdge(n1, n2, 2);
            graph.AddEdge(n1, n3, 5);
            graph.AddEdge(n3, n5, 5);
            graph.AddEdge(n3, n2, 6);
            graph.AddEdge(n2, n1, 5);
            graph.AddEdge(n5, n6, 5);
            graph.AddEdge(n5, n7, 5);

            var edges = graph.GetEdges();

            foreach (var node in graph.MinimumSpanningTreeKurksal())
            {
                Console.WriteLine(node);
            }





        }
    }
}
