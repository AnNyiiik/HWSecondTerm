namespace HW2_Calculator.Tests;

public class StackCalculatorTests
{
    
    private static readonly double delta = 0.00001;
    
    private static IEnumerable<TestCaseData> TestCasesTrue 
        => new TestCaseData[]
        {
            new TestCaseData(new StackBasedOnArray(), "12 8 - 3 *", 12.0), 
            new TestCaseData(new StackBasedOnList(), "12 8 - 3 *", 12.0), 
            new TestCaseData(new StackBasedOnArray(), "-4 9 + 8 * 4 /", 10.0), 
            new TestCaseData(new StackBasedOnList(), "-4 9 + 8 * 4 /", 10.0),
            new TestCaseData(new StackBasedOnArray(), "13 7 / 9 +", 10.85714),
            new TestCaseData(new StackBasedOnList(), "13 7 / 9 +", 10.85714),
            new TestCaseData(new StackBasedOnArray(), "0 -7 - 2 *", 14),
            new TestCaseData(new StackBasedOnList(), "0 -7 - 2 *", 14),
            new TestCaseData(new StackBasedOnArray(), "0 -9 - 2 *", 18),
            new TestCaseData(new StackBasedOnList(), "0 -9 - 2 *", 18),
            new TestCaseData(new StackBasedOnArray(), "0 0 +", 0),
            new TestCaseData(new StackBasedOnList(), "0 0 +", 0), 
            new TestCaseData(new StackBasedOnArray(), "3,3 -9,8 + 11,16 -", -17.66),
            new TestCaseData(new StackBasedOnList(), "3,3 -9,8 + 11,16 -", -17.66)
        };
    
    [TestCaseSource(nameof(TestCasesTrue))]
    public void TestTrue(IStack stack, string expression, double answer)
    {
        var stackCalculator = new StackCalculator(stack);
        var result = stackCalculator.Calculate(expression);
        Assert.That(result.Item1);
        Assert.That(result.Item2 != null);
        if (result.Item2 != null)
        {
            Assert.That(Math.Abs((double)result.Item2 - answer) < delta);
        }
    }
    
    private static IEnumerable<TestCaseData> TestCasesFalse 
        => new TestCaseData[]
        {
            new TestCaseData(new StackBasedOnArray(), ""), 
            new TestCaseData(new StackBasedOnList(), ""), 
            new TestCaseData(new StackBasedOnArray(), "10 8 - 0 /"), 
            new TestCaseData(new StackBasedOnList(), "10 8 - 0 /"),  
            new TestCaseData(new StackBasedOnArray(), "+"),
            new TestCaseData(new StackBasedOnList(), "+"),
            new TestCaseData(new StackBasedOnArray(), null),
            new TestCaseData(new StackBasedOnList(), null)
        };
    
    [TestCaseSource(nameof(TestCasesFalse))]
    public void TestFalse(IStack stack, string? expression)
    {
        var stackCalculator = new StackCalculator(stack);
        var result = stackCalculator.Calculate(expression);
        Assert.That(!result.Item1);
    }
}