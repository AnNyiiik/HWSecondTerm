using System;
using System.Collections;

namespace HW2_Bor;

public class Trie
{
    private class Vertex
    {
        public Vertex(int numberOfTerminalVertices, bool isTerminal)
        {
            this.NumberOfTerminalVertices = numberOfTerminalVertices;
            this.IsTerminal = isTerminal;
            this.NextVertices = new Dictionary<char, Vertex>();
        }

        public Dictionary<Char, Vertex> NextVertices;

        public int NumberOfTerminalVertices;
        
        public bool IsTerminal;

    }

    private Vertex Root;
    
    private int SizeOfTrie;

    public Trie()
    {
        this.Root = new Vertex(0, false);
        this.SizeOfTrie = 0;
    }

    public int Size()
    {
        return 0;
    }

    private void CountTerminalVertices(Vertex vertex)
    {
        
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
    
    public bool Add(string element)
    {
        var isAdded =  AddToVertex(this.Root, element, 0);
        if (isAdded)
        {
            ++this.SizeOfTrie;
        }

        return isAdded;
    }

    public bool Contains(string element)
    {
        return true;
    }
    
    private Tuple<bool, bool> RemoveFromVertex(Vertex vertex, string element, int position)
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
            try
            {
                var isdDeleted = RemoveFromVertex(vertex.NextVertices[element[position]], element, position + 1);
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
            }
            catch
            {
                return new Tuple<bool, bool>(false, false);
            }
            return new Tuple<bool, bool>(false, false);
        }
        
        return new Tuple<bool, bool>(false, false);
    }

    public bool Remove(string element)
    {
        var isDeleted =  RemoveFromVertex(this.Root, element, 0);
        if (isDeleted.Item1)
        {
            --this.SizeOfTrie;
        }
        return isDeleted.Item1;
    }

    public int HowManyStartsWithPrefix(String prefix)
    {
        return 0;
    }
}