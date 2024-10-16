namespace UnitTests.DataStructureTests;

[TestClass]
public class LinkedListTests
{
  [TestMethod]
  public void Constructor_WithArray_NodesAdded()
  {
    var array = new int[] { 1, 2, 3 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    for (var i = 0; i < array.Length; i++)
      Assert.AreEqual(array[i], list.Get(i));

    Assert.AreEqual(array.Length, list.Count);
  }

  [TestMethod]
  public void Append_ItemAppended()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2]);

    list.Append(3);

    Assert.AreEqual(3, list.Count);
    Assert.AreEqual(3, list.Get(2));
  }

  [TestMethod]
  public void Get_Found_ItemReturned()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    var result = list.Get(0);

    Assert.AreEqual(1, result);
  }

  [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
  public void Get_NotFound_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.Get(3);
  }

  [TestMethod]
  public void InsertAt_ItemInserted()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.InsertAt(index: 1, item: 4);

    Assert.AreEqual(4, list.Count);
    Assert.AreEqual(1, list.Get(0));
    Assert.AreEqual(4, list.Get(1));
    Assert.AreEqual(2, list.Get(2));
  }

  [TestMethod]
  public void InsertAt_EmptyList_ItemInserted()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>();

    list.InsertAt(index: 0, item: 1);

    Assert.AreEqual(1, list.Count);
    Assert.AreEqual(1, list.Get(0));
  }

  [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
  public void InsertAt_OutOfRange_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>();

    list.InsertAt(index: 1, item: 2);
  }

  [TestMethod]
  public void Prepend_ItemPrepended()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2]);

    list.Prepend(0);

    Assert.AreEqual(3, list.Count);
    Assert.AreEqual(0, list.Get(0));
  }

  [TestMethod]
  public void Remove_First_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var item = array[0];
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(item);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(1, list.Get(0));
  }

  [TestMethod]
  public void Remove_Middle_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var item = array[1];
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(item);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(2, list.Get(1));
  }

  [TestMethod]
  public void Remove_Last_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var item = array[2];
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(item);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(1, list.Get(1));
  }

  [TestMethod]
  public void Remove_NotFound_NoExceptions()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([]);

    list.Remove(0);
  }

  [TestMethod]
  public void RemoveAt_First_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.RemoveAt(0);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(2, list.Get(0));
    Assert.AreEqual(3, list.Get(1));
  }

  [TestMethod]
  public void RemoveAt_Middle_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.RemoveAt(1);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(1, list.Get(0));
    Assert.AreEqual(3, list.Get(1));
  }

  [TestMethod]
  public void RemoveAt_Last_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.RemoveAt(2);

    Assert.AreEqual(2, list.Count);
    Assert.AreEqual(1, list.Get(0));
    Assert.AreEqual(2, list.Get(1));
  }

  [TestMethod]
  public void RemoveAt_OnlyOne_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);

    Assert.AreEqual(0, list.Count);
  }

  [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
  public void RemoveAt_OutOfRange_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([]);

    list.RemoveAt(0);
  }

  [TestMethod]
  public void RemoveAt_And_Append_OneItem()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);
    list.Append(4);

    Assert.AreEqual(1, list.Count);
    Assert.AreEqual(4, list.Get(0));
  }

  [TestMethod]
  public void RemoveAt_And_Prepend_OneItem()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);
    list.Prepend(4);

    Assert.AreEqual(1, list.Count);
    Assert.AreEqual(4, list.Get(0));
  }
}
