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
    public void PopFromEmptyStackShouldThrowAccessViolationExceptionTest(IStack stack)
    {
        Assert.Throws<AccessViolationException>(() => stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushShallWorkTest(IStack stack)
    {
        stack.Push(1);
        Assert.That(!stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPopShallLeaveStackEmptyTest(IStack stack)
    {
        stack.Push(1);
        stack.Pop();
        Assert.That(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void TwoPushesAndPopShallLeaveElementInStackTest(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Pop();

        Assert.That(!stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPopShallGetExpectedValueTest(IStack stack)
    {
        stack.Push(1);
        var value = stack.Pop();

        Assert.That(value, Is.EqualTo(1));
    }
}