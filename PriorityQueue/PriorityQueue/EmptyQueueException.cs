namespace PriorityQueue;

public class EmptyQueueException : Exception
{
    public EmptyQueueException()
    {
    }
    
    public EmptyQueueException(string message)
        :base(message)
    {
    }
}