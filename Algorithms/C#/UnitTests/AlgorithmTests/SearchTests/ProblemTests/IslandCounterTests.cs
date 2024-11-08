using Algorithms.Algorithms.Search.Problems;

namespace UnitTests.AlgorithmTests.SearchTests.ProblemTests;

[TestClass]
public class IslandCounterTests
{
  [TestMethod]
  public void Solve()
  {
    var grid = new int[][]
    {
      [0,1,0,0,1],
      [0,0,0,1,1],
      [0,0,1,0,1],
      [0,0,0,0,0],
    };

    var result = IslandCounter.Solve(grid);

    Assert.AreEqual(3, result);
  }
}