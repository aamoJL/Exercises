namespace UnitTests.DataStructureTests;

[TestClass]
public class StackTests
{
  [TestMethod]
  public void Pop_HasItems_ItemRemovedAndReturned()
  {
    var list = new Algorithms.DataStructures.Stack<int>([1, 2, 3]);

    var result = list.Pop();

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(3, result);
    Assert.AreEqual(2, list.Peek());
  }

  [TestMethod]
  public void Pop_Empty_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.Stack<int>();

    Assert.ThrowsException<InvalidOperationException>(() => list.Pop());
  }

  [TestMethod]
  public void Push_ItemAdded()
  {
    var list = new Algorithms.DataStructures.Stack<int>([1, 2, 3]);

    list.Push(4);

    Assert.AreEqual(4, list.Count);
    Assert.AreEqual(4, list.Peek());
  }

  [TestMethod]
  public void Peek_HasItems_ItemReturned()
  {
    var list = new Algorithms.DataStructures.Stack<int>([1, 2, 3]);

    var result = list.Peek();

    Assert.AreEqual(3, result);
  }

  [TestMethod]
  public void Peek_HasItems_ItemNotRemoved()
  {
    var list = new Algorithms.DataStructures.Stack<int>([4, 6, 2]);

    _ = list.Peek();

    Assert.AreEqual(3, list.Count);
  }

  [TestMethod]
  public void Peek_Empty_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.Stack<int>();

    Assert.ThrowsException<InvalidOperationException>(() => list.Peek());
  }

  [TestMethod]
  public void Push_Pop()
  {
    var list = new Algorithms.DataStructures.Stack<int>();

    list.Push(1);
    list.Push(2);
    list.Push(3);

    for (var i = list.Count; i > 0; i--)
      Assert.AreEqual(i, list.Pop());

    Assert.AreEqual(0, list.Count);

    Assert.ThrowsException<InvalidOperationException>(() => list.Pop());
  }

  [TestMethod]
  public void ToArray_FirstIsFirst()
  {
    var array = new int[] { 4, 6, 2 };
    var list = new Algorithms.DataStructures.Stack<int>(array);

    var result = list.ToArray(Algorithms.DataStructures.Stack<int>.ArrayOrder.FirstIsFirst);

    CollectionAssert.AreEqual(array.Reverse().ToArray(), result);
  }

  [TestMethod]
  public void ToArray_LastIsFirst()
  {
    var array = new int[] { 4, 6, 2 };
    var list = new Algorithms.DataStructures.Stack<int>(array);

    var result = list.ToArray(Algorithms.DataStructures.Stack<int>.ArrayOrder.LastIsFirst);

    CollectionAssert.AreEqual(array, result);
  }

  [TestMethod]
  public void Contains_True()
  {
    var list = new Algorithms.DataStructures.Stack<int>([1, 2, 3]);

    Assert.IsTrue(list.Contains(2));
  }

  [TestMethod]
  public void Contains_False()
  {
    var list = new Algorithms.DataStructures.Stack<int>([1, 2, 3]);

    Assert.IsFalse(list.Contains(4));
  }
}
