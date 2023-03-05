using System;

namespace HW2_Calculator;

public static class Test
{
    private static double delta = 0.00001;
    private static string[] testCasesTrue = new[] { "12 8 - 3 *", "-4 9 + 8 * 4 /" };
    private static double[] correctAnswers = new[] { 12.0, 10.0 };
    private static string[] testCasesFalse = new[] { "", "10 8 - 0 /", "10 8 - 5", "+" };

    private static bool TestStack(IStack stackImplementation)
    {
        var stack = new StackCalculator(stackImplementation);
        for (var i = 0; i < testCasesTrue.Length; ++i)
        {
            var result = stack.Calculate(testCasesTrue[i]);
            if (!result.Item1)
            {
                return false;
            }

            if (Math.Abs(result.Item2 - correctAnswers[i]) > delta)
            {
                return false;
            }
        }
        for (var i = 0; i < testCasesFalse.Length; ++i)
        {
            var result = stack.Calculate(testCasesFalse[i]);
            if (result.Item1)
            {
                return false;
            }
        }
        return true;
    }

    public static bool TestStackImplementation()
    {
        return TestStack((IStack)new StackBasedOnArray()) && TestStack((IStack)new StackBasedOnList());
    }
}