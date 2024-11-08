using Algorithms.Algorithms.Search.Problems;

namespace UnitTests.AlgorithmTests.SearchTests.ProblemTests;

[TestClass]
public class TwoCrystalBallsTests
{
  [TestMethod]
  public void FindBreakingPointLinearWalk()
  {
    for (var i = 0; i < 102; i++)
    {
      var ball = new TwoCrystalBalls.Ball(breakPoint: i);
      var result = TwoCrystalBalls.FindBreakingPointLinearWalk(ball);

      Assert.AreEqual(ball.BreakingPoint, result);
    }
  }

  [TestMethod]
  public void FindBreakingPointLinearSkipping()
  {
    for (var i = 0; i < 102; i++)
    {
      var ball1 = new TwoCrystalBalls.Ball(breakPoint: i);
      var ball2 = new TwoCrystalBalls.Ball(breakPoint: i);
      var result = TwoCrystalBalls.FindBreakingPointLinearSkipping(ball1, ball2);

      Assert.AreEqual(ball1.BreakingPoint, result);
    }
  }

  [TestMethod]
  public void FindBreakingPointSquareRootSkipping()
  {
    for (var i = 0; i < 102; i++)
    {
      var ball1 = new TwoCrystalBalls.Ball(breakPoint: i);
      var ball2 = new TwoCrystalBalls.Ball(breakPoint: i);
      var result = TwoCrystalBalls.FindBreakingPointSquareRootSkipping(ball1, ball2);

      Assert.AreEqual(ball1.BreakingPoint, result);
    }
  }
}