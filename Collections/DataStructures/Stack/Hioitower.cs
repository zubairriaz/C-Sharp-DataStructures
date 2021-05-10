using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stack
{
    class Hinoitower
    {
        public int DiscsCount { get; private set; }
        public int MovesCout { get; private set; }

        public Stack<int> To { get; private set; }

        public Stack<int> From { get; private set; }

        public Stack<int> Auxilary { get; private set; }

        public Hinoitower(int discsCount)
        {
            DiscsCount = discsCount;
            To = new Stack<int>();
            From = new Stack<int>();
            Auxilary = new Stack<int>();
            for (var i = 1; i <= DiscsCount; i++)
            {
                int size = DiscsCount - i + 1;
                From.Push(size);
            }
        }

        public void Start()
        {
            Move(DiscsCount, From, To, Auxilary);
        }

        private void Move(int discsCount, Stack<int> from, Stack<int> to, Stack<int> auxilary)
        {
            if (discsCount > 0)
            {
                Move(discsCount - 1, from, auxilary, to);
                to.Push(from.Pop());
                MovesCout++;
                Move(discsCount - 1, auxilary, to, from);

            }
        }

        public string getStats()
        {
            return $"Total moves count are {this.MovesCout}";
        }
    }
}
