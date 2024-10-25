﻿using Algorithms.Algorithms.Sort;

namespace UnitTests.AlgorithmTests.SortTests;

[TestClass]
public class BubbleSortTests
{
  [TestMethod]
  public void Sort_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2 };
    var expected = new int[] { 1, 1, 2, 3, 4, 7 };

    BubbleSort.Sort(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void Sort_Empty_NoErrors()
  {
    var array = Array.Empty<int>();

    BubbleSort.Sort(array);
  }

  [TestMethod]
  public void SortOptimized_Sorted()
  {
    var array = new int[] { 1, 3, 7, 4, 1, 2 };
    var expected = new int[] { 1, 1, 2, 3, 4, 7 };

    BubbleSort.SortOptimized(array);

    CollectionAssert.AreEqual(expected, array);
  }

  [TestMethod]
  public void SortOptimized_Empty_NoErrors()
  {
    var array = Array.Empty<int>();

    BubbleSort.SortOptimized(array);
  }
}