using Lambdas;

namespace TestListLambdaFunctions;

public class Tests
{
    private static IEnumerable<TestCaseData> MapFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new Func<int, int>(i => i * 2)),
            new TestCaseData(new Func<int, int>(i => i * i))
        };

    private static IEnumerable<TestCaseData> FilterFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new Func<char, bool>(i => i <= '9' && i >= '0')),
            new TestCaseData(new Func<int, bool>(i => i > 0))
        };
    
    private static IEnumerable<TestCaseData> FoldFunctions
        => new TestCaseData[]
            {
                new TestCaseData(new Func<int, int, int>((x, y) => x + y)),
                new TestCaseData(new Func<int, int, int>((x, y) => x * y))
            }

    [Test]
    public void Test1()
    {
        var list = new List<int> {1, 2, 3};
        var listRes = ListLambdas<int>.Fold(list, 0, lambdaExpressionsMap);
        Assert.Pass();
    }
}