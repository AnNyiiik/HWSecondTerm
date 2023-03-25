using System.Text;

namespace ExpressionTree;

public class BinaryExpressionTree 
{
    private readonly Operation? rootOperation;

    private readonly Operand? rootOperand;

    private readonly BinaryExpressionTree? leftTree;

    private readonly BinaryExpressionTree? rightTree;

    public BinaryExpressionTree (string? expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException();
        }  
        if (expression.Length == 0)
        {
            throw new ArgumentException("operand is zero-length");
        }
        
        if (expression[0] != '(')
        {
            var isNumber = Int32.TryParse(expression, out var value);
            if (isNumber)
            {
                rootOperand = new Operand(value);
            }
            else
            {
                throw new ArgumentException("a subsequence which should be an operand is not a number");
            }
        }
        else if (expression[0] == '(')
        {
            var operands = ParseOperands(expression);
            if (operands.Item1 != null)
            {
                rootOperation = new Operation((Operation.Operations) operands.Item1);
                leftTree = new BinaryExpressionTree(operands.Item2);
                rightTree = new BinaryExpressionTree(operands.Item3);
            }
        }
        else
        {
            throw new ArgumentException("incorrect expression");
        }
    }
    
    private string ParseOperand(string expression, ref int index)
    {
        if (expression.Length < index)
        {
            throw new ArgumentException("incorrect expression");
        }

        if (expression[2] != ' ')
        {
            throw new ArgumentException("incorrect expression");
        }
        var character = expression[index];
        var operand = new StringBuilder();
        var start = index;
        if (character != '(') {
            while (index < expression.Length && character != ' ' && character != ')') {
                operand.Append(character);
                ++index;
                if (index == expression.Length)
                {
                    throw new ArgumentException("incorrect expression");
                }
                character = expression[index];
            }
        } else {
            var countBrackets = 1;
            while (index < expression.Length && countBrackets != 0) {
                character = expression[index];
                if (character == ')') {
                    --countBrackets;
                } else if (character == '(' && index != start) {
                    ++countBrackets;
                }
                operand.Append(character);
                ++index;
            }

            if (countBrackets != 0)
            {
                throw new ArgumentException("incorrect expression");
            }
        }

        return operand.ToString();
    }

    private Tuple<Operation.Operations?, string, string> ParseOperands(string expression)
    {
        var operationType = Operation.GetOperationType(expression[1]);
        if (operationType == null)
        {
            throw new ArgumentException("incorrect expression");
        }
        var index = 3;
        var left = ParseOperand(expression, ref index);
        ++index;
        var right = ParseOperand(expression, ref index);
        if (expression[index] != ')')
        {
            throw new ArgumentException("incorrect expression");
        }
        return new Tuple<Operation.Operations?, string, string>(operationType, left, right);
    }

    public void PrintExpression(bool isFirst, ref StringBuilder result)
    {
        if (leftTree != null && rightTree != null) {
            result.Append('(');
            rootOperation?.PrintOperation(ref result);
            result.Append(' ');
            leftTree.PrintExpression(true, ref result);
            rightTree.PrintExpression(false, ref result);
            if (isFirst) {
                result.Append(") ");
            } else {
                result.Append(')');
            }
        } else {
            if (isFirst) {
                rootOperand?.PrintOperand(ref result);
                result.Append(' ');
            } else {
                rootOperand?.PrintOperand(ref result);
            }
        }
    }

    private Operand? CountExpression()
    {
        if (rootOperation == null) {
            return rootOperand;
        }
        var operandFirst = leftTree?.CountExpression();
        var operandSecond = rightTree?.CountExpression();
        if (operandFirst != null && operandSecond != null)
        {
            return rootOperation.DoOperation(operandFirst, operandSecond);
        }
        
        throw new ArgumentNullException();
    }

    public double? Count()
    {
        return CountExpression()?.Value;
    }

}