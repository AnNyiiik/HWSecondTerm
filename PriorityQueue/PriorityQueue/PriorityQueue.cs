namespace PriorityQueue;

public class PriorityQueue
{
    private List<QueueElement> _queue;

    private int INIT_Size;
    
    /// <summary>
    /// An element of the queue which stores its value and priority.
    /// </summary>
    private class QueueElement
    {
        private char _value;
        private int _priority;

        public QueueElement(char value, int priority)
        {
            _value = value;
            _priority = priority;
            Value = _value;
            Priority = _priority;
        }
        
        public char Value { get; }
        
        public int Priority { get; }
    }

    public PriorityQueue()
    {
        _queue = new List<QueueElement>();
    }
    
    /// <summary>
    /// Add a new queue element in queue by its priority.
    /// </summary>
    public void Enqueue(char value, int priority)
    {
        if (_queue.Count == 0)
        {
            _queue.Add(new QueueElement(value, priority));
            return;
        }

        int index = 0;
        while (index < _queue.Count && _queue[index].Priority >= priority)
        {
            ++index;
        }
        _queue.Insert(index,new QueueElement(value, priority));
    }

    /// <summary>
    /// Returns a value of an element with the biggest priority.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="EmptyQueueException">This exception is thrown if Dequeue for an empty queue is called.</exception>
    public char Dequeue()
    {
        if (Empty())
        {
            throw new EmptyQueueException("the queue is empty, there is nothing to dequeue");
        }

        var returnValue = _queue[0].Value;
        _queue.RemoveAt(0);
        return returnValue;
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns></returns>
    public bool Empty()
    {
        return _queue.Count == 0;
    }
}