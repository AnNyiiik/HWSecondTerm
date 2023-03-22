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

    private string value;

    public string Value
    {
        get => value;
        set => this.value = value;
    }

    private Operations operation;

    public Operation(Operations operation)
    {
        this.operation = operation;
        switch (operation)
        {
            case Operations.Add:
                value = "+";
                break;
            case Operations.Subtract:
                value = "-";
                break;
            case Operations.Multiply:
                value = "*";
                break;
            case Operations.Divide:
                value = "/";
                break;
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
                return null;
        }
    }

    public Operand? DoOperation(Operand first, Operand second)
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
                    throw new ArgumentException();
                } 
                return new Operand(first.Value / second.Value); 
            default:
                return null;
        }
    }

    public void PrintOperation()
    {
        Console.Write(value);
    }
}