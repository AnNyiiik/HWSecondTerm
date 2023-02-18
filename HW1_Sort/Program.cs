using System;

namespace HW1_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = Test.TestSort();
            if (!isCorrect)
            {
                Console.WriteLine("Test has been failed");
                return;
            }
            Console.WriteLine("Enter the size of the array:\n");
            int size = Int32.Parse(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Enter the numbers:\n");
            for (int i = 0; i < size; ++i)
            {
                array[i] = Int32.Parse(Console.ReadLine());
            }
            Sort.InsertionSort(array);
            string result = String.Join(", ", array);
            Console.WriteLine(result);
        }
    }
}