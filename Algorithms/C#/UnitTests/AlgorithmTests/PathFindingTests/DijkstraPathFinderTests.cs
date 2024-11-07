using Algorithms.Algorithms.PathFinding;

namespace UnitTests.AlgorithmTests.PathFindingTests;

[TestClass]
public class DijkstraPathFinderTests
{
  [TestMethod]
  public void Solve_Solvable_ShortestPathReturned()
  {
    var graph = new DijkstrasPathFinder.Connection[][]
    {
      [new(1, 4), new(7, 8)],
      [new(0, 4), new(2, 8),  new(7, 11)],
      [new(1, 8), new(3, 7),  new(5, 4),  new(8, 2)],
      [new(2, 7), new(4, 9),  new(5, 14)],
      [new(3, 9), new(5, 10)],
      [new(2, 4), new(3, 14), new(4, 10), new(6, 2)],
      [new(5, 2), new(7, 1),  new(8, 6)],
      [new(0, 8), new(1, 11), new(6, 1),  new(8, 7)],
      [new(2, 2), new(6, 6),  new(7, 7)],
    };

    var expectedPaths = new (uint from, uint to, uint[] expected)[]
    {
      (0, 0, [0]),
      (0, 8, [0, 1, 2, 8]),
      (0, 4, [0, 7, 6, 5, 4]),
      (0, 3, [0, 1, 2, 3])
    };

    foreach (var (from, to, expected) in expectedPaths)
    {
      var actual = DijkstrasPathFinder.Solve(graph, from, to);

      CollectionAssert.AreEqual(expected, actual);
    }
  }

  [TestMethod]
  public void Solve_DoesNotExist_EmptyArrayReturned()
  {
    var graph = new DijkstrasPathFinder.Connection[][]
    {
      [new(1, 4), new(7, 8)],
      [new(0, 4), new(2, 8),  new(7, 11)],
      [new(1, 8), new(3, 7),  new(5, 4),  new(8, 2)],
      [new(2, 7), new(4, 9),  new(5, 14)],
      [new(3, 9), new(5, 10)],
      [new(2, 4), new(3, 14), new(4, 10), new(6, 2)],
      [new(5, 2), new(7, 1),  new(8, 6)],
      [new(0, 8), new(1, 11), new(6, 1),  new(8, 7)],
      [new(2, 2), new(6, 6),  new(7, 7)],
    };

    var actual = DijkstrasPathFinder.Solve(graph, 0, 9);

    CollectionAssert.AreEqual(Array.Empty<uint>(), actual);
  }

  [TestMethod]
  public void Solve_OutOfRange_ExceptionThrown()
  {
    var graph = new DijkstrasPathFinder.Connection[][]
    {
      [new(1, 4), new(7, 8)],
      [new(0, 4), new(2, 8),  new(7, 11)],
      [new(1, 8), new(3, 7),  new(5, 4),  new(8, 2)],
      [new(2, 7), new(4, 9),  new(5, 14)],
      [new(3, 9), new(5, 10)],
      [new(2, 4), new(3, 14), new(4, 10), new(6, 2)],
      [new(5, 2), new(7, 1),  new(8, 6)],
      [new(0, 8), new(1, 11), new(6, 1),  new(8, 7)],
      [new(2, 2), new(6, 6),  new(7, 7)],
    };

    Assert.ThrowsException<ArgumentOutOfRangeException>(() => DijkstrasPathFinder.Solve(graph, 9, 0));
  }
}
