namespace ExpressionTree;

public abstract class Operation : INode
{
    public INode Left { get; }
    public INode Right { get; }

    public Operation(INode left, INode right)
    {
        Left = left;
        Right = right;
    }

    public virtual string Print()
    {
        PrintOperation();
        Left.Print();
        Right.Print();
        return String.Empty;
    }

    protected abstract void PrintOperation();

    public abstract double Count();
}