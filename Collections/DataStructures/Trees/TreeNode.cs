using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

    }
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }

        public List<TreeNode<T>> Children { get; set; }

        public int GetHeight()
        {
            int height = 1;
            var current = this;
            while(current.Parent != null)
            {
                current = current.Parent;
                height++;
            }
            return height;
        }
    }
}
