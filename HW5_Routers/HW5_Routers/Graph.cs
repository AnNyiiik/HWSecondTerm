namespace HW5_Routers;

public class Graph
{
    private class Edge
    {
        private int _nodeFirst;
        private int _nodeSecond;
        private int _weigth;

        public Edge(int nodeFirst, int nodeSecond, int weight)
        {
            _nodeFirst = nodeFirst;
            _nodeSecond = nodeSecond;
            _weigth = weight;

            NodeFirst = _nodeFirst;
            NodeSecond = _nodeSecond;
            Weight = _weigth;
        }
        
        public int NodeFirst { get; set; }
        public int NodeSecond { get; set; }
        public int Weight { get; set; }
    }

    private List<Edge> edges;

    public void AddEdge(int nodeFirst, int nodeSecond, int weight)
    {
        edges.Add(new Edge(nodeFirst, nodeSecond, weight));
    }

    private int CompareEdges(Edge first, Edge second)
    {
        if (first.Weight > second.Weight)
        {
            return 1;
        } 
        if (first.Weight < second.Weight)
        {
            return -1;
        }

        return 0;
    }

    private void SortEdges()
    {
        edges.Sort();
    }

}