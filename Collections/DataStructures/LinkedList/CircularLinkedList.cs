using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
    public class CircularLinkedList<T> : LinkedList<T>
    {

             public new IEnumerator<T> GetEnumerator()
        {
            return new CircularLinkedListEnumerator<T>(this);
        }

    }

    internal class CircularLinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;


        public CircularLinkedListEnumerator(LinkedList<T> list) {
            _current = list.First;
        }
        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if(_current == null)
            {
                return false;
            }
            _current = _current.Next ?? _current.List.First;
            return true;
        }

        public void Reset()
        {
            _current = _current.List.First;
        }
    }

    public static class LinkedListExtensions
    {
        public static LinkedListNode<T> Next<T> (this LinkedListNode<T> node)
        {
            if(node != null && node.List != null)
            {
                return node.Next ?? node.List.First;
            }

            return null;
        }

        public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
        {
            if (node != null && node.List != null)
            {
                return node.Previous ?? node.List.Last;
            }

            return null;
        }
    }


    public class CircularLinkedListMethods
    {
        public static void CircularLinkedListMethodCheck()
        {
            var circularLinkedList = new CircularLinkedList<string>();
            circularLinkedList.AddFirst("A");
            circularLinkedList.AddFirst("B");
            circularLinkedList.AddLast("C");
            circularLinkedList.AddLast("D");
            circularLinkedList.AddLast("E");
            circularLinkedList.AddLast("F");

            foreach (var items in circularLinkedList)
            {
                Console.WriteLine(items);
            }
        }
    }
}
