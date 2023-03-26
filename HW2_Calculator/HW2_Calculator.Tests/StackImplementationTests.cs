namespace HW2_Calculator.Tests;

public class StackImplementationTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new StackBasedOnArray()),
            new TestCaseData(new StackBasedOnList())
        };

    [TestCaseSource(nameof(Stacks))]
    public void PopFromEmptyStackShouldNotFailTest(IStack stack)
    {
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty);
    }

    [Test]
    public void PushShallWork()
    {
        stack.Push(1);

        Assert.IsFalse(stack.IsEmpty);
    }

    [Test]
    public void PushAndPopShallLeaveStackEmpty()
    {
        stack.Push(1);
        stack.Pop();

        Assert.IsTrue(stack.IsEmpty);
    }

    [Test]
    public void TwoPushesAndPopShallLeaveElementInStack()
    {
        stack.Push(1);
        stack.Push(2);
        stack.Pop();

        Assert.IsFalse(stack.IsEmpty);
    }

    [Test]
    public void PushAndPopShallGetExpectedValue()
    {
        stack.Push(1);
        var value = stack.Pop();

        Assert.AreEqual(1, value);
    }
}