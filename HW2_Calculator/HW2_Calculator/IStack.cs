namespace HW2_Calculator;

public interface IStack
{
    public void Push(double value);

    public double Pop();

    public bool IsEmpty();

    public void Clear();
}