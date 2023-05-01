namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private List<Node> _topLevel;

    private List<List<Node>> _levels;

    private class Node
    {
        public Node(Node? down, T? value)
        {
            Down = down;
            Value = value;
        }
        public Node? Down { get; set; }
        
        public T? Value { get; set; }
    }

    public SkipList(List<T> list)
    {
        list.Sort();
        _topLevel = new List<Node>();
        _levels = new List<List<Node>>();
        _levels.Add(_topLevel);
        foreach (var item in list)
        {
            _topLevel.Add(new Node(null, item));
        }

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
        if (level.Count < 2)
        {
            return null;
        }

        var newLevel = new List<Node>();

        for (var i = 1; i < level.Count; i += 2)
        {
            newLevel.Add(new Node(level[i], level[i].Value));
        }

        return newLevel;
    }

    public bool FindValue(T value)
    {
        if (_levels[0][0].Value?.CompareTo(value) > 0 || _levels[0][_levels[0].Count - 1].Value?.CompareTo(value) < 0)
        {
            return false;
        }
    
        return Find(_topLevel[0], _levels.Count - 1, 0, value);
    }

    private bool Find(Node? currentNode, int currentLevel, int index, T value)
    {
        if (currentNode == null)
        {
            return false;
        }
        while (currentNode.Value?.CompareTo(value) <= 0 && index < _levels[currentLevel].Count)
        {
            if (currentNode.Value?.CompareTo(value) == 0)
            {
                return true;
            }

            if (index + 1 == _levels[currentLevel].Count || index + 1 < _levels[currentLevel].Count && _levels[currentLevel][index + 1].Value?.CompareTo(value) > 0)
            {
                if (currentNode.Down == null)
                {
                    return false;
                }
                return Find(currentNode.Down, currentLevel - 1, 
                        _levels[currentLevel - 1].IndexOf(currentNode.Down), value);
            }
            
            currentNode = _levels[currentLevel][index + 1];
            ++index;
        }

        if (currentLevel == 0)
        {
            return false;
        }
        
        return Find(_levels[currentLevel - 1][0], --currentLevel, 0, value);
    }
}