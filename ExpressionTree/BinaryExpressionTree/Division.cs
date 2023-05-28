namespace ExpressionTree;

public class Division : Operation
{
    
    public Division(INode left, INode right) : base(left, right)
    {
        
    }
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

    protected override void PrintOperation()
    {
        Console.Write("/ ");
    }

    public override string Print()
    {
        Console.Write("(");
        base.Print();
        Console.Write(") ");
        return "/";
    }
}