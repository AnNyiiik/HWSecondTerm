using PriorityQueue;

namespace TestQueue;

public class Tests
{
    
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void EnqueueShouldAddElement()
    {
        var queue = new PriorityQueue.PriorityQueue();
        queue.Enqueue('a', 1);
        Assert.That(!queue.Empty());
    }

    [Test]
    public void DequeueShouldDeleteAnElementFromNonEmptyQueueAndReturnRightValue()
    {
        var queue = new PriorityQueue.PriorityQueue();
        queue.Enqueue('a', 1);
        queue.Enqueue('b', 2);
        var value = queue.Dequeue();
        Assert.That(!queue.Empty());
        Assert.That(value, Is.EqualTo('b'));
    }

    private static IEnumerable<TestCaseData> Data
        => new TestCaseData[]
        {
            new TestCaseData(new [] {('1', 2), ('3', 3), ('4', 4), ('2', 3)}, new [] {'4', '3', '2', '1'})
        };

    [TestCaseSource(nameof(Data))]
    public void EnqueueShouldAddAtRightOrder((char, int) [] parameters, char [] correctOutputSequence)
    {
        var queue = new PriorityQueue.PriorityQueue();
        foreach (var parameter in parameters)
        {
            queue.Enqueue(parameter.Item1, parameter.Item2);
        }

        foreach (var correctItem in correctOutputSequence)
        {
            Assert.That(!queue.Empty());
            var value = queue.Dequeue();
            Assert.That(value, Is.EqualTo(correctItem));
        }
    }

    [Test]
    public void DequeueFromEmptyQueueShouldThrowException()
    {
        var queue = new PriorityQueue.PriorityQueue();
        Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }
    
    
}