namespace UniqueList;

public class MyList<T> where T : IComparable<T>
{
    
    private class ListElement
    {
        public ListElement(T value)
        {
            this._value = value;
            Next = _next;
        }
        private T _value;

        public T Value
        {
            get => _value;
            set => this._value = value;
        }

        private ListElement? _next;

        public ListElement? Next { get; set; }
    }

    private ListElement? _head;

    private int _size;

    public int Size { get; set; }

    /// <summary>
    /// Add a new element to the list by position and define its value. If the position is out of the range throws
    /// ArgumentException.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <exception cref="ArgumentException"></exception>
    public void Add(T value, int position)
    {
        if (position > _size && position != 0 || position < 0)
        {
            throw new ArgumentException();
        }
        if (_head == null)
        {
            _head = new ListElement(value);
            ++_size;
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
        ++_size;
    }

    /// <summary>
    /// Delete an element from list by given position. If the position is out of the range throws
    /// DeleteOrChangeNonExistingElementException.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="DeleteOrChangeNonExistingElementException"></exception>
    public T Delete(int position)
    {
        if (position >= _size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }

        T value;
        
        if (position == 0)
        {
            value = _head.Value;
            _head = _head.Next;
            --_size;
            return value;
        }
        var element = _head;
        for (var i = 1; i < position; ++i)
        {
            element = element?.Next;
        }
        
        value = element.Next.Value;
        element.Next = element.Next?.Next ?? null;
        --_size;
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
    public T Change(T value, int position)
    {
        if (position >= _size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }
        var element = _head;
        for (var i = 0; i < position; ++i)
        {
            element = element?.Next;
        }
        T oldValue = element.Value;
        element.Value = value;
        return oldValue;
    }
    
    /// <summary>
    /// Return a first position of the given value in the list. If there is no element with given value return -1.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>

    public int GetFirstCoincide(T value)
    {
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

        return -1;
    }

    /// <summary>
    /// Return a value of the element by its position. If the position is out of the range throws ArgumentException.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public T GetValueByPosition(int position)
    {
        if (position >= _size || position < 0)
        {
            throw new ArgumentException();
        }
        var element = _head;
        for (var i = 0; i < position; ++i)
        {
            element = element?.Next;
        }
        
        return element.Value;
    }
}