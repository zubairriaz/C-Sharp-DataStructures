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
    }
}
