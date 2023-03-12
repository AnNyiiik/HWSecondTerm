namespace HW2_Bor;

public class Trie
{
    private class Vertex
    {
        public Vertex(int numberOfTerminalVertices, bool isTerminal)
        {
            this.numberOfTerminalVertices = numberOfTerminalVertices;
            this.isTerminal = isTerminal;
            this.nextVertices = new Dictionary<char, Vertex>();
        }

        private Dictionary<char, Vertex> nextVertices;

        private int numberOfTerminalVertices;
        
        private bool isTerminal;

        public Dictionary<char, Vertex> NextVertices
        {
            get => this.nextVertices;
        }

        public bool IsTerminal
        {
            get => isTerminal;
            set => isTerminal = value;
        }

        public int NumberOfTerminalVertices
        {
            get => numberOfTerminalVertices;
            set => numberOfTerminalVertices = value;
        }

    }

    private readonly Vertex _root;
    
    private int _sizeOfTrie;

    public Trie()
    {
        this._root = new Vertex(0, false);
        this._sizeOfTrie = 0;
    }
    
    public int Size
    {
        get => _sizeOfTrie; 
    }

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
            try
            {
                var isAdded = AddToVertex(vertex.NextVertices[element[position]], element, ++position);
                if (isAdded)
                {
                    ++vertex.NumberOfTerminalVertices;
                    return true;
                }
            }
            catch
            {
                return false;
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
    
    public bool Add(string? element)
    {
        if (String.IsNullOrEmpty(element))
        {
            return false;
        }
        var isAdded =  AddToVertex(this._root, element, 0);
        if (isAdded)
        {
            ++this._sizeOfTrie;
        }

        return isAdded;
    }

    public bool Contains(string? element)
    {
        if (String.IsNullOrEmpty(element))
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
    
    ///<summary> Recursively checks if the given element exists in the tree. If it does, returns a pair of bool values: 1st - 
    ///      true, 2nd - if there is no other elements after the current. If the second value is true, we can delete a
    ///      branch. </summary>
    private Tuple<bool, bool> RemoveWordFromVertex(Vertex vertex, string element, int position)
    {
        if (position == element.Length)
        {
            if (!vertex.IsTerminal)
            {
                return new Tuple<bool, bool>(false, false);
            }

            vertex.IsTerminal = false;
            --vertex.NumberOfTerminalVertices;
            if (vertex.NextVertices.Count == 0)
            {
                return new Tuple<bool, bool>(true, true);
            }
            return new Tuple<bool, bool>(true, false);
        }
        if (vertex.NextVertices.ContainsKey(element[position]))
        {
            
            var isdDeleted = RemoveWordFromVertex(vertex.NextVertices[element[position]], 
                    element, position + 1);
            if (isdDeleted.Item1)
            {
                --vertex.NumberOfTerminalVertices;
                if (!isdDeleted.Item2)
                {
                    return isdDeleted;
                }

                vertex.NextVertices.Remove(element[position]);
                if (vertex.NextVertices.Count != 0 || vertex.IsTerminal)
                {
                    return new Tuple<bool, bool>(true, false);
                }
                return new Tuple<bool, bool>(true, true);
            }
            
            return new Tuple<bool, bool>(false, false);
        }
        
        return new Tuple<bool, bool>(false, false);
    }

    public bool Remove(string? element)
    {
        if (String.IsNullOrEmpty(element))
        {
            return false;
        }
        var isDeleted =  RemoveWordFromVertex(_root, element, 0);
        if (isDeleted.Item1)
        {
            --_sizeOfTrie;
        }
        return isDeleted.Item1;
    }
    
    public int HowManyStartsWithPrefix(String prefix)
    {
        if (prefix.Length == 0)
        {
            return _sizeOfTrie;
        }
        var vertex = FindVertex(prefix);
        if (vertex != null)
        {
            return vertex.NumberOfTerminalVertices;
        }
        return 0;
    }
}