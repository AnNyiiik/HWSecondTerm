namespace HW2_Calculator;

public class StackBasedOnList : IStack
{
    private List<double> stack;
    
    public StackBasedOnList()
    {
        stack = new List<double>();
    }
    
    public void Push(double element)
    {
        stack.Add(element);
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new AccessViolationException();
        }

        var last = stack.Count - 1;
        var value = stack[last];
        stack.RemoveAt(stack.Count - 1);
        return value;
    }

    public bool IsEmpty() => stack.Count == 0;

    public void Clear()
    {
        stack.Clear();
    }
}