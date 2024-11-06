using Algorithms.Algorithms.Search;

namespace UnitTests.AlgorithmTests.SearchTests;

[TestClass]
public class WeightedAdjacencyMatrixBreadthFirstSearchTests
{
  [TestMethod]
  public void GetPath_Exists_PathReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new int[][]
    {
      [0, 1, 0, 1],
      [0, 0, 0, 0],
      [1, 0, 0, 0],
      [0, 1, 1, 0],
    };

    // 0 -> 2
    var expected = new int[] { 0, 3, 2 };
    var actual = WeightedAdjacencyMatrixBreadthFirstSearch.GetPath(graph, 0, 2);

    CollectionAssert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void GetPath_DoesNotExist_EmptyReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new int[][]
    {
      [0, 1, 0, 1],
      [0, 0, 0, 0],
      [1, 0, 0, 0],
      [0, 1, 1, 0],
    };

    // 0 -> 4
    var expected = Array.Empty<int>();
    var actual = WeightedAdjacencyMatrixBreadthFirstSearch.GetPath(graph, 0, 4);

    CollectionAssert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void GetPath_Inaccessible_EmptyReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new int[][]
    {
      [0, 1, 0, 1],
      [0, 0, 0, 0],
      [1, 0, 0, 0],
      [0, 1, 1, 0],
    };

    // 1 -> 3
    var expected = Array.Empty<int>();
    var actual = WeightedAdjacencyMatrixBreadthFirstSearch.GetPath(graph, 1, 3);

    CollectionAssert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void GetPath_OutOfRange_ExceptionThrown()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new int[][]
    {
      [0, 1, 0, 1],
      [0, 0, 0, 0],
      [1, 0, 0, 0],
      [0, 1, 1, 0],
    };

    // 4 -> 0
    Assert.ThrowsException<ArgumentOutOfRangeException>(
      () => WeightedAdjacencyMatrixBreadthFirstSearch.GetPath(graph, graph.Length, 0));
  }

  [TestMethod]
  public void GetPath_Negative_ExceptionThrown()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new int[][]
    {
      [0, 1, 0, 1],
      [0, 0, 0, 0],
      [1, 0, 0, 0],
      [0, 1, 1, 0],
    };

    // -1 -> 0
    Assert.ThrowsException<ArgumentOutOfRangeException>(
      () => WeightedAdjacencyMatrixBreadthFirstSearch.GetPath(graph, -1, 0));
  }
}
