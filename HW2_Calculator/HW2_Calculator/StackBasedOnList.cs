namespace HW2_Calculator;

public class StackBasedOnList : IStack
{
    private readonly List<double> _stack;
    
    public StackBasedOnList()
    {
        _stack = new List<double>();
    }
    
    public void Push(double element)
    {
        _stack.Add(element);
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new AccessViolationException();
        }

        var last = _stack.Count - 1;
        var value = _stack[last];
        _stack.RemoveAt(_stack.Count - 1);
        return value;
    }

    public bool IsEmpty() => _stack.Count == 0;

    public void Clear()
    {
        _stack.Clear();
    }
}