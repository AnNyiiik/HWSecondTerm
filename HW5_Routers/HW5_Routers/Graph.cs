using System.Text;

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
        
        public int NodeFirst { get; }
        public int NodeSecond { get; }
        public int Weight { get; }
    }
    
    private readonly List<Edge> _edges;
    public Graph()
    {
        _edges = new List<Edge>();
        _sets = new List<Set>();
    }

    public void AddEdge(int nodeFirst, int nodeSecond, int weight)
    {
        _edges.Add(new Edge(nodeFirst, nodeSecond, weight));
    }

    private void AddEdge(Edge edge)
    {
        _edges.Add(edge);
    }
    
    private void Add(Graph graph)
    {
        foreach (Edge edge in graph._edges)
        {
            _edges.Add(edge);
        }
    }
    
    private class Set
    {
        private readonly Graph _set;
        private readonly List<int> _nodes;

        public Graph GetSet { get; }

        public Set(Edge edge)
        {
            _set = new Graph();
            _set.AddEdge(edge);
            
            _nodes = new List<int>();
            _nodes.Add(edge.NodeFirst);
            _nodes.Add(edge.NodeSecond);

            GetSet = _set;
        }
        
        public void UnionGraphs(Set set, Edge connectingEdge)
        {
            _set.Add(set._set);
            _nodes.AddRange(set._nodes);
            _set.AddEdge(connectingEdge);
        }

        public void AddEdge(Edge edge)
        {
            _nodes.Add(edge.NodeFirst);
            _nodes.Add(edge.NodeSecond);
            _set.AddEdge(edge);
        }
        
        public bool Contains(int node)
        {
            return _nodes.Contains(node);
        }
        
    }
    
    private readonly List<Set> _sets;
    
    private Set? Find(int node)
    {
        foreach (var set in _sets)
        {
            if (set.Contains(node)) return set;
        }
        return null;
    }
    
    private void AddEdgeInSet(Edge edge)
    {
        var setFirst = Find(edge.NodeFirst);
        var setSecond = Find(edge.NodeSecond);

        if (setFirst != null && setSecond == null)
        {
            setFirst.AddEdge(edge);
        }
        else if (setFirst == null && setSecond != null)
        {
            setSecond.AddEdge(edge);
        }
        else if (setFirst == null && setSecond == null)
        {
            var set = new Set(edge);
            _sets.Add(set);
        }
        else if (setFirst != null && setSecond != null)
        {
            if (setFirst != setSecond)
            {
                setFirst.UnionGraphs(setSecond, edge);
                _sets.Remove(setSecond);
            }
        }
    }

    private class EdgeComparer : IComparer<Edge>
    {
        public int Compare(Edge? first, Edge? second)
        {
            if (first?.Weight > second?.Weight)
            {
                return -1;
            } 
            if (first?.Weight < second?.Weight)
            {
                return 1;
            }

            return 0;
        }
    }

    private class EdgeFirstNodeComparer : IComparer<Edge>
    {
        public int Compare(Edge? first, Edge? second)
        {
            if (first?.NodeFirst > second?.NodeFirst)
            {
                return 1;
            } 
            if (first?.NodeFirst < second?.NodeFirst)
            {
                return -1;
            }
            if (first?.NodeSecond > second?.NodeSecond)
            {
                return 1;
            } 
            if (first?.NodeSecond < second?.NodeSecond)
            {
                return -1;
            }
            return 0;
        }
    }

    private void SortEdges()
    {
        _edges.Sort(new EdgeComparer());
    }

    private void FindMaxSpanningTree()
    {
        
        SortEdges();
        foreach (Edge edge in _edges)
        {
            AddEdgeInSet(edge);
        }
    }

    public string? PrintMaxSpanningTree()
    {
        FindMaxSpanningTree();
        if (_sets.Count != 1)
        {
            return null;
        }
        var edges = _sets[0].GetSet._edges;
        edges.Sort(new EdgeFirstNodeComparer());
        var output = new StringBuilder();
        bool isNewString = true;
        for (var i = 0; i < edges.Count; ++i)
        {
            if (isNewString)
            {
                if (i == edges.Count - 1)
                {
                    output.Append(edges[i].NodeFirst + ": " + edges[i].NodeSecond + " (" + edges[i].Weight + ")");
                    break;
                }
                if (edges[i].NodeFirst == edges[i + 1].NodeFirst)
                {
                    output.Append(edges[i].NodeFirst + ": " + edges[i].NodeSecond + " (" + edges[i].Weight + "), ");
                    isNewString = false;
                }
                else
                {
                    output.Append(edges[i].NodeFirst + ": " + edges[i].NodeSecond + " (" + edges[i].Weight + ")\n");
                }
            }
            else
            {
                if (i == edges.Count - 1)
                {
                    output.Append(edges[i].NodeSecond + " (" + edges[i].Weight + ")");
                    break;
                }
                if (edges[i].NodeFirst == edges[i + 1].NodeFirst)
                {
                    output.Append(edges[i].NodeSecond + " (" + edges[i].Weight + "), ");
                }
                else
                {
                    output.Append(edges[i].NodeSecond + " (" + edges[i].Weight + ")\n");
                    isNewString = true;
                }
            }
        }
        return output.ToString();
    }

}