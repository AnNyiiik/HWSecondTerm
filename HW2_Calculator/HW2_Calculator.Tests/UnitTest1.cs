namespace HW2_Calculator.Tests;

public class Tests
{
    private IStack stack;
    private StackCalculator stackCalculator;
    
    private static readonly string[] testCasesTrue = { "12 8 - 3 *", "-4 9 + 8 * 4 /", "13 7 / 9 +" };
    private static readonly double[] correctAnswers = { 12.0, 10.0, 10.85714};
    
    private static readonly string[] testCasesFalse = { "", "10 8 - 0 /", "10 8 - 5", "+" };
    
    private static readonly double delta = 0.00001;

    [SetUp]
    public void Setup()
    {
        stackCalculator = new StackCalculator(stack);
    }

    [Test]
    public void TestTrue()
    {
        for (var i = 0; i < 2; ++i)
        {
            stack = i == 1 ? new StackBasedOnArray() : new StackBasedOnList();
            Setup();
            for(var j = 0; j < testCasesTrue.Length; ++j)
            {
                var result = stackCalculator.Calculate(testCasesTrue[j]);
                Assert.True(result.Item1);
                Assert.True(Math.Abs((double)result.Item2 - correctAnswers[j]) < delta);
                stack.Clear();
            }
        }
    }
    
    [Test]
    public void TestFalse()
    {
        for (var i = 0; i < 2; ++i)
        {
            stack = i == 1 ? new StackBasedOnArray() : new StackBasedOnList();
            Setup();
            foreach(var expression in testCasesFalse)
            {
                var result = stackCalculator.Calculate(expression);
                Assert.False(result.Item1);
                stack.Clear();
            }
        }
    }
}