using System;

using HW1_BWT;

if (!Test.TestBWT())
{
    Console.WriteLine("Tests have been failed");
    return;
}
Console.WriteLine("Please, enter the option (1 to encode and 2 to decode):");
var isCorrect = Int32.TryParse(Console.ReadLine(), out int option);
if (!isCorrect)
{
    Console.WriteLine("Not a number");
    return;
}

switch (option)
{
    case 1:
        Console.WriteLine("Please, enter a string to encode:");
        var sequence = Console.ReadLine();
        if (String.IsNullOrEmpty(sequence))
        {
            Console.WriteLine("Empty string or null-reference");
            return;
        }
        var answer = BWT.Encode(sequence);
        Console.WriteLine("Encoded string : {0} \nPosition : {1}", answer.Item1, answer.Item2);
        break;
    
    case 2:
        Console.WriteLine("Please, enter a string to decode:");
        sequence = Console.ReadLine();
        if (String.IsNullOrEmpty(sequence))
        {
            Console.WriteLine("Empty string or null-reference");
            return;
        }
        Console.WriteLine("Please, enter a position:");
        isCorrect = Int32.TryParse(Console.ReadLine(), out int position);
        if (!isCorrect)
        {
            Console.WriteLine("Not a number");
            return;
        } 
        if (position >= sequence.Length || position < 0)
        {
            Console.WriteLine("Position is incorrect");
            return;
        }
        var decodedString = BWT.Decode(sequence, position);
        Console.WriteLine("Decoded string : {0} ", decodedString);
        break;
    
    default:
        Console.WriteLine("Option is incorrect");
        break;
}