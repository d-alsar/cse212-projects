using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with distinct priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority.
    public void TestPriorityQueue_DistinctPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 2);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same priority and dequeue them.
    // Expected Result: Items with the same priority should be dequeued in FIFO order.
    public void TestPriorityQueue_SamePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with mixed priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority; ties resolved by FIFO.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 3);
        priorityQueue.Enqueue("Item4", 2);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("Queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items and ensure ToString produces the correct result.
    // Expected Result: The string representation matches the state of the queue.
    public void TestPriorityQueue_ToString()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 2);

        var expectedOutput = "Item1 (Priority: 3), Item3 (Priority: 2), Item2 (Priority: 1)";
        Assert.AreEqual(expectedOutput, priorityQueue.ToString());
    }
}
