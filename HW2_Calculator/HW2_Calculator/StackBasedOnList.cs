namespace HW2_Calculator;

public class StackBasedOnList : IStack
{
    private StackElement? head;

    private List<StackElement> stack;

    public int Size() => stack.Count;
    
    private class StackElement
    {
        private double value;

        private StackElement? next;
        
        public StackElement(double value)
        {
            this.next = null;
            this.value = value;
        }

        public StackElement(double value, StackElement? head)
        {
            this.next = head;
            this.value = value;
        }

        public double Value
        {
            get => value;
        }

        public StackElement? Next
        {
            get => next;
        }
    }

    public StackBasedOnList()
    {
        stack = new List<StackElement>();
    }
    
    public void Push(double element)
    {
        if (stack.Count == 0)
        {
            head = new StackElement(element);
            stack.Add(this.head);
            return;
        }

        head = new StackElement(element, this.head);
        stack.Add(head);
    }

    public double? Pop()
    {
        if (stack.Count == 0)
        {
            return null;
        }

        var value = head?.Value;
        head = head?.Next;
        stack.RemoveRange(stack.Count - 1, 1);
        return value;
    }
    
    public void Clear()
    {
        stack = new List<StackElement>();
        head = null;
    }
}