namespace Algorithms.Algorithms.PathFinding.Problems;

public static class BasicMazeSolver
{
  public static (int row, int col)[] Solve(char[][] maze)
  {
    BasicGridPathFinder.FindPath(maze, 'S', 'E', ['#'], out var steps);

    return steps.Select(x => (x.Row, x.Col)).ToArray();
  }
}
