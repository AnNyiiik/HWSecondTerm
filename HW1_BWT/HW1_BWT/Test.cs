using System;

namespace HW1_BWT
{
    public class Test
    {
        public static bool TestEncode()
        {
            string[] testCases = new[] { "abracadabra", "banana", "abacaba" };
            string[] correctAnswers = new[] { "rdarcaaaabb", "nnbaaa", "bcabaaa" };
            for (int i = 0; i < testCases.Length; ++i)
            {
                if (String.Compare(BWT.Encode(testCases[i]), correctAnswers[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}