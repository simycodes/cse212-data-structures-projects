using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: DEQUEUE FUNCTION REMOVES THE ITEM WITH HIGHEST PROPRIETY AND RETURN 
    // ITS VALUE
    // Expected Result: thirdItem
    // Defect(s) Found: ITEM WITH HIGHEST PROPRIETY IS NOT REMOVED - TEST FAILED (TEXT FIXED)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // ADD ITEMS TO THE QUEUE
        priorityQueue.Enqueue("firstItem", 1);
        priorityQueue.Enqueue("secondItem", 2);
        priorityQueue.Enqueue("thirdItem", 3);

        // REMOVE AN ITEM
        var removedItem = priorityQueue.Dequeue();
        // VERIFY TEST
        Assert.AreEqual("thirdItem", removedItem, "ThirdItem should be dequeued as it has the highest priority");
    } 

    [TestMethod]
    // Scenario: DEQUEUE ITEM CLOSEST TO THE FRONT OF QUEUE WHEN THERE ARE MORE THAN
    // ONE ITEM WITH HIGHEST PRIORITY 
    // Expected Result: secondItem
    // Defect(s) Found: ITEM CLOSEST TO THE FRONT OF QUEUE IS NOT REMOVED (TEST FIXED)
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // ADD ITEMS TO THE QUEUE
        priorityQueue.Enqueue("firstItem", 10);
        priorityQueue.Enqueue("secondItem", 10);
        priorityQueue.Enqueue("thirdItem", 7);
        priorityQueue.Enqueue("fourthItem", 3);

        // DEQUEUE TO GET BACK ITEM (IT HOLDS HIGHEST PRIORITY SO ITS REMOVED)
        var removedItem = priorityQueue.Dequeue();
        
        // VERIFY TEST
        Assert.AreEqual("firstItem", removedItem, "first should be dequeued");
    }

    [TestMethod]
    // Scenario: DEQUEUING FROM AN EMPTY QUEUE
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: NO DEFECTS OBSERVED, TEST PASSES AS EXCEPTION IS WELL HANDLED 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
 
}