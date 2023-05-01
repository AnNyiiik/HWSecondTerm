using SkipList;

namespace TestSkipList;

public class Tests
{
    private static IEnumerable<TestCaseData> ListData =>
        new TestCaseData[] {
            new TestCaseData(new List<int> {90, -12, 34, 2, -10, 5, -13, -100, 100, 0, 
                    -8, 77, 2, 5, 6})
        };

    [TestCaseSource(nameof(ListData))]
    public void TestFindValue(List<int> list)
    {
        var skipList = new SkipList<int>(list);
        foreach (var item in list)
        {
            Assert.That(skipList.FindValue(item), Is.EqualTo(true));
        }
        Assert.Pass();
    }
}