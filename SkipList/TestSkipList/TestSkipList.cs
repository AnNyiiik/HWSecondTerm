using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SkipList;

namespace TestSkipList;

public class Tests
{
    private static IEnumerable<TestCaseData> ListDataFind =>
        new TestCaseData[] {
            new TestCaseData(new List<int> {90, -12, 34, 2, -10, 5, -13, -100, 100, 0, 
                    -8, 77, 2, 5, 6})
        };
    
    private static IEnumerable<TestCaseData> ListDataAdd =>
        new TestCaseData[] {
            new TestCaseData(new List<int> {90, -12, 34, 2, -10, 5, -13, -100, 100, 0, 
                -8, 77, 2, 5, 6}, new List<int> {1, -14, 11, 99, -19, 3})
        };

    [TestCaseSource(nameof(ListDataFind))]
    public void TestFindValue(List<int> list)
    {
        var skipList = new SkipList<int>(list);
        foreach (var item in list)
        {
            Assert.That(skipList.FindValue(item), Is.EqualTo(true));
        }
    }

    [TestCaseSource(nameof(ListDataAdd))]
    public void TestAddElement(List<int> list, List<int> newElements)
    {
        var skipList = new SkipList<int>(list);
        foreach (var item in newElements)
        {
            skipList.Add(item);
            Assert.That(skipList.FindValue(item), Is.EqualTo(true));
        }
    }

    [TestCaseSource(nameof(ListDataFind))]
    public void TestDelete(List<int> list)
    {
        var skipList = new SkipList<int>(list);
        foreach (var item in list)
        {
            skipList.Delete(item);
            Assert.That(skipList.FindValue(item), Is.EqualTo(false));
        }
    }
}