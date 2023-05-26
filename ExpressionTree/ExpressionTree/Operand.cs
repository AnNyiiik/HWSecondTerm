namespace ExpressionTree;

public class Operand
{ 
    public Operand(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public string PrintOperand()
    {
        return Value.ToString();
    }
}