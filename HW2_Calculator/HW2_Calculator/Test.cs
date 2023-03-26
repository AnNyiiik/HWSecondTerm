namespace HW2_Calculator;

public static class Test
{
    private static readonly double delta = 0.00001;
    private static readonly string[] TestCasesTrue = { "12 8 - 3 *", "-4 9 + 8 * 4 /" };
    private static readonly double[] CorrectAnswers = { 12.0, 10.0 };
    private static readonly string[] TestCasesFalse = { "", "10 8 - 0 /", "10 8 - 5" };

    private static bool TestStack(IStack stackImplementation)
    {
        var stack = new StackCalculator(stackImplementation);
        for (var i = 0; i < TestCasesTrue.Length; ++i)
        {
            var result = stack.Calculate(TestCasesTrue[i]);
            if (result.Item2 == null)
            {
                return false;
            }
            if (Math.Abs((double)result.Item2 - CorrectAnswers[i]) > delta)
            {
                return false;
            }
            stack.Clear();
        }

        foreach (var expression in TestCasesFalse)
        {
            var result = stack.Calculate(expression);
            if (result.Item1)
            {
                return false;
            }
            stack.Clear();
        }
        
        return true;
    }

    public static bool TestStackImplementation()
    {
        return TestStack(new StackBasedOnArray()) && TestStack(new StackBasedOnList());
    }
}