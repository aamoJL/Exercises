using Algorithms.Algorithms.Sort;

namespace UnitTests.Algorithms.Sort;

[TestClass]
public class BubbleSortTests
{
  [TestMethod]
  public void Sort_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2 };

    BubbleSort.Sort(array);

    CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 4, 7 }, array);
  }

  [TestMethod]
  public void SortOptimized_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2 };

    BubbleSort.SortOptimized(array);

    CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 4, 7 }, array);
  }
}
