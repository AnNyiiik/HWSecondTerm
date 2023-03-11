namespace HW2_Calculator;

public class StackBasedOnArray : IStack
{
    private static readonly double Delta = 0.00001;
    Tuple<bool, double> IStack.Calculate(string expression)
    {
        if (expression.Length == 0)
        {
            return new Tuple<bool, double>(false, 0);
        }
        var parsedOperands = expression.Split(' ');
        var stack = Array.Empty<double>();
        foreach (var operand in parsedOperands)
        {
            var isNumber = int.TryParse(operand, out var number);
            if (isNumber)
            {
                var size = stack.GetLength(0);
                Array.Resize(ref stack, size + 1);
                stack[size] = number;
            }
            else
            {
                var size = stack.GetLength(0);
                if (size < 2)
                {
                    return new Tuple<bool, double>(false, 0);
                }
                switch (operand)
                {
                    case "+":
                        var sum = stack[size - 1] + stack[size - 2];
                        Array.Resize(ref stack, size - 1);
                        stack[size - 2] = sum;
                        break;
                    case "-":
                        var difference = stack[size - 2] - stack[size - 1];
                        Array.Resize(ref stack, size - 1);
                        stack[size - 2] = difference;
                        break;
                    case "*":
                        var product = stack[size - 1] * stack[size - 2];
                        Array.Resize(ref stack, size - 1);
                        stack[size - 2] = product;
                        break;
                    case "/":
                        if (Math.Abs(stack[size - 1] - 0.0) < Delta)
                        {
                            return new Tuple<bool, double>(false, 0);
                        }
                        var quotient = stack[size - 2] / stack[size - 1];
                        Array.Resize(ref stack, size - 1);
                        stack[size - 2] = quotient;
                        break;
                    default:
                        return new Tuple<bool, double>(false, 0);
                }
            }
        }

        if (stack.GetLength(0) != 1)
        {
            return new Tuple<bool, double>(false, 0);
        }
        return new Tuple<bool, double>(true, stack[0]);
    }
}