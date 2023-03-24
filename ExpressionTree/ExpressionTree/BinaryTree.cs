using System.Text;

namespace ExpressionTree;

public class BinaryExpressionTree 
{
    private Operation? rootOperation;

    private Operand? rootOperand;

    private BinaryExpressionTree? leftTree;

    private BinaryExpressionTree? rightTree;

    public BinaryExpressionTree (string expression)
    {
        if (expression[0] != '(')
        {
            var isNumber = Int32.TryParse(expression, out var value);
            if (isNumber)
            {
                rootOperand = new Operand(value);
            }
        }
        else
        {
            var operands = parseOperands(expression);
            if (operands.Item1 != null)
            {
                rootOperation = new Operation((Operation.Operations) operands.Item1);
                leftTree = new BinaryExpressionTree(operands.Item2);
                rightTree = new BinaryExpressionTree(operands.Item3);
            }
        }
    }
    
    private string ParseOperand(string expression, ref int index)
    {
        var character = expression[index];
        var operand = new StringBuilder();
        var start = index;
        if (character != '(') {
            while (character != ' ' && character != ')') {
                operand.Append(character);
                ++index;
                character = expression[index];
            }
        } else {
            var countBrackets = 1;
            while (countBrackets != 0) {
                character = expression[index];
                if (character == ')') {
                    --countBrackets;
                } else if (character == '(' && index != start) {
                    ++countBrackets;
                }
                operand.Append(character);
                ++index;
            }
        }

        return operand.ToString();
    }

    private Tuple<Operation.Operations?, string, string> parseOperands(string expression)
    {
        var operationType = Operation.GetOperationType(expression[1]);
        var index = 3;
        var left = ParseOperand(expression, ref index);
        ++index;
        var right = ParseOperand(expression, ref index);
        return new Tuple<Operation.Operations?, string, string>(operationType, left, right);
    }

    public void PrintExpression(bool isFirst)
    {
        if (leftTree != null && rightTree != null) {
            Console.Write("(");
            rootOperation?.PrintOperation();
            Console.Write(" ");
            leftTree.PrintExpression(true);
            rightTree.PrintExpression(false);
            if (isFirst) {
                Console.Write(") ");
            } else {
                Console.Write(")");
            }
        } else {
            if (isFirst) {
                rootOperand?.PrintOperand();
                Console.Write(" ");
            } else {
                rootOperand?.PrintOperand();
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
        return rootOperation.DoOperation(operandFirst, operandSecond);
    }

    public double? Count()
    {
        return CountExpression()?.Value;
    }

}