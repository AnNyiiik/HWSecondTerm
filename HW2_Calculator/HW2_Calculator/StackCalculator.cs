namespace HW2_Calculator;

public class StackCalculator
{
    private readonly IStack _stack;
    
    private static readonly double Delta = 0.00001;
    
    public StackCalculator(IStack stack)
    {
        _stack = stack;
    }

    public void Clear()
    {
        _stack.Clear();
    }

    public Tuple<bool, double?> Calculate(string? expression)
    {
        if (String.IsNullOrEmpty(expression))
        {
            return new Tuple<bool, double?>(false, null);
        }
        var parsedOperands = expression.Split();
        foreach (var operand in parsedOperands)
        {
            var isNumber = int.TryParse(operand, out var number);
            if (isNumber)
            {
                _stack.Push(number);
            }
            else
            {
                var operandFirst = _stack.Pop();
                var operandSecond = _stack.Pop();
                switch (operand)
                {
                    case "+":
                        var sum = operandFirst + operandSecond;
                        _stack.Push((int) sum);
                        break;
                    case "-":
                        var difference = operandSecond - operandFirst;
                        _stack.Push((int) difference);
                        break;
                    case "*":
                        var product = operandFirst * operandSecond;
                        _stack.Push((int) product);
                        break;
                    case "/":
                        if (Math.Abs((int)operandFirst) < Delta)
                        {
                            return new Tuple<bool, double?>(false, null);
                        }
                        var quotient = operandSecond / operandFirst;
                        _stack.Push((int)quotient);
                        break;
                    default:
                        return new Tuple<bool, double?>(false, null);
                }
            }
        }

        var result = _stack.Pop();
        if (!_stack.IsEmpty())
        {
            return new Tuple<bool, double?>(false, null);
        }
        return new Tuple<bool, double?>(true, result);
    }
}