using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class TreeExampleMethods
    {
        public static void TreeExampleMethod()
        {
            var Tree = new Tree<int>();
            Tree.Root = new TreeNode<int>() { Data = 100 };
            Tree.Root.Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>(){Data = 50},
                new TreeNode<int>(){Data = 1},
                new TreeNode<int>(){Data = 150},

            };

            Tree.Root.Children[2].Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>(){Data = 30},
                new TreeNode<int>(){Data = 5},
                new TreeNode<int>(){Data = 11},
            };
           
        }
    }
}
