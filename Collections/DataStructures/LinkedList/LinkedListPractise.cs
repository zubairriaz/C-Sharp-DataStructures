using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
   public class LinkedListPractise
    {
        public static void LinkedListMethod()
        {
            LinkedList<Page> pages = new LinkedList<Page>();
            pages.AddFirst(new Page() { Content = "Hello there how are you first" });
            pages.AddLast(new Page() { Content = "Hello there how are you 2" });
            LinkedListNode<Page> linkedListNode3 = pages.AddLast(new Page() { Content = "Hello there how are you 3" });
            var page4 = new Page() { Content = "Hello there how are you 4" };
            pages.AddAfter(linkedListNode3, page4);

            foreach(var page in pages)
            {
                Console.WriteLine(page.Content);
            }

            var item = pages.First;
            while (item != null)
            {
                Console.WriteLine(item.Value.Content);
                item = item.Next;
            }

            var current = pages.Last;
            while (current != null)
            {
                Console.WriteLine(current.Value.Content);
                current = current.Previous;
            }







        }
    }

    internal class Page
    {
        public string Content { get; set; }
    }
}
