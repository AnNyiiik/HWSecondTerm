using System;

namespace HW2_Calculator;

public class StackBasedOnList : IStack
{
    private static double delta = 0.00001;
    Tuple<bool, double> IStack.Calculate(string expression)
    {
        if (expression.Length == 0)
        {
            return new Tuple<bool, double>(false, 0);
        }
        var parsedOperands = expression.Split(' ');
        var stack = new List<double>();
        foreach (var operand in parsedOperands)
        {
            var isNumber = int.TryParse(operand.ToString(), out var number);
            if (isNumber)
            {
                stack.Add(number);
            }
            else
            {
                var size = stack.Count;
                if (size < 2)
                {
                    return new Tuple<bool, double>(false, 0);
                }
                switch (operand)
                {
                    case "+":
                        var sum = stack[size - 1] + stack[size - 2];
                        stack.RemoveRange(size - 2, 2);
                        stack.Add(sum);
                        break;
                    case "-":
                        var difference = stack[size - 2] - stack[size - 1];
                        stack.RemoveRange(size - 2, 2);
                        stack.Add(difference);
                        break;
                    case "*":
                        var product = stack[size - 1] * stack[size - 2];
                        stack.RemoveRange(size - 2, 2);
                        stack.Add(product);
                        break;
                    case "/":
                        if (Math.Abs(stack[size - 1] - 0.0) < delta)
                        {
                            return new Tuple<bool, double>(false, 0);
                        }
                        var quotient = stack[size - 2] / stack[size - 1];
                        stack.RemoveRange(size - 2, 2);
                        stack.Add(quotient);
                        break;
                    default:
                        return new Tuple<bool, double>(false, 0);
                }
            }
        }

        if (stack.Count != 1)
        {
            return new Tuple<bool, double>(false, 0);
        }
        return new Tuple<bool, double>(true, stack[0]);;
    }
}