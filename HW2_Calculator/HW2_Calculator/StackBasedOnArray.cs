namespace HW2_Calculator;

public class StackBasedOnArray : IStack
{
    private StackElement? head;

    private StackElement[] stack;

    public int Size() => stack.GetLength(0);

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
            set => this.value = value;
        }

        public StackElement? Next
        {
            get => next;
        }
    }

    public StackBasedOnArray()
    {
        stack = Array.Empty<StackElement>();
    }
    
    public void Push(double element)
    {
        var length = stack.GetLength(0);
        if (length == 0)
        {
            head = new StackElement(element);
            Array.Resize(ref stack, length + 1);
            stack[length] = head;
            return;
        }
        head = new StackElement(element, head);
        Array.Resize(ref stack, length + 1);
        stack[length] = head;
    }

    public double? Pop()
    {
        var length = stack.GetLength(0);
        var value = head?.Value;
        head = head == null ? head : head?.Next;
        if (length > 0)
        {
            Array.Resize(ref stack, length - 1);
        }
        return value;
    }

    public void Clear()
    {
        stack = Array.Empty<StackElement>();
        head = null;
    }
}