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
            int size = 0;
            bool isCorrectData = Int32.TryParse(Console.ReadLine(), out size);
            if (!isCorrectData)
            {
                Console.WriteLine("Not a number");
                return;
            } else if (size < 0)
            {
                Console.WriteLine("Invalid size value (should be non-negative)");
                return;
            }
            int[] array = new int[size];
            Console.WriteLine("Enter the numbers:\n");
            for (int i = 0; i < size; ++i)
            {
                isCorrectData =  Int32.TryParse(Console.ReadLine(), out array[i]);
                if (!isCorrectData)
                {
                    Console.WriteLine("Not a number");
                    return;
                }
            }
            Sort.InsertionSort(array);
            string result = String.Join(", ", array);
            Console.WriteLine("The sorted data via insertion sort : {0} ", result);
        }
    }
}