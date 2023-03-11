namespace HW2_Calculator;

public class StackCalculator
{
    private readonly IStack _stack;
    public StackCalculator(IStack stack)
    {
        this._stack = stack;
    }

    public Tuple<bool, double> Calculate(string expression)
    {
        return _stack.Calculate(expression);
    }
}