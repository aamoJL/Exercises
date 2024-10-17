namespace UnitTests.DataStructureTests;

[TestClass]
public class QueueTests
{
  [TestMethod]
  public void Enqueue_Empty_ItemAdded()
  {
    var list = new Algorithms.DataStructures.Queue<int>();

    list.Enqueue(1);

    Assert.AreEqual(1, list.Count);
    Assert.AreEqual(1, list.Peek());
  }

  [TestMethod]
  public void Enqueue_HasItems_ItemAdded()
  {
    var list = new Algorithms.DataStructures.Queue<int>([1, 2, 3]);

    list.Enqueue(4);

    Assert.AreEqual(4, list.Count);
    Assert.AreEqual(1, list.Peek());
  }

  [TestMethod]
  public void Enqueue_AllItemsStillInQueue()
  {
    var array = new int[] { 1, 2, 3 };
    var list = new Algorithms.DataStructures.Queue<int>(array);

    array = [1, 2, 3, 4];
    list.Enqueue(4);

    for (var i = 0; i < list.Count; i++)
      Assert.AreEqual(array[i], list.Dequeue());
  }

  [TestMethod]
  public void Dequeue_Empty_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.Queue<int>();

    Assert.ThrowsException<InvalidOperationException>(() => list.Dequeue());
  }

  [TestMethod]
  public void Dequeue_HasItems_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.Queue<int>([1, 2, 3]);

    var result = list.Dequeue();

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void Dequeue_AllItemsStillInQueue()
  {
    var array = new int[] { 1, 2, 3, 4 };
    var list = new Algorithms.DataStructures.Queue<int>(array);

    array = [2, 3, 4];
    list.Dequeue();

    for (var i = 0; i < list.Count; i++)
      Assert.AreEqual(array[i], list.Dequeue());
  }

  [TestMethod]
  public void Dequeue_Enqueue_Seek()
  {
    var list = new Algorithms.DataStructures.Queue<int>([1]);

    list.Dequeue();
    list.Enqueue(2);

    Assert.AreEqual(2, list.Peek());
  }

  [TestMethod]
  public void Peek_Empty_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.Queue<int>();

    Assert.ThrowsException<InvalidOperationException>(() => list.Peek());
  }

  [TestMethod]
  public void Peek_HasItems_FirstReturned()
  {
    var list = new Algorithms.DataStructures.Queue<int>([1, 2, 3]);

    var result = list.Peek();

    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void Peek_HasItems_ItemNotRemoved()
  {
    var list = new Algorithms.DataStructures.Queue<int>([1, 2, 3]);

    list.Peek();

    Assert.AreEqual(3, list.Count);
  }
}
