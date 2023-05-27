namespace UniqueList;

public class UniqueList<T> : MyList<T> where T : IComparable<T>
{
    new public void Add(T value, int position)
    {
        if (GetFirstCoincide(value) != -1)
        {
            throw new AddExistingElementToUniqueListException();
        }
        
        base.Add(value, position); 
        
    }

    new public void Delete(int position)
    {
        base.Delete(position);
    }

    new public void Change(T value, int position)
    {
        var index = GetFirstCoincide(value);
        if (index != -1 && index != position)
        {
            throw new AddExistingElementToUniqueListException();
        }

        base.Change(value, position);
    }
}