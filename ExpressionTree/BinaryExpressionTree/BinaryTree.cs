using System.Text;

namespace ExpressionTree;

public class BinaryExpressionTree
{
    private readonly INode _root; 

    private readonly BinaryExpressionTree? _leftTree;

    private readonly BinaryExpressionTree? _rightTree;
    
    private const int BracketPosition = 0;

    private const int OperationPosition = 1;
    
    private const int SpacePosition = 2;

    private const int FirstOperandStartPosition = 3;

    private bool IsCorrectBracketBalance(string expression)
    {
        var count = 0;
        foreach (var character in expression)
        {
            if (character == ')')
            {
                --count;
            }

            if (character == '(')
            {
                ++count;
            }

            if (count < 0)
            {
                return false;
            }
        }

        return count == 0;
    }
    
    public BinaryExpressionTree(string expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException();
        }  
        if (expression.Length == 0)
        {
            throw new ArgumentException("operand is zero-length");
        }

        if (!IsCorrectBracketBalance(expression))
        {
            throw new ArgumentException("incorrect sequence");
        }
        if (expression[BracketPosition] != '(')
        {
            var isNumber = Int32.TryParse(expression, out var value);
            if (isNumber)
            {
                _root = new Operand(value);
            }
            else
            {
                throw new ArgumentException("a subsequence which should be an operand is not a number");
            }
        }
        else if (expression[BracketPosition] == '(')
        {
            var operands = ParseOperands(expression);
            _root = operands.Item1 switch
            {
                '+' => new Addition(),
                '-' => new Subtraction(),
                '*' => new Multiplication(),
                '/' => new Division(),
                _ => throw new ArgumentException("incorrect expression")
            };
            _leftTree = new BinaryExpressionTree(operands.Item2);
            _rightTree = new BinaryExpressionTree(operands.Item3);
            if (_root is Operation)
            {
                ((Operation)_root).Left = _leftTree._root;
                ((Operation)_root).Right = _rightTree._root;
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

        if (expression[SpacePosition] != ' ')
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

    private (char operation, string operandLeft, string operandRight) ParseOperands(string expression)
    {
        var operation = expression[OperationPosition];
        if (operation != '+' && operation != '-' && operation != '/' && operation != '*')
        {
            throw new ArgumentException("incorrect expression");
        }
        var index = FirstOperandStartPosition;
        var left = ParseOperand(expression, ref index);
        ++index;
        var right = ParseOperand(expression, ref index);
        if (expression[index] != ')')
        {
            throw new ArgumentException("incorrect expression");
        }
        return (operation, left, right);
    }

    public double CountExpression()
    {
        return _root.Count();
    }
    
    public void PrintExpression(bool isFirst, ref StringBuilder result)
    {
        if (_leftTree != null && _rightTree != null) {
            result.Append('(');
            result.Append(_root.Print());
            result.Append(' ');
            _leftTree.PrintExpression(true, ref result);
            _rightTree.PrintExpression(false, ref result);
            if (isFirst) {
                result.Append(") ");
            } else {
                result.Append(')');
            }
        } else {
            if (isFirst) {
                result.Append(_root.Print());
                result.Append(' ');
            } else {
                result.Append(_root.Print());
            }
        }
    }
}