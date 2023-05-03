using System.Collections;

namespace SkipList;

public class SkipList<T> : IList<T> where T : IComparable
{
    private List<Node> _topLevel;

    private readonly List<List<Node>> _levels;

    private int _state;

    protected class Node
    {
        public Node(Node? down, Node? next, T value)
        {
            Down = down;
            Next = next;
            Value = value;
        }
        public Node? Down { get; set; }
        
        public Node? Next { get; set; }
        
        public T Value { get; set; }
    }

    public SkipList()
    {
        _topLevel = new List<Node>();
        _levels = new List<List<Node>>();
        _levels.Add(_topLevel);
    }

    public SkipList(List<T> list)
    {
        list.Sort();
        _topLevel = new List<Node>();
        _levels = new List<List<Node>>();
        _levels.Add(_topLevel);
        for (int i = list.Count - 1; i >= 0; --i)
        {
            Node? next = _topLevel.Count == 0 ? null : _topLevel[0];
            _topLevel.Insert(0,new Node(null, next, list[i]));
        }
        _topLevel.Insert(0, new Node(null, _topLevel[0], _topLevel[0].Value));
        var newLevel = MakeNewLevel(_topLevel);
        while (newLevel != null)
        {
            _topLevel = newLevel;
            _levels.Add(newLevel);
            newLevel = MakeNewLevel(newLevel);
        }
    }
    
    /// <summary>
    /// Creates new upper-level of the given one.
    /// </summary>
    private List<Node>? MakeNewLevel(List<Node> level)
    {
        if (level.Count <= 2)
        {
            return null;
        }

        var newLevel = new List<Node>();

        for (var i = level.Count - 1 - (level.Count - 1) % 2; i >= 1; i -= 2)
        {
            Node? next = newLevel.Count == 0 ? null : newLevel[0];
            newLevel.Insert(0, new Node(level[i], next, level[i].Value));
        }
        newLevel.Insert(0, new Node(level[0], newLevel[0], newLevel[0].Value));
        return newLevel;
    }

    public void Clear()
    {
        ++_state;
        foreach (var level in _levels)
        {
            level.Clear();
        }
        _levels.Clear();
    }

    public bool Contains(T value)
    {
        if (Count == 0)
        {
            return false;
        }
        if (_levels[0][1].Value.CompareTo(value) > 0 || _levels[0][_levels[0].Count - 1].Value.CompareTo(value) < 0)
        {
            return false;
        }
    
        return Find(_topLevel[1], _levels.Count - 1, value);
    }

    public void CopyTo(T[] array, int indexOfFirstCopiedElement)
    {
        if (_levels.Count == 0 && indexOfFirstCopiedElement >= 0)
        {
            throw new ArgumentException("Incorrect index");
        } 
        if (_levels.Count > 0 && indexOfFirstCopiedElement >= _levels[0].Count)
        {
            throw new ArgumentException("Incorrect index");
        }

        var index = indexOfFirstCopiedElement + 1;
        while (index - indexOfFirstCopiedElement - 1 < array.Length)
        {
            array[index - indexOfFirstCopiedElement - 1] = _levels[0][index].Value;
            ++index;
        }
    }
    
    public int Count
    {
        get => _levels.Count == 0 ? 0 : _levels[0].Count - 1;
    }
    
    public bool IsReadOnly
    {
        get => false;
    }
    
    
    /// <summary>
    /// Finds a node with given value recursively.
    /// </summary>
    /// <returns>true, if it was found</returns>
    private bool Find(Node? currentNode, int currentLevel, T value)
    {
        if (currentNode == null)
        {
            return false;
        }
        while (currentNode?.Value.CompareTo(value) <= 0 && currentNode.Next != null)
        {
            if (currentNode.Value.CompareTo(value) == 0)
            {
                return true;
            }

            if (currentNode.Next.Value.CompareTo(value) > 0)
            {
                if (currentNode.Down == null)
                {
                    return false;
                }
                return Find(currentNode.Down, currentLevel - 1, value);
            }
            
            currentNode = currentNode.Next;
        }

        if (currentNode?.Down == null)
        {
            if (currentNode?.Value.CompareTo(value) == 0)
            {
                return true;
            }
            return false;
        }
        
        return Find(_levels[currentLevel - 1][1], currentLevel - 1, value);
    }

    public void Add(T value)
    {
        ++_state;
        if (_topLevel.Count == 0)
        {
            _topLevel.Add(new Node(null, null, value));
            _topLevel.Insert(0,new Node(null, _topLevel[0], value));
            return;
        }
        var randomizer = new Random();
        var newNode = InsertNode(_topLevel[0], value, randomizer);
        if (newNode != null)
        {
            _topLevel = new List<Node> { newNode };
            _topLevel.Insert(0,new Node(null, _topLevel[0], value));
            _levels.Add(_topLevel);
        }
    }

    /// <summary>
    /// Inserts new node to the skip list recursively after given node.
    /// </summary>
    /// <param name="currentNode">Node after which we insert a new one.</param>
    /// <param name="value">value of the new node</param>
    /// <param name="randomizer">to define whether we add new value to the upper level or not</param>
    /// <returns>node, which were added to the skip list at the down level</returns>
    private Node? InsertNode(Node currentNode, T value, Random randomizer)
    {
        while (currentNode.Next != null && currentNode.Next?.Value.CompareTo(value) < 0)
        {
            currentNode = currentNode.Next;
        }
        
        Node? downNode = null;
        
        if (currentNode.Down != null)
        {
            downNode = InsertNode(currentNode.Down, value, randomizer);
        }

        if (currentNode.Down == null || downNode != null)
        {
            currentNode.Next = new Node(downNode, currentNode.Next, value);
            if (randomizer.Next() % 2 == 0)
            {
                return currentNode.Next;
            }

            return null;
        }

        return null;
    }

    public bool Remove(T value)
    {
        ++_state;
        var result = DeleteValue(_topLevel[0], value, _levels.Count - 1);
        if (_topLevel.Count == 1)
        {
            _levels.Remove(_topLevel);
            _topLevel = (_levels.Count == 0) ? new List<Node> () : _levels[_levels.Count - 1];
        }

        return result;
    }

    public void RemoveAt(int index)
    {
        if (_levels.Count == 0)
        {
            return;
        }
        for(var i = _levels.Count - 1; i >= 0; --i)
        {
            if (index > _levels[i].Count - 1)
            {
                index -= _levels[i].Count - 1;
            }
            else
            {
                _levels[i][index].Next = _levels[i][index + 1].Next;
                _levels[i].RemoveAt(index + 1);
            }
        }
    }

    public int IndexOf(T value)
    {
        if (_levels.Count == 0)
        {
            return -1;
        }

        var index = 0;
        for (var i = _levels.Count - 1; i >= 0; --i)
        {
            for (var j = 1; j < _levels[i].Count; ++j)
            {
                if (_levels[i][j].Value.CompareTo(value) == 0)
                {
                    return index;
                }

                ++index;
            }
        }

        return -1;
    }

    public T this[int index]
    {
        get
        {
            if (_levels.Count == 0)
            {
                throw new ArgumentException("empty list");
            }
            
            for(var i = _levels.Count - 1; i >= 0; --i)
            {
                if (index > _levels[i].Count - 1)
                {
                    index -= _levels[i].Count - 1;
                }
                else
                {
                    return _levels[i][index + 1].Value;
                }
            }

            throw new ArgumentException("index out of bounds");

        }
        set
        {
            throw new NotImplementedException();
        } 
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new NodeEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Enumerator for nodes in the skipList, iterates over levels from the peak to the bottom.
    /// </summary>
    public class NodeEnumerator : IEnumerator<T>
    {
        private SkipList<T> _skipList;

        private int _state;

        public NodeEnumerator(SkipList<T> list)
        {
            _skipList = list;
            _state = list._state;
            _indexLevel = _skipList._levels.Count - 1;
        }

        private int _indexLevel;

        private int _index;
        
        public bool MoveNext()
        {
            if (_state != _skipList._state)
            {
                throw new InvalidOperationException();
            }
            if (_skipList.Count == 0)
            {
                return false;
            }

            if (_skipList._levels[_indexLevel].Count - 1 > _index)
            {
                ++_index;
                return true;
            }
            
            _index = 0;
            --_indexLevel;
            return _indexLevel >= 0;
            
        }

        public void Reset()
        {
            _index = 0;
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public T Current
        {
            get
            {
                try
                {
                    return _skipList._levels[_indexLevel][_index].Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose() { }
    }

    public void Insert(int index, T value)
    {
        throw new NotImplementedException();
    }
    
    
    /// <summary>
    /// Delete given value recursively, if it exists.
    /// </summary>
    /// <param name="currentNode">start Node, from which we seek value</param>
    /// <param name="value">value to delete</param>
    /// <returns>true, if the value has been deleted</returns>
    private bool DeleteValue(Node currentNode, T value, int currentLevel)
    {
        while (currentNode.Next != null && currentNode.Next?.Value.CompareTo(value) < 0)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode.Down != null)
        {
            return DeleteValue(currentNode.Down, value, currentLevel - 1);
        }

        if (currentNode.Next != null && currentNode.Next.Value.CompareTo(value) == 0)
        {
            _levels[currentLevel].Remove(currentNode.Next);
            currentNode.Next = currentNode.Next.Next;
            return true;
        }

        return false;
    }
}