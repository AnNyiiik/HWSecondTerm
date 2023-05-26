namespace ExpressionTree;

public class Operation
{
    public enum Operations
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    private Operand left;
    private Operand right;
    public string Value { get; }

    private Operations operation;

    public Operation(Operations operation, Operand right, Operand left)
    {
        this.operation = operation;
        this.left = left;
        this.right = right;
        switch (operation)
        {
            case Operations.Add:
                Value = "+";
                break;
            case Operations.Subtract:
                Value = "-";
                break;
            case Operations.Multiply:
                Value = "*";
                break;
            case Operations.Divide:
                Value = "/";
                break;
            default:
                throw new ArgumentException();
        }
    }

    public static Operations? GetOperationType(char operation)
    {
        switch (operation)
        {
            case '+':
                return Operations.Add;
            
            case '-':
                return Operations.Subtract;
            
            case '*':
                return Operations.Multiply;
            
            case '/':
                return Operations.Divide;
            
            default:
                throw new ArgumentException();
        }
    }

    public Operand DoOperation(Operand first, Operand second)
    {
        switch (operation)
        {
            case Operations.Add:
                return new Operand(first.Value + second.Value);
            case Operations.Subtract:
                return new Operand(first.Value - second.Value);
            case Operations.Multiply:
                return new Operand(first.Value * second.Value);
            case Operations.Divide:
                if (Math.Abs(second.Value) < 0.0000001)
                {
                    throw new DivideByZeroException();
                } 
                return new Operand(first.Value / second.Value); 
            default:
                throw new ArgumentException();
        }
    }

    public string PrintOperation()
    {
        var value = operation switch
        {
            Operations.Add => "+",
            Operations.Subtract => "-",
            Operations.Multiply => "*",
            Operations.Divide => "/",
        };
        return value;
    }
}