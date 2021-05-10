using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stack
{
    public class StackPractise 
    {
        public static string ReverseWord (string word)
        {
            Stack<char> chars = new Stack<char>();
            foreach(var item in word)
            {
                chars.Push(item);
            }

            StringBuilder stringBuilder = new StringBuilder();
            while(chars.Count > 0)
            {
                stringBuilder.Append(chars.Pop());
            }

            return stringBuilder.ToString();
        }


       
    }
}
