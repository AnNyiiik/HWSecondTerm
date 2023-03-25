using System.Text;

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

    public void PrintOperand(ref StringBuilder buffer)
    {
        buffer.Append(value);
    }
}