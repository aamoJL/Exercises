using Algorithms.Algorithms.Search;

namespace UnitTests.AlgorithmTests.SearchTests;

[TestClass]
public class WeightedAdjacencyListDepthFirstSearchTests
{
  [TestMethod]
  public void GetPath_Exists_PathReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new WeightedAdjacencyListDepthFirstSearch.Connection[][] {
      [new(1), new(3)],
      [],
      [new(0)],
      [new(1), new(2)]
    };

    var validPaths = new int[][]
    {
      [0, 1], [0, 3, 2], [0, 3],
      [2, 0],
      [3, 2, 0], [3, 1], [3, 2],
    };

    foreach (var path in validPaths)
    {
      var actual = WeightedAdjacencyListDepthFirstSearch.GetPath(graph, path.First(), path.Last());

      CollectionAssert.AreEqual(path, actual, $"Path: {path.First()} -> {path.Last()}");
    }
  }

  [TestMethod]
  public void GetPath_DoesNotExist_EmptyReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new WeightedAdjacencyListDepthFirstSearch.Connection[][] {
      [new(1), new(3)],
      [],
      [new(0)],
      [new(2), new(1)]
    };

    // 0 -> 4
    var expected = Array.Empty<int>();
    var actual = WeightedAdjacencyListDepthFirstSearch.GetPath(graph, 0, 4);

    CollectionAssert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void GetPath_Inaccessible_EmptyReturned()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new WeightedAdjacencyListDepthFirstSearch.Connection[][] {
      [new(1), new(3)],
      [],
      [new(0)],
      [new(2), new(1)]
    };

    // 1 -> 3
    var expected = Array.Empty<int>();
    var actual = WeightedAdjacencyListDepthFirstSearch.GetPath(graph, 1, 3);

    CollectionAssert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void GetPath_OutOfRange_ExceptionThrown()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new WeightedAdjacencyListDepthFirstSearch.Connection[][] {
      [new(1), new(3)],
      [],
      [new(0)],
      [new(2), new(1)]
    };

    // 4 -> 0
    Assert.ThrowsException<ArgumentOutOfRangeException>(
      () => WeightedAdjacencyListDepthFirstSearch.GetPath(graph, 4, 0));
  }

  [TestMethod]
  public void GetPath_Negative_ExceptionThrown()
  {
    /// 0 → 1
    /// ↑ ↘ ↑
    /// 2 ← 3
    var graph = new WeightedAdjacencyListDepthFirstSearch.Connection[][] {
      [new(1), new(3)],
      [],
      [new(0)],
      [new(2), new(1)]
    };

    // -1 -> 0
    Assert.ThrowsException<ArgumentOutOfRangeException>(
      () => WeightedAdjacencyListDepthFirstSearch.GetPath(graph, -1, 0));
  }
}