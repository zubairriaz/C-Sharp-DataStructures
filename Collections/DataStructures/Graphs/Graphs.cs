using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class Graph<T>
    {
        private bool _isDirected { get; set; }
        private bool _isWeighted { get; set; }

        private List<Node<T>> Nodes = new List<Node<T>>();

        public Graph(bool isDirected , bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }

        public Edge<T> this[int from , int to]
        {
            get
            {
                Node<T> nodeFrom = Nodes[from];
                Node<T> nodeto = Nodes[to];

                var neighbourIndex = nodeFrom.Neighbours.IndexOf(nodeto);
                if (neighbourIndex >= 0)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = nodeFrom,
                        To = nodeto,
                        Weight = neighbourIndex < nodeFrom.Weights.Count ? nodeFrom.Weights[neighbourIndex] : 0
                };
                return edge;

            }
                return null;
            }
        }

    }

    public class Node<T>
    {
        public int Index { get; set; }
        public T Data { get; set; }

        public List<Node<T>> Neighbours { get; set; } = new List<Node<T>>();

        public List<int> Weights { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"Node with Index ${Index}:{Data} , neighbours: {Neighbours.Count}";
        }
    }

    public class Edge<T>
    {
        public Node<T> From { get; set; }
        public Node<T> To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Edge: From Node {From.ToString()} to Node {To.ToString()} having wight {Weight}";
        }
    }
}
