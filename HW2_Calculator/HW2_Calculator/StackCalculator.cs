namespace HW2_Calculator;

public class StackCalculator
{
    private IStack stack;
    public StackCalculator(IStack stack)
    {
        this.stack = stack;
    }

    public Tuple<bool, double> Calculate(string expression)
    {
        return stack.Calculate(expression);
    }
}