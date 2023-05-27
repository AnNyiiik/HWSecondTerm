namespace ExpressionTree;

public class Multiplication : Operation
{
    public override double Count()
    {
        if (Left == null || Right == null)
        {
            throw new InvalidOperationException();
        }
        
        return Left.Count() * Right.Count();
    }

    public override string Print()
    {
        Console.Write("(");
        Console.Write("* ");
        base.Print();
        Console.Write(") ");
        return "*";
    }
}