using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue once.
    // Expected Result: The item with the highest priority (Banana, 5) is returned.
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Apple", 1);
        queue.Enqueue("Banana", 5);
        queue.Enqueue("Cherry", 3);

        var result = queue.Dequeue();
        Assert.AreEqual("Banana", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority. Dequeue should follow FIFO for same priority.
    // Expected Result: "Tom" (priority 4) should be returned before "Jerry" (priority 4).
    // Defect(s) Found: 
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Tom", 4);
        queue.Enqueue("Jerry", 4);
        queue.Enqueue("Spike", 2);

        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();

        Assert.AreEqual("Tom", result1);
        Assert.AreEqual("Jerry", result2);
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: An InvalidOperationException with message "The queue is empty." should be thrown.
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}