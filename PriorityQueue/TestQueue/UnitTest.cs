using PriorityQueue;

namespace TestQueue;

public class Tests
{
    [Test]
    public void EnqueueShouldAddElement()
    {
        var queue = new PriorityQueue<char>();
        queue.Enqueue('a', 1);
        Assert.That(!queue.Empty());
    }

    [Test]
    public void DequeueShouldDeleteAnElementFromNonEmptyQueueAndReturnRightValue()
    {
        var queue = new PriorityQueue<char>();
        queue.Enqueue('a', 1);
        queue.Enqueue('b', 2);
        var value = queue.Dequeue();
        Assert.That(!queue.Empty());
        Assert.That(value, Is.EqualTo('b'));
    }

    private static IEnumerable<TestCaseData> Data
        => new TestCaseData[]
        {
            new TestCaseData(new [] {('1', 2), ('3', 3), ('4', 4), ('2', 3)}, new [] {'4', '3', '2', '1'}),
            new TestCaseData(new [] {('8', 8), ('4', 4), ('9', 9), ('7', 7), ('6', 6), ('5', 4)}, 
                new [] {'9', '8', '7', '6', '4', '5'})
        };

    [TestCaseSource(nameof(Data))]
    public void EnqueueShouldAddAtRightOrder((char value, int priority) [] parameters, char [] correctOutputSequence)
    {
        var queue = new PriorityQueue<char>();
        foreach (var parameter in parameters)
        {
            queue.Enqueue(parameter.value, parameter.priority);
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
        var queue = new PriorityQueue<int>();
        Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
    }

    [Test]
    public void EmptyShouldReturnCorrectAnswer()
    {
        var queue = new PriorityQueue<int>();
        Assert.That(queue.Empty());
        queue.Enqueue(1, 1);
        Assert.That(!queue.Empty());
    }
}