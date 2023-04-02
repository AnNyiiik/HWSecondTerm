namespace Lambdas;

public static class ListLambdas<T> 
{
    public static List<T> Map(ref List<T>? list, Func<T, T> lambdaExpression)
    {
        if (list == null)
        {
            throw new ArgumentNullException();
        }

        for (var i = 0; i < list.Count; ++i)
        {
            list[i] = lambdaExpression(list[i]);
        }

        return list;
    }

    public static List<T> Filter(List<T>? list, Func<T, bool> lambdaExpression)
    {
        if (list == null)
        {
            throw new ArgumentNullException();
        }

        var listFiltered = new List<T>();
        foreach (var item in list)
        {
            if (lambdaExpression(item))
            {
                listFiltered.Add(item);
            }
        }

        return listFiltered;
    }

    public static T Fold(List<T> list, T initialValue, Func<T, T, T> lambdaExpression)
    {
        if (list == null)
        {
            throw new ArgumentNullException();
        }
        
        var value = initialValue;
        foreach (var item in list)
        {
            value = lambdaExpression(value, item);
        }

        return value;
    }
}