using System;

namespace HW1_BWT
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Test.TestBWT())
            {
                Console.WriteLine("Tests have been failed");
                return;
            }
            Console.WriteLine("Please, enter the option (1 to encode and 2 to decode):");
            int option = 0;
            bool isCorrect = Int32.TryParse(Console.ReadLine(), out option);
            if (!isCorrect)
            {
                Console.WriteLine("Not a number");
                return;
            }

            if (option == 1)
            {
                Console.WriteLine("Please, enter a string to encode:");
                string sequence = Console.ReadLine();
                Tuple<string, int> answer = BWT.Encode(sequence);
                Console.WriteLine("Encoded string : {0} \nPosition : {1}", answer.Item1, answer.Item2);
            }
            else if (option == 2)
            {
                Console.WriteLine("Please, enter a string to decode:");
                string sequence = Console.ReadLine();
                Console.WriteLine("Please, enter a position:");
                int position = 0;
                isCorrect = Int32.TryParse(Console.ReadLine(), out position);
                if (!isCorrect)
                {
                    Console.WriteLine("Not a number");
                    return;
                } else if (position >= sequence.Length || position < 0)
                {
                    Console.WriteLine("Position is incorrect");
                    return;
                }
                string answer = BWT.Decode(sequence, position);
                Console.WriteLine("Decoded string : {0} ", answer);
            }
            else
            {
                Console.WriteLine("Option is incorrect");
            }
        }
    }
}