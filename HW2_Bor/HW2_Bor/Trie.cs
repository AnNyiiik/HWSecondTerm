namespace HW2_Bor;

public class Trie
{
    private class Vertex
    {
        public Vertex(int numberOfTerminalVertices, bool isTerminal)
        {
            _numberOfTerminalVertices = numberOfTerminalVertices;
            _isTerminal = isTerminal;
            _nextVertices = new Dictionary<char, Vertex>();
            NextVertices = _nextVertices;
            IsTerminal = _isTerminal;
            NumberOfTerminalVertices = _numberOfTerminalVertices;
        }

        private readonly Dictionary<char, Vertex> _nextVertices;

        private int _numberOfTerminalVertices;
        
        private bool _isTerminal;

        public Dictionary<char, Vertex> NextVertices { get; }

        public bool IsTerminal { get; set; }

        public int NumberOfTerminalVertices { get; set; }

    }

    private readonly Vertex _root;
    
    private int _sizeOfTrie;

    public Trie()
    {
        _root = new Vertex(0, false);
        Size = _sizeOfTrie;
    }
    
    public int Size { get; private set; }

    private bool AddToVertex(Vertex vertex, string element, int position)
    {
        if (position == element.Length)
        {
            if (vertex.IsTerminal)
            {
                return false;
            }

            vertex.IsTerminal = true;
            ++vertex.NumberOfTerminalVertices;
            return true;
        }
        if (vertex.NextVertices.ContainsKey(element[position]))
        {
            
            var isAdded = AddToVertex(vertex.NextVertices[element[position]], element, ++position);
            if (isAdded)
            {
                ++vertex.NumberOfTerminalVertices;
                return true;
            }
            
            return false;
        }

        ++vertex.NumberOfTerminalVertices;
        var current = vertex;
        while (position < element.Length)
        {
            var newVertex = (position == element.Length - 1) ? new Vertex(1, true) :
                    new Vertex(1, false);
            
            current.NextVertices.Add(element[position], newVertex);
            ++position;
            current = newVertex;
        }

        return true;
    }
    
    public bool Add(string element)
    {
        if (element.Length == 0)
        {
            return false;
        }
        var isAdded =  AddToVertex(_root, element, 0);
        if (isAdded)
        {
            ++_sizeOfTrie;
        }

        return isAdded;
    }

    public bool Contains(string element)
    {
        if (element.Length == 0)
        {
            return false;
        }
        var vertex = FindVertex(element);
        if (vertex == null || !vertex.IsTerminal)
        {
            return false;
        }
        return true;
    }

    private Vertex? FindVertex(string element)
    {
        var position = 0;
        var current = this._root;
        while (position < element.Length)
        {
            if (current.NextVertices.ContainsKey(element[position]))
            {
                current = current.NextVertices[element[position]];
                ++position;
            }
            else
            {
                return null;
            }
        }
        return current;
    }
    
    private bool RemoveWordFromVertex(Vertex vertex, string element, int position)
    {
        if (position == element.Length)
        {
            if (!vertex.IsTerminal)
            {
                return false;
            }

            vertex.IsTerminal = false;
            --vertex.NumberOfTerminalVertices;
            
            return true;
        }
        if (vertex.NextVertices.ContainsKey(element[position]))
        {
            
            var resultOfDeletion = RemoveWordFromVertex(vertex.NextVertices[element[position]], 
                    element, position + 1);
            if (resultOfDeletion)
            {
                --vertex.NumberOfTerminalVertices;
                DeleteBranch(ref vertex, element[position]);
                return true;
            }
            
            return false;
        }
        
        return false;
    }

    private void DeleteBranch(ref Vertex vertexParent, char childKey)
    {
        var vertexChild = vertexParent.NextVertices[childKey];
        if (vertexChild.NextVertices.Count == 0 && !vertexChild.IsTerminal)
        {
            vertexParent.NextVertices.Remove(childKey);
        }
    }

    public bool Remove(string element)
    {
        if (element.Length == 0)
        {
            return false;
        }
        var isDeleted =  RemoveWordFromVertex(_root, element, 0);
        if (isDeleted)
        {
            --_sizeOfTrie;
        }
        return isDeleted;
    }
    
    public int HowManyStartsWithPrefix(String? prefix)
    {
        if (prefix == null)
        {
            throw new ArgumentNullException();
        }
        if (prefix.Length == 0)
        {
            throw new ArgumentException();
        }
        var vertex = FindVertex(prefix);
        if (vertex != null)
        {
            return vertex.NumberOfTerminalVertices;
        }
        return 0;
    }
}