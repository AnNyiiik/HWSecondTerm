namespace UniqueList;

public class UniqueList<T> : MyList<T> where T : IComparable<T>
{
    /// <summary>
    /// Create and add an element to a list, if there is no such value in the list.
    /// </summary>
    /// <param name="value">the value of new element</param>
    /// <param name="position">by which position it should be placed</param>
    /// <exception cref="AddExistingElementToUniqueListException">Thrown, if it was
    /// an attempt to add an existing value.</exception>
    public override void Add(T value, int position)
    {
        try
        {
            GetFirstCoincide(value);
            throw new AddExistingElementToUniqueListException();
        }
        catch (ArgumentException)
        {
            base.Add(value, position);
        }
    }

    /// <summary>
    /// Delete an element by the position.
    /// </summary>
    /// <param name="position">position of the deleted element</param>
    /// <returns>value of the deleted element</returns>
    public override T Delete(int position)
    {
        var deleteValue = base.Delete(position);
        return deleteValue;
    }

    /// <summary>
    /// Change a value by the position in the list, if there is no such a value on the other position.
    /// </summary>
    /// <param name="value">new value</param>
    /// <param name="position">position of a replaced element</param>
    /// <exception cref="AddExistingElementToUniqueListException">Thrown, if it was an attempt
    /// to add an existing value</exception>
    public override void Change(T value, int position)
    {
        try
        {
            var index = GetFirstCoincide(value);
            if (index != -1 && index != position)
            {
                throw new AddExistingElementToUniqueListException();
            }
            base.Change(value, position);
        }
        catch(ArgumentException)
        {
            base.Change(value, position);
        }
    }
}