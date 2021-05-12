using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BinarySearchTrees
{
    public class BinaryTreeNode<T> :  TreeNode<T>
    {
        public BinaryTreeNode()
        {
            Children = new List<TreeNode<T>>() { null, null };
        }

        public BinaryTreeNode<T> LeftChild { get { return (BinaryTreeNode<T>)Children[0]; } set { Children[0] = value; } }
        public BinaryTreeNode<T> RightChild { get { return (BinaryTreeNode<T>)Children[1]; } set { Children[1] = value; } }

    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get; set; }

        private void TraversePreOrder(BinaryTreeNode<T> node , List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                result.Add(node);
                TraversePreOrder(node.LeftChild, result);
                TraversePreOrder(node.RightChild, result);
            }
        }

        private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.LeftChild, result);
                result.Add(node);
                TraverseInOrder(node.RightChild, result);
            }
        }

        private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraversePostOrder(node.LeftChild, result);
                TraversePostOrder(node.RightChild, result);
                result.Add(node);

            }
        }

        public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
        {
            var result = new List<BinaryTreeNode<T>>();
            switch (mode)
            {
                case TraversalEnum.INORDER:
                    TraverseInOrder(Root, result);
                    break;
                case TraversalEnum.PREORDER:
                    TraversePreOrder(Root, result);
                    break;
                case TraversalEnum.POSTORDER:
                    TraversePostOrder(Root, result);
                    break;


            }

            return result;
        }

        public int GetHeight()
        {
            int height = 0;
            foreach(var item in Traverse(TraversalEnum.PREORDER))
            {
                height = Math.Max(height, item.GetHeight());
            }
            return height;
        }
    }

    public enum TraversalEnum
    {
        PREORDER,
        INORDER,
        POSTORDER
    }
}
