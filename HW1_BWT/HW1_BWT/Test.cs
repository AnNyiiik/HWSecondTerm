using System;

namespace HW1_BWT;
public class Test {
    private static bool TestEncode()
    {
        var testCases = new[] { "abracadabra", "banana", "abacaba", "" };
        var correctAnswers = new[] { "rdarcaaaabb", "nnbaaa", "bcabaaa", "" };
        var correctPositions = new[] { 2, 3, 2, 0 };
        for (int i = 0; i < testCases.Length; ++i)
        {
            var answer = BWT.Encode(testCases[i]);
            if (String.Compare(answer.Item1, correctAnswers[i]) != 0 
                    || correctPositions[i] != answer.Item2)
            {
                return false;
            }
        }

        return true;
    }

    private static bool TestDecode()
    {
        var testCases = new[] { "rdarcaaaabb", "bcabaaa" };
        var position = new[] { 2, 2 };
        var correctAnswers = new[] { "abracadabra", "abacaba" };
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