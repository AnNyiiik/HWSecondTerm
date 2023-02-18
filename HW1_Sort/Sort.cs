namespace HW1_Sort
{
    public class Sort
    {
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i - 1;
                while(index >= 0 && (array[index] > array[index + 1]))
                {
                    array[index + 1] = array[index + 1] ^ array[index];
                    array[index] = array[index] ^ array[index + 1];
                    array[index + 1] = array[index + 1] ^ array[index];
                    index--;
                }
            }
        }

    }
}