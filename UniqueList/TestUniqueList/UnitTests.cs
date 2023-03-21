using UniqueList;

namespace TestUniqueList;

public class Tests
{
    private static IEnumerable<TestCaseData> Lists
        => new TestCaseData[]
        {
            new TestCaseData(new MyList<int>()),
            new TestCaseData(new UniqueList<int>())
        };

    [TestCaseSource(nameof(Lists))]
    public void ListSholdNotBeEmptyAfterAdd(MyList<int> list)
    {
        list.Add(1, 0);
        Assert.That(list.Size, Is.EqualTo(1));
    }

    [TestCaseSource(nameof(Lists))]
    public void ListSizeSholdBeLessAfterDeleteAndReturnCorrectValue(MyList<int> list)
    {
        list.Add(1, 0);
        var value = list.Delete(0);
        Assert.That(list.Size, Is.EqualTo(0));
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestCaseSource(nameof(Lists))]
    public void ListSholdChangeTheValueOfElementAfterChange(MyList<int> list)
    {
        for (var i = 0; i < 5; ++i)
        {
            list.Add(i, i);
        }

        list.Change(7, 3);
        var value = list.GetValueByPosition(3);
        Assert.That(value, Is.EqualTo(7));
    }

    [TestCaseSource(nameof(Lists))]
    public void ListShouldThrowArgumentExceptionAfterAddingByTheWrongPosition(MyList<int> list)
    {
        Assert.Throws<ArgumentException>(() => list.Add(0, 4));
    }
    
    [TestCaseSource(nameof(Lists))]
    public void ListShouldThrowNonExistingElementExceptionAfterDeletingOrChangingByTheWrongPosition(MyList<int> list)
    {
        Assert.Throws<DeleteOrChangeNonExistingElementException>(() => list.Delete(0));
        Assert.Throws<DeleteOrChangeNonExistingElementException>(() => list.Change(0, 9));
    }

    private static IEnumerable<TestCaseData> uniqueList
        => new TestCaseData[]
        {
            new TestCaseData(new UniqueList<int>())
        };
    
    [TestCaseSource(nameof(uniqueList))]
    public void UniqueListShouldThrowExceptionWhenAddExistingElement(UniqueList<int> list)
    {
        list.Add(1, 0);
        Assert.Throws<AddExistingElementToUniqueListException>(() => list.Add(1, 0));
    }
    
    
}