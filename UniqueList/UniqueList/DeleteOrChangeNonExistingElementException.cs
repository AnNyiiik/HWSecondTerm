namespace UniqueList;

public class DeleteOrChangeNonExistingElementException : Exception
{
    public DeleteOrChangeNonExistingElementException()
    {
    }
    
    public DeleteOrChangeNonExistingElementException(string message)
    : base(message)
    {
    }
}