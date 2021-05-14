using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BinarySearchTrees
{
    public class BinarySearchTree<T> : BinaryTree<T> where T: IComparable
    {
        public bool isContains (T data)
        {
            BinaryTreeNode<T> node = Root;
            while (node != null)
            {
                int result = node.Data.CompareTo(data);
                if (result == 0)
                {
                    return true;
                }
                else if(result < 0)
                {
                    node = node.LeftChild;
                }
                else if(result > 0)
                {
                    node = node.RightChild;
                }
             

            }
            return false;
           
        }

        public void Add(T data)
        {

            // First find the parent for the node to add. 2nd add the node to the right or left of the Parent appropriately.
            BinaryTreeNode<T> Parent = GetParentForNewNode(data);
            BinaryTreeNode<T> NewNode = new BinaryTreeNode<T>()
            {
                Data = data,
                Parent = Parent
            };

            if (Parent == null)
            {
                Root = NewNode;
            }
            else if (NewNode.Data.CompareTo(Parent.Data) > 0)
            {
                Parent.RightChild = NewNode;
            }
            else if (NewNode.Data.CompareTo(Parent.Data) < 0)
            {
                Parent.LeftChild = NewNode;
            }
        }

        private BinaryTreeNode<T> GetParentForNewNode(T data)
        {
            BinaryTreeNode<T> current = Root;
            BinaryTreeNode<T> parent = null;
            while (current != null)
            {
                parent = current;
                if (data.CompareTo(current.Data) == 0)
                {
                    throw new ArgumentException("node Already exists");
                }
                else if (data.CompareTo(current.Data) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    current = current.LeftChild;
                }
            }
            return parent;
        }


        public void Remove (T data)
        {
            Remove(Root, data);
        }

        private void Remove(BinaryTreeNode<T> node, T data)
        {
            if (node == null)
            {
                throw new ArgumentException("Tree does not contains the respected value");
            }
            //Find the child to remove in right subtree
           else if (data.CompareTo(node.Data) > 0)
            {
                Remove(node.RightChild, data);
            }
            //Find the child to remove in left subtree
            else if (data.CompareTo(node.Data) < 0)
            {
                Remove(node.LeftChild, data);
            }
            else
            {   // If the found child is leaf node i.e have no children
                if (node.LeftChild == null && node.RightChild == null)
                {
                    //Parent will have a refernece of null
                    ReplaceInParent(node, null);
                    Count--;
                }
                // If the found child has left children
                else if (node.LeftChild != null)
                {
                    //Parent will have a refernece of left child
                    ReplaceInParent(node, node.LeftChild);
                }
                // If the found child has right children
                else if (node.LeftChild == null)
                {
                    //Parent will have a refernece of right child
                    ReplaceInParent(node, node.RightChild);
                }
                else
                {
                    // if selected node has both left and right child, then find the miimum in the right subtree and replace that with the selected node
                    BinaryTreeNode<T> successor = FindMinimumInRightSubTree(node);
                    node.Data = successor.Data;
                    Remove(successor, successor.Data);
                }
            }

        }

        private BinaryTreeNode<T> FindMinimumInRightSubTree(BinaryTreeNode<T> node)
        {
            while (node != null)
            {
                node = node.LeftChild;
            }

            return node;
        }

        private void ReplaceInParent(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (node.Parent != null)
            {
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = newNode;
                }
                else
                {
                    node.Parent.RightChild = newNode;
                }
            }
            else
            {
                Root = newNode;
            }

            if(newNode != null)
            {
                newNode.Parent = node.Parent;
            }
        }
    }
}
