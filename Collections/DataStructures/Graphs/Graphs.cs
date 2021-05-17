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

        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T>() { Data = value };
            Nodes.Add(node);
            UpdateIndices();
            return node;
        }

        public void RemoveNode(Node<T> node)
        {
            Nodes.Remove(node);
            UpdateIndices();
            foreach (var item in Nodes)
            {
                RemoveEdge(item, node);
            }
        }

        private void RemoveEdge(Node<T> from, Node<T> to)
        {
            var index = from.Neighbours.IndexOf(to);
            if(index >= 0)
            {
                from.Neighbours.RemoveAt(index);
                if (_isWeighted)
                {
                    from.Weights.RemoveAt(index);
                }
            }
        }

        public void AddEdge(Node<T> from , Node<T> to, int weight = 0)
        {
            
            
                from.Neighbours.Add(to);
                if (_isWeighted)
                {
                    from.Weights.Add(weight);
                }

            if (!_isDirected)
            {
                to.Neighbours.Add(from);
                if (_isWeighted)
                {
                    to.Weights.Add(weight);
                }
            }
            
        }

        public List<Edge<T>> GetEdges()
        {
            var edges = new List<Edge<T>>();
            foreach (var node in Nodes)
            {
                for (var i = 0; i <= node.Neighbours.Count; i++)
                {
                    var edge = new Edge<T>()
                    {
                        From = node,
                        To = node.Neighbours[i],
                        Weight = i < node.Weights.Count ? node.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
                
            }
            return edges;
        }

        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
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
