namespace ExpressionTree;

public class Addition : Operation
{
    public Addition(INode left, INode right) : base(left, right)
    {
        
    }

    public override double Count()
    {
        if (Left == null || Right == null)
        {
            throw new InvalidOperationException();
        }
        
        return Left.Count() + Right.Count();
    }
    
    protected override void PrintOperation()
    {
        Console.Write("+ ");
    }

    public override string Print()
    {
        Console.Write("(");
        base.Print();
        Console.Write(") ");
        return "+";
    }
}