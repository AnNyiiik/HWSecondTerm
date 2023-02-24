using System;

namespace HW1_BWT
{
    public class Test
    {
        private static bool TestEncode()
        {
            string[] testCases = new[] { "abracadabra", "banana", "abacaba", ""};
            string[] correctAnswers = new[] { "rdarcaaaabb", "nnbaaa", "bcabaaa", ""};
            for (int i = 0; i < testCases.Length; ++i)
            {
                if (String.Compare(BWT.Encode(testCases[i]).Item1, correctAnswers[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TestDecode()
        {
            string[] testCases = new[] { "rdarcaaaabb", "bcabaaa"};
            int[] position = new[] { 2, 2 };
            string[] correctAnswers = new[] { "abracadabra", "abacaba"};
            for (int i = 0; i < testCases.Length; ++i)
            {
                if (String.Compare(BWT.Decode(testCases[i], position[i]), correctAnswers[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool TestBWT()
        {
            return TestEncode() && TestDecode();
        }
    }
}