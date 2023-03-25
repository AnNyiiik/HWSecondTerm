namespace HW2_Calculator;

public class StackBasedOnArray : IStack
{
    private double[] stack;

    private int Capacity;

    private int NumberOfElements;

    public StackBasedOnArray()
    {
        Capacity = 2;
        stack = new double[2];
    }
    
    public void Push(double element)
    {
        if (NumberOfElements < Capacity)
        {
            stack[NumberOfElements] = element;
            ++NumberOfElements;
        }
        else
        {
            Array.Resize(ref stack, Capacity * 2);
            Capacity *= 2;
            stack[NumberOfElements] = element;
            ++NumberOfElements;
        }
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new AccessViolationException();
        }
        var value = stack[NumberOfElements - 1];
        if (NumberOfElements * 2 < Capacity && Capacity != 2)
        {
            Array.Resize(ref stack, Capacity / 2);
        }

        --NumberOfElements;
        return value;
    }
    
    public bool IsEmpty() => NumberOfElements == 0;

    public void Clear()
    {
        NumberOfElements = 0;
        Capacity = 2;
        stack = new double[2];
    }
}