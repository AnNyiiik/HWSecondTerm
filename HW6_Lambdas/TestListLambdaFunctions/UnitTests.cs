using Lambdas;

namespace TestListLambdaFunctions;

public class Tests
{
    private static IEnumerable<TestCaseData> MapFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new Tuple<Func<int, int>, List<int>, List<int>>(new Func<int, int>(i => i * 2),
                new List<int>(){ -3, -2, -1, 1, 2, 3 }, new List<int>() { -6, -4, -2, 2, 4, 6 })),
            new TestCaseData(new Tuple<Func<int, int>, List<int>, List<int>>(new Func<int, int>(i => i * i),
                new List<int>(){ 1, 2, 3 }, new List<int>() { 1, 4, 9 }))
        };

    private static IEnumerable<TestCaseData> FilterFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new Tuple<Func<int, bool>, List<int>, List<int>>(new Func<int, bool>(i => i % 2 == 0),
                    new List<int>(){1, 2, 3, 4, 5}, new List<int>() {2, 4})),
            new TestCaseData(new Tuple<Func<int, bool>, List<int>, List<int>>(new Func<int, bool>(i => i > 0),
                new List<int>(){-1, -2, 3, 4, -5}, new List<int>() {3, 4}))
        };

    private static IEnumerable<TestCaseData> FoldFunctions
        => new TestCaseData[]
        {
            new TestCaseData(new Tuple<Func<int, int, int>, List<int>, int, int> (new Func<int, int, int>((x, y) => 
                    x + y), new List<int>() {1, 2, 3, 4, 5}, 0, 15)),
            new TestCaseData(new Tuple<Func<int, int, int>, List<int>, int, int> (new Func<int, int, int>((x, y) => 
                    x * y), new List<int>() {1, 2, 3}, 1, 6))
        };

    [TestCaseSource(nameof(MapFunctions))]
    public void TestMap(Tuple<Func<int, int>, List<int>, List<int>> arguments)
    {
        var list = arguments.Item2;
        var listCorrectOut = arguments.Item3;
        ListLambdas<int>.Map(ref list, arguments.Item1);
        Assert.That(list, Is.Not.EqualTo(null));
        Assert.That(list?.Count, Is.EqualTo(listCorrectOut.Count));
        for (var i = 0; i < list.Count; ++i)
        {
            Assert.That(list[i], Is.EqualTo(listCorrectOut[i]));
        }
    }

    [TestCaseSource(nameof(FilterFunctions))]
    public void TestFilter(Tuple<Func<int, bool>, List<int>, List<int>> arguments)
    {
        var list = ListLambdas<int>.Filter(arguments.Item2, arguments.Item1);
        var listCorrectOut = arguments.Item3;
        Assert.That(list, Is.Not.EqualTo(null));
        Assert.That(list?.Count, Is.EqualTo(listCorrectOut.Count));
        for (var i = 0; i < list.Count; ++i)
        {
            Assert.That(list[i], Is.EqualTo(listCorrectOut[i]));
        }
    }

    [TestCaseSource(nameof(FoldFunctions))]
    public void TestFold(Tuple<Func<int, int, int>, List<int>, int, int> arguments)
    {
        var outValue = ListLambdas<int>.Fold(arguments.Item2, arguments.Item3, arguments.Item1);
        Assert.That(outValue, Is.EqualTo(arguments.Item4));
    }

    [Test]
    public void TestNullArgument()
    {
        List<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => ListLambdas<int>.Fold(list, 1,
            (x, y) => x + y));
        Assert.Throws<ArgumentNullException>(() => ListLambdas<int>.Map(ref list, i => i));
        Assert.Throws<ArgumentNullException>(() => ListLambdas<int>.Filter(list, i => i > 0));
    }
}