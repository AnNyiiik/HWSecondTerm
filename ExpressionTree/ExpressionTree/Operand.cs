namespace ExpressionTree;

public class Operand
{
    private double value;

    public Operand(double value)
    {
        this.value = value;
    }

    public double Value
    {
        set => this.value = value;
        get => value;
    }

    public void PrintOperand()
    {
        Console.Write(value);
    }
}