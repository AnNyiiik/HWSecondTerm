namespace ExpressionTree;

public abstract class Operation : INode
{
    public INode? Left { get; set; }
    public INode? Right { get; set; }

    public virtual string Print()
    {
        Left?.Print();
        Right?.Print();
        return String.Empty;
    }

    public abstract double Count();
}