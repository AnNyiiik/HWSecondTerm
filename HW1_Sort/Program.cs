using System;
using HW1_Sort;

    var isCorrect = Test.TestSort();
    if (!isCorrect)
    {
        Console.WriteLine("Test has been failed");
        return;
    }
    Console.WriteLine("Enter the size of the array:\n");
    var isCorrectData = Int32.TryParse(Console.ReadLine(), out var size);
    if (!isCorrectData)
    {
        Console.WriteLine("Not a number");
        return;
    } 
    if (size < 0)
    {
        Console.WriteLine("Invalid size value (should be non-negative)");
        return;
    }
    var array = new int[size];
    Console.WriteLine("Enter the numbers:\n");
    for (var i = 0; i < size; ++i)
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