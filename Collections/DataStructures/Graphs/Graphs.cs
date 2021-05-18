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

        public List<Node<T>> DFS(Node<T> node)
        {
            var result = new List<Node<T>>();
            bool[] isVisited = new bool[Nodes.Count];
            DFS_Search(node, isVisited, result);
            return result;

        }


        public List<Node<T>> BFS()
        {
            var node = Nodes[0];
            var result = new List<Node<T>>();
            bool[] isVisited = new bool[Nodes.Count];
            BFS_Search(node, isVisited, result);
            return result;

        }

        public List<Edge<T>> MinimumSpanningTreeKurksal()
        {
            var edges = GetEdges();
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            Queue<Edge<T>> edgeQueue = new Queue<Edge<T>>(edges);
            SubSet<T>[] subSets = new SubSet<T>[Nodes.Count];
            for(var i =0; i < Nodes.Count; i++)
            {
                subSets[i] = new SubSet<T>() { Parent = Nodes[i] };
            }

            var result = new List<Edge<T>>();
            while(result.Count < Nodes.Count - 1)
            {
                var edge = edgeQueue.Dequeue();
                var nodeFrom = GetRoot(subSets, edge.From);
                var nodeTo = GetRoot(subSets, edge.To);
                if(nodeFrom != nodeTo)
                {
                    result.Add(edge);
                    Union(subSets, nodeFrom, nodeTo);
                }
            }
            return result;
        }

        private void Union(SubSet<T>[] subSets, Node<T> nodeFrom, Node<T> nodeTo)
        {
            if (subSets[nodeFrom.Index].Rank > subSets[nodeTo.Index].Rank)
            {
                subSets[nodeTo.Index].Parent = nodeFrom;
            }
            else if (subSets[nodeTo.Index].Rank > subSets[nodeFrom.Index].Rank)
            {
                subSets[nodeFrom.Index].Parent = nodeTo;
            }

            else
            {
                subSets[nodeTo.Index].Parent = nodeFrom;
                subSets[nodeFrom.Index].Rank++;
            }
        }

        private Node<T> GetRoot(SubSet<T>[] subSets, Node<T> from)
        {
           if(subSets[from.Index].Parent == from)
            {
                return from;
            }

            return GetRoot(subSets, subSets[from.Index].Parent);
        }

        private void BFS_Search(Node<T> node, bool[] isVisited, List<Node<T>> result)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            while(queue.Count > 0)
            {
                var innernode = queue.Dequeue();
                result.Add(innernode);
                isVisited[innernode.Index] = true;
                foreach(var item in innernode.Neighbours)
                {
                    if (!isVisited[item.Index])
                    {
                        queue.Enqueue(item);
                    }
                }
            }
        }

        private void DFS_Search(Node<T> node, bool[] isVisited, List<Node<T>> result)
        {
            result.Add(node);
            isVisited[node.Index] = true;
            foreach(var neighNode in node.Neighbours)
            {
                if (!isVisited[neighNode.Index])
                {
                    DFS_Search(neighNode, isVisited, result);
                }
            }
        }

        public List<Edge<T>> GetEdges()
        {
            var edges = new List<Edge<T>>();
            foreach (var node in Nodes)
            {
                for (var i = 0; i <= node.Neighbours.Count - 1; i++)
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
