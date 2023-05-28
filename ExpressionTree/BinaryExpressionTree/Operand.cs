namespace ExpressionTree;

public class Operand : INode
{ 
    public Operand(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public string Print()
    {
        Console.Write(" {0} ", Value);
        return Value.ToString();
    }

    public double Count() => Value;
}