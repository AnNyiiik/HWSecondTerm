namespace UniqueList;

/// <summary>
/// Generic list, where type is comparable.
/// </summary>
/// <typeparam name="T">T is IComparable</typeparam>
public class MyList<T> where T : IComparable<T>
{
    
    private class ListElement
    {
        public ListElement(T value)
        {
            Value = value;
        }
        
        public T Value { get; set; }
        public ListElement? Next { get; set; }
    }

    private ListElement? _head;
    
    /// <summary>
    /// Return the current size of the list.
    /// </summary>
    public int Size { get; private set; }
    /// <summary>
    /// Add a new element to the list by position and define its value. If the position is out of the range throws
    /// ArgumentException.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <exception cref="ArgumentException"></exception>
    public virtual void Add(T value, int position)
    {
        if (position > Size || position < 0)
        {
            throw new ArgumentException();
        }
        if (_head == null)
        {
            _head = new ListElement(value);
            ++Size;
            return;
        }

        ListElement? element = _head;
        for (var i = 1; i < position; ++i)
        {
            element = element?.Next;
        }
        var newElement = new ListElement(value);
        newElement.Next = element?.Next;
        if (element != null)
        {
            element.Next = newElement;
        }
        ++Size;
    }

    /// <summary>
    /// Delete an element from list by given position. If the position is out of the range throws
    /// DeleteOrChangeNonExistingElementException.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="DeleteOrChangeNonExistingElementException"></exception>
    public virtual T Delete(int position)
    {
        if (position >= Size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }

        if (_head == null)
        {
            throw new InvalidOperationException();
        }

        T value;
        
        if (position == 0)
        {
            value = _head.Value;
            _head = _head.Next;
            --Size;
            return value;
        }
        var element = _head;
        for (var i = 1; i < position; ++i)
        {
            element = element?.Next;
        }
        if (element == null || element.Next == null)
        {
            throw new IndexOutOfRangeException();
        }
        value = element.Next.Value;
        element.Next = element.Next?.Next ?? null;
        --Size;
        return value;
    }

    /// <summary>
    /// Change an element value by given position. If the position is out of the range throws
    /// DeleteOrChangeNonExistingElementException.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="DeleteOrChangeNonExistingElementException"></exception>
    public virtual void Change(T value, int position)
    {
        if (value == null)
        {
            throw new NullReferenceException();
        }
        if (position >= Size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }
        var element = _head;
        for (var i = 0; i < position; ++i)
        {
            element = element?.Next;
        }
        if (element == null)
        {
            throw new IndexOutOfRangeException();
        }
        element.Value = value;
    }

    /// <summary>
    /// Return a first position of the given value in the list. If there is no element with given value return -1.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    protected int GetFirstCoincide(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("null value");
        }
        var element = _head;
        var position = 0;
        while (element != null)
        {
            if (element.Value.CompareTo(value) == 0)
            {
                return position;
            }

            ++position;
            element = element.Next;
        }

        throw new ArgumentException("There is not such a value");
    }

    /// <summary>
    /// Return a value of the element by its position. If the position is out of the range throws ArgumentException.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public T GetValueByPosition(int position)
    {
        if (position >= Size || position < 0)
        {
            throw new IndexOutOfRangeException();
        }
        var element = _head;
        for (var i = 0; i < position; ++i)
        {
            element = element?.Next;
        }

        if (element == null)
        {
            throw new IndexOutOfRangeException();
        }
        return element.Value;
    }
}