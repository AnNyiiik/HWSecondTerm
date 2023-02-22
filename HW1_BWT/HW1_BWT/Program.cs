using System;

namespace HW1_BWT
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Test.TestEncode())
            {
                return;
            }
            string code = BWT.Encode("banana");
            Console.WriteLine(code);
            string encoded = BWT.Decode(code);
            Console.WriteLine(encoded);
        }
    }
}