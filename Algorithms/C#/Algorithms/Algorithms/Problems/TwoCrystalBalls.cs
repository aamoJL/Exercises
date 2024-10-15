namespace Algorithms.Algorithms.Problems;

/// <summary>
/// Problem: Find the breaking point of a crystal ball using two balls.
/// </summary>
public class TwoCrystalBalls
{
  public class Ball(int breakPoint)
  {
    public static readonly int MaxBreakingPoint = 100;

    public int BreakingPoint { get; init; } = Math.Min(breakPoint, MaxBreakingPoint);
    public bool Broken { get; private set; } = false;

    public bool Drop(int height)
    {
      if (Broken) return false;

      return Broken = height >= BreakingPoint;
    }
  }

  /// <summary>
  /// Returns the breaking point of the ball using linear search algorithm.
  /// </summary>
  public static int FindBreakingPointLinearWalk(Ball ball)
  {
    var value = -1;

    while (!ball.Broken)
      ball.Drop(++value);

    return value;
  }

  /// <summary>
  /// Returns the breaking point of the ball using search algorithm that skips points.
  /// Has better performance than the linear walk.
  /// </summary>
  public static int FindBreakingPointLinearSkipping(Ball first, Ball second)
  {
    var skip = 2;
    var value = -1;

    while (!first.Broken)
      first.Drop(value += skip);

    return second.Drop(value - 1) ? value - 1 : value;
  }

  /// <summary>
  /// Returns the breaking point of the ball using search algorithm that skips points using square root of the max distance.
  /// Has better performance than the linear skipping
  /// </summary>
  public static int FindBreakingPointSquareRootSkipping(Ball first, Ball second)
  {
    var skip = (int)MathF.Floor((float)Math.Sqrt(Ball.MaxBreakingPoint));

    for (var i = 0; i <= Ball.MaxBreakingPoint; i += skip)
    {
      if (first.Drop(i))
      {
        // Go back to the last step
        var last = i - skip;

        // Walk the remaining points
        for (var j = last; j <= Ball.MaxBreakingPoint; j++)
          if (second.Drop(j))
            return j;
      }
    }

    return -1;
  }
}
