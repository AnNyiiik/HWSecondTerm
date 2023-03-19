using System.Collections.Specialized;

namespace UniqueList;

public class UniqueList<T> : MyList<T>
{
    private Dictionary<T, bool> values;

    public UniqueList()
    {
        values = new Dictionary<T, bool>();
    }

    public void Add(T value, int position)
    {
        if (values.ContainsKey(value))
        {
            throw new AddExistingElementToUniqueListException();
        }
        
        base.Add(value, position); 
        values.Add(value, true);
    }

    public void Delete(int position)
    {
        var value = base.Delete(position);
        values.Remove(value);
    }

    public void Change(T value, int position)
    {
        if (values.ContainsKey(value))
        {
            throw new AddExistingElementToUniqueListException();
        }
        var oldValue = base.Change(value, position);
        values.Remove(oldValue);
        values.Add(value, true);
    }

}