namespace HW2_Calculator;

public interface IStack
{
    public Tuple<bool, double> Calculate(string expression);
}