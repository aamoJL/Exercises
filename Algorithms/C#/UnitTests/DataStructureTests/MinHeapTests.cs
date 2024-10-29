using Algorithms.DataStructures;

namespace UnitTests.DataStructureTests;

[TestClass]
public class MinHeapTests
{
  [TestMethod]
  public void Insert_Empty_Added()
  {
    var heap = new MinHeap<int>();

    heap.Insert(2);

    Assert.AreEqual(1, heap.Count);
    CollectionAssert.AreEqual(new int[] { 2 }, heap.ToArray());
  }

  [TestMethod]
  public void Insert_NoChildren_Added()
  {
    var heap = new MinHeap<int>([1]);

    heap.Insert(2);

    Assert.AreEqual(2, heap.Count);
    CollectionAssert.AreEqual(new int[] { 1, 2 }, heap.ToArray());
  }

  [TestMethod]
  public void Insert_Bigger_Added()
  {
    var heap = new MinHeap<int>([1, 2, 3, 17, 19, 36, 7, 25, 100]);

    // The next incomplete parent is 19
    heap.Insert(20);

    CollectionAssert.AreEqual(new int[] { 1, 2, 3, 17, 19, 36, 7, 25, 100, 20 }, heap.ToArray());
  }

  [TestMethod]
  public void Insert_Smaller_Added()
  {
    var heap = new MinHeap<int>([1, 2, 3, 17, 19, 36, 7, 25, 100]);

    // The next incomplete parent is 19
    heap.Insert(15);

    CollectionAssert.AreEqual(new int[] { 1, 2, 3, 17, 15, 36, 7, 25, 100, 19 }, heap.ToArray());
  }

  [TestMethod]
  public void Insert_Smallest_Added()
  {
    var heap = new MinHeap<int>([1, 2, 3, 17, 19, 36, 7, 25, 100]);

    // The next incomplete parent is 19
    heap.Insert(0);

    CollectionAssert.AreEqual(new int[] { 0, 1, 3, 17, 2, 36, 7, 25, 100, 19 }, heap.ToArray());
  }

  [TestMethod]
  public void ToArray()
  {
    var array = new int[] { 1, 2, 3, 17, 19, 36, 7, 25, 100 };
    var heap = new MinHeap<int>(array);

    CollectionAssert.AreEqual(array, heap.ToArray());
  }

  [TestMethod]
  public void Remove_Empty_ExceptionThrown()
  {
    var heap = new MinHeap<int>();

    Assert.ThrowsException<InvalidOperationException>(() => heap.Remove());
  }

  [TestMethod]
  public void Remove_One_Removed()
  {
    var heap = new MinHeap<int>([1]);

    heap.Remove();

    Assert.AreEqual(0, heap.Count);
  }

  [TestMethod]
  public void Remove_FirstItemReturned()
  {
    var heap = new MinHeap<int>([1, 2, 3, 17, 19, 36, 7, 25, 100]);

    var result = heap.Remove();

    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void Remove_RemovedAndReordered()
  {
    var heap = new MinHeap<int>([1, 2, 3, 17, 19, 36, 7, 25, 100]);

    heap.Remove();

    CollectionAssert.AreEqual(new int[] { 2, 17, 3, 25, 19, 36, 7, 100 }, heap.ToArray());
  }
}
