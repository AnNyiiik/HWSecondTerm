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

    public Tuple<bool, double?> Calculate(string expression)
    {
        if (expression.Length == 0)
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
                if (operandFirst == null || operandSecond == null)
                {
                    return new Tuple<bool, double?>(false, null);
                }
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
        if (_stack.Size() != 1)
        {
            return new Tuple<bool, double?>(false, null);
        }
        return new Tuple<bool, double?>(true, _stack.Pop());
    }
}