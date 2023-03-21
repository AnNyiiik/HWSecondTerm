namespace UniqueList;

public class MyList<T> where T : IComparable<T>
{
    
    private class ListElement
    {
        public ListElement(T value)
        {
            this.value = value;
        }
        private T value;

        public T Value
        {
            get => value;
            set => this.value = value;
        }

        private ListElement? next;

        public ListElement Next
        {
            get => next;
            set => next = value;
        }
    }

    private ListElement? head;

    private int size;

    public int Size
    {
        get => size;
        set => size = value;
    }

    /// <summary>
    /// Add a new element to the list by position and define its value. If the position is out of the range throws
    /// ArgumentException.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <exception cref="ArgumentException"></exception>
    public void Add(T value, int position)
    {
        if (position > size && position != 0 || position < 0)
        {
            throw new ArgumentException();
        }
        if (head == null)
        {
            head = new ListElement(value);
            ++size;
            return;
        }

        var element = head;
        for (var i = 1; i < position; ++i)
        {
            element = element.Next;
        }
        var newElement = new ListElement(value);
        newElement.Next = element.Next;
        element.Next = newElement;
        ++size;
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
        if (position >= size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }

        T value;
        
        if (position == 0)
        {
            value = head.Value;
            head = head.Next;
            --size;
            return value;
        }
        var element = head;
        for (var i = 1; i < position; ++i)
        {
            element = element?.Next;
        }
        
        value = element.Next.Value;
        element.Next = element.Next?.Next ?? null;
        --size;
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
        if (position >= size || position < 0)
        {
            throw new DeleteOrChangeNonExistingElementException();
        }
        var element = head;
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
        var element = head;
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
        if (position >= size || position < 0)
        {
            throw new ArgumentException();
        }
        var element = head;
        for (var i = 0; i < position; ++i)
        {
            element = element?.Next;
        }
        
        return element.Value;
    }
}