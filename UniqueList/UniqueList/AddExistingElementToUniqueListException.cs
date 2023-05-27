namespace UniqueList;

public class AddExistingElementToUniqueListException : Exception
{
    public AddExistingElementToUniqueListException()
    {
    }
    
    public AddExistingElementToUniqueListException(string message)
        :base(message)
    {
    }
}