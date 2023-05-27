namespace ExpressionTree;

public class Division : Operation
{
    public override double Count()
    {
        if (Left == null || Right == null)
        {
            throw new InvalidOperationException();
        }

        var rightValue = Right.Count();
        if (Math.Abs(rightValue) < 0.0001)
        {
            throw new DivideByZeroException();
        }

        return Left.Count() / rightValue;
    }

    public override string Print()
    {
        Console.Write("(");
        Console.Write("/ ");
        base.Print();
        Console.Write(") ");
        return "/";
    }
}