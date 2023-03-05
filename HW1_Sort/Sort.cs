namespace HW1_Sort;
public class Sort
{
    public static void InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var index = i - 1;
            while(index >= 0 && (array[index] > array[index + 1]))
            {
                (array[index + 1], array[index]) = (array[index], array[index + 1]);
                index--;
            }
        }
    }
}