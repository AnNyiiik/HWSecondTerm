namespace HW2_Calculator;

public class StackBasedOnArray : IStack
{
    private double[] _stack;

    private int _capacity;

    private int _numberOfElements;

    public StackBasedOnArray()
    {
        _capacity = 2;
        _stack = new double[2];
    }
    
    public void Push(double element)
    {
        if (_numberOfElements < _capacity)
        {
            _stack[_numberOfElements] = element;
            ++_numberOfElements;
        }
        else
        {
            Array.Resize(ref _stack, _capacity * 2);
            _capacity *= 2;
            _stack[_numberOfElements] = element;
            ++_numberOfElements;
        }
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new AccessViolationException();
        }
        var value = _stack[_numberOfElements - 1];
        if (_numberOfElements * 2 < _capacity && _capacity != 2)
        {
            Array.Resize(ref _stack, _capacity / 2);
        }

        --_numberOfElements;
        return value;
    }
    
    public bool IsEmpty() => _numberOfElements == 0;

    public void Clear()
    {
        _numberOfElements = 0;
        _capacity = 2;
        _stack = new double[2];
    }
}