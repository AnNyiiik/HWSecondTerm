namespace HW2_Calculator.Tests;

public class Tests
{
    private IStack stackBasedOnArray = new StackBasedOnArray();
    private IStack stackBasedOnList = new StackBasedOnList();

    [SetUp]
    public void Setup()
    {
        stackBasedOnArray = new StackBasedOnArray();
        stackBasedOnList = new StackBasedOnList();
    }

    [Test]
    public void PopFromEmptyStackShouldNotFail()
    {
        stackBasedOnArray.Pop();
        stackBasedOnList.Pop();
        
        Assert.IsTrue(stackBasedOnArray.Size() == 0);
        Assert.IsTrue(stackBasedOnList.Size() == 0);
    }

    [Test]
    public void PushShallWork()
    {
        stackBasedOnArray.Push(1);
        stackBasedOnList.Push(1);

        Assert.IsFalse(stackBasedOnArray.Size() == 0);
        Assert.IsFalse(stackBasedOnList.Size() == 0);
    }

    [Test]
    public void PushAndPopShallLeaveStackEmpty()
    {
        stackBasedOnArray.Push(1);
        stackBasedOnArray.Pop();
        
        stackBasedOnList.Push(1);
        stackBasedOnList.Pop();

        Assert.IsTrue(stackBasedOnArray.Size() == 0);
        
        Assert.IsTrue(stackBasedOnList.Size() == 0);
    }

    [Test]
    public void TwoPushesAndPopShallLeaveElementInStack()
    {
        stackBasedOnArray.Push(1);
        stackBasedOnArray.Push(2);
        stackBasedOnArray.Pop();

        Assert.IsFalse(stackBasedOnArray.Size() == 0);
        
        stackBasedOnList.Push(1);
        stackBasedOnList.Push(2);
        stackBasedOnList.Pop();

        Assert.IsFalse(stackBasedOnList.Size() == 0);
    }

    [Test]
    public void PushAndPopShallGetExpectedValue()
    {
        stackBasedOnArray.Push(1);
        var value = stackBasedOnArray.Pop();

        Assert.That(value, Is.EqualTo(1.0));
        
        stackBasedOnList.Push(1);
        value = stackBasedOnList.Pop();

        Assert.That(value, Is.EqualTo(1.0));
    }
}