using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BinarySearchTrees
{
    public class BST_Visualization
    {
        public static void BST_Visualization_Main()
        {
            BinarySearchTree<int> stree = new BinarySearchTree<int>();
            stree.Add(4);
            stree.Add(5);
            stree.Add(6);
            stree.Add(8);
            stree.Add(20);
            Console.Write("Pre-order traversal:\t");
            var Traverse = stree.Traverse(TraversalEnum.PREORDER);
            foreach (var item in Traverse)
            {
                Console.WriteLine(item.Data);
            }
        }
    }
}
