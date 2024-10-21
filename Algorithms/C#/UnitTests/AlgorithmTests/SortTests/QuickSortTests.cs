using Algorithms.Algorithms.Sort;

namespace UnitTests.AlgorithmTests.SortTests;

[TestClass]
public class QuickSortTests
{
  [TestMethod]
  public void Sort_Odd_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2, 9 };
    var expected = new int[] { 1, 1, 2, 3, 4, 7, 9 };

    QuickSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_Even_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2 };
    var expected = new int[] { 1, 1, 2, 3, 4, 7 };

    QuickSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_Same_Sorted()
  {
    var array = new int[] { 1, 1, 1, 1, 1, 1 };
    var expected = new int[] { 1, 1, 1, 1, 1, 1 };

    QuickSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_Sorted_Sorted()
  {
    var array = new int[] { 1, 2, 3, 4, 5, 6 };
    var expected = new int[] { 1, 2, 3, 4, 5, 6 };

    QuickSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_One_Sorted()
  {
    var array = new int[] { 1 };
    var expected = new int[] { 1 };

    QuickSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_Empty_NoErrors()
  {
    var array = Array.Empty<int>();

    QuickSort.Sort(array);
  }
}
