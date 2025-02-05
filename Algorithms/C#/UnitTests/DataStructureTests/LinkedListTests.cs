using Algorithms.DataStructures;

namespace UnitTests.DataStructureTests;

[TestClass]
public class LinkedListTests
{
  [TestMethod]
  public void Constructor_WithArray_NodesAdded()
  {
    var array = new int[] { 1, 2, 3 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    Assert.AreEqual(array.Length, list.Count);

    CollectionAssert.AreEqual(array, list.ToArray());
    CollectionAssert.AreEqual(array.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void GetReversedList_ListReturned()
  {
    var array = new int[] { 1, 2, 3 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    var reversedList = list.GetReversedList();

    CollectionAssert.AreEqual(array.Reverse().ToArray(), reversedList.ToArray());
  }

  [TestMethod]
  public void Append_ItemAppended()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2]);

    list.Append(3);

    var expected = new int[] { 1, 2, 3 };

    Assert.AreEqual(3, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void Get_Found_ItemReturned()
  {
    var array = new int[] { 1, 2, 3 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    for (var i = 0; i < list.Count; i++)
      Assert.AreEqual(array[i], list.Get(i));
  }

  [TestMethod]
  public void Get_NotFound_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(3));
  }

  [TestMethod]
  public void InsertAt_ItemInserted()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.InsertAt(index: 1, item: 4);

    var expected = new int[] { 1, 4, 2, 3 };

    Assert.AreEqual(4, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void InsertAt_EmptyList_ItemInserted()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>();

    list.InsertAt(index: 0, item: 1);

    var expected = new int[] { 1 };

    Assert.AreEqual(1, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
  }

  [TestMethod]
  public void InsertAt_OutOfRange_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>();

    Assert.ThrowsException<IndexOutOfRangeException>(() => list.InsertAt(index: 1, item: 2));
  }

  [TestMethod]
  public void Prepend_ItemPrepended()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2]);

    list.Prepend(0);

    var expected = new int[] { 0, 1, 2 };

    Assert.AreEqual(3, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void Remove_First_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(array[0]);

    var expected = new int[] { 1, 2 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void Remove_Middle_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(array[1]);

    var expected = new int[] { 0, 2 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void Remove_Last_ItemRemoved()
  {
    var array = new int[] { 0, 1, 2 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    list.Remove(array[2]);

    var expected = new int[] { 0, 1 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
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

    var expected = new int[] { 2, 3 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void RemoveAt_Middle_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.RemoveAt(1);

    var expected = new int[] { 1, 3 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void RemoveAt_Last_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1, 2, 3]);

    list.RemoveAt(2);

    var expected = new int[] { 1, 2 };

    Assert.AreEqual(2, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
    CollectionAssert.AreEqual(expected.Reverse().ToArray(), list.GetReversedList().ToArray());
  }

  [TestMethod]
  public void RemoveAt_OnlyOne_ItemRemoved()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);

    var expected = Array.Empty<int>();

    Assert.AreEqual(0, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
  }

  [TestMethod]
  public void RemoveAt_OutOfRange_ExceptionThrown()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>();

    Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(0));
  }

  [TestMethod]
  public void RemoveAt_And_Append_OneItem()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);
    list.Append(4);

    var expected = new int[] { 4 };

    Assert.AreEqual(1, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
  }

  [TestMethod]
  public void RemoveAt_And_Prepend_OneItem()
  {
    var list = new Algorithms.DataStructures.LinkedList<int>([1]);

    list.RemoveAt(0);
    list.Prepend(4);

    var expected = new int[] { 4 };

    Assert.AreEqual(1, list.Count);
    CollectionAssert.AreEqual(expected, list.ToArray());
  }

  [TestMethod]
  public void ToArray_Empty_EmptyArrayReturned()
  {
    var array = Array.Empty<int>();
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    CollectionAssert.AreEqual(array, list.ToArray());
  }

  [TestMethod]
  public void ToArray_HasItems_ArrayReturned()
  {
    var array = new int[] { 4, 5, 2, 3, 5, 1 };
    var list = new Algorithms.DataStructures.LinkedList<int>(array);

    CollectionAssert.AreEqual(array, list.ToArray());
    CollectionAssert.AreEqual(array.Reverse().ToArray(), list.GetReversedList().ToArray());
  }
}