namespace UniqueList;

public class MyList<T>
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
            element = element.Next;
        }
        
        value = element.Next.Value;
        element.Next = element.Next?.Next ?? null;
        --size;
        return value;
    }

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
}