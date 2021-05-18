namespace DataStructures.Graphs
{
    internal class SubSet<T>
    {
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }
    }
}