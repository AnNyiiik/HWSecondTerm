using System;
using System.Data.SqlTypes;

namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private List<Node> _topLevel;

    private List<List<Node>> _levels;

    private class Node
    {
        public Node(Node? down, Node? next, T? value)
        {
            Down = down;
            Next = next;
            Value = value;
        }
        public Node? Down { get; set; }
        
        public Node? Next { get; set; }
        
        public T? Value { get; set; }
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

    public bool FindValue(T value)
    {
        if (_topLevel.Count == 0)
        {
            return false;
        }
        if (_levels[0][1].Value?.CompareTo(value) > 0 || _levels[0][_levels[0].Count - 1].Value?.CompareTo(value) < 0)
        {
            return false;
        }
    
        return Find(_topLevel[1], _levels.Count - 1, value);
    }

    private bool Find(Node? currentNode, int currentLevel, T value)
    {
        if (currentNode == null)
        {
            return false;
        }
        while (currentNode?.Value?.CompareTo(value) <= 0 && currentNode.Next != null)
        {
            if (currentNode.Value?.CompareTo(value) == 0)
            {
                return true;
            }

            if (currentNode.Next.Value?.CompareTo(value) > 0)
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
            if (currentNode?.Value?.CompareTo(value) == 0)
            {
                return true;
            }
            return false;
        }
        
        return Find(_levels[currentLevel - 1][1], currentLevel - 1, value);
    }

    public void Add(T value)
    {
        if (_topLevel.Count == 0)
        {
            _topLevel.Add(new Node(null, null, value));
            _topLevel.Insert(0,new Node(null, _topLevel[0], value));
            return;
        }
        var randomizer = new Random();
        var newNode = InsertNode(_topLevel[0], value, _levels.Count - 1, randomizer);
        if (newNode != null)
        {
            _topLevel = new List<Node> { newNode };
            _topLevel.Insert(0,new Node(null, _topLevel[0], value));
            _levels.Add(_topLevel);
        }
    }

    private Node? InsertNode(Node currentNode, T value, int currentLevel, Random randomizer)
    {
        while (currentNode.Next != null && currentNode.Next?.Value?.CompareTo(value) < 0)
        {
            currentNode = currentNode.Next;
        }
        
        Node? downNode = null;
        
        if (currentNode.Down != null)
        {
            downNode = InsertNode(currentNode.Down, value, currentLevel - 1, randomizer);
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

    public void Delete(T value)
    {
        DeleteValue(_topLevel[0], value, _levels.Count - 1);
        if (_topLevel.Count == 1)
        {
            _levels.Remove(_topLevel);
            _topLevel = (_levels.Count == 0) ? new List<Node> () : _levels[_levels.Count - 1];
        }
    }

    private void DeleteValue(Node currentNode, T value, int currentLevel)
    {
        while (currentNode.Next != null && currentNode.Next?.Value?.CompareTo(value) < 0)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode.Down != null)
        {
            DeleteValue(currentNode.Down, value, currentLevel - 1);
        }

        if (currentNode.Next != null && currentNode.Next.Value?.CompareTo(value) == 0)
        {
            var nodeToDelete = currentNode.Next;
            while (nodeToDelete != null && nodeToDelete.Value?.CompareTo(value) == 0)
            {
                _levels[currentLevel].Remove(nodeToDelete);
                currentNode.Next = nodeToDelete.Next;
                nodeToDelete = nodeToDelete.Next;
            }
        }
    }
}