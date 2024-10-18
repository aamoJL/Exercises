namespace Algorithms.Algorithms.PathFinding.Problems;

public static class BasicMazeSolver
{
  public static (int row, int index)[] Solve(char[][] maze)
  {
    var path = new DataStructures.Stack<(int row, int index)>();

    // Find starting cell
    var start = new Func<(int row, int index)?>(() =>
    {
      for (var row = 0; row < maze.Length; row++)
        if (Array.IndexOf(maze[row], 'S') is var index && index != -1)
          return (row, index);

      return null;
    })();

    if (start != null)
      FindPath(maze, start!.Value, path);

    return path.ToArray(DataStructures.Stack<(int row, int index)>.ArrayOrder.LastIsFirst);
  }

  private static bool FindPath(char[][] maze, (int row, int index) current, DataStructures.Stack<(int row, int index)> path)
  {
    (int row, int index)[] directions = [
      (-1, 0), // Up
      (0, -1), // Left
      (1, 0), // Down
      (0, 1), // Right
      ];

    #region Base Case

    // Path overlap
    if (path.Contains(current))
      return false;

    // Out of Bounds
    if (current.row < 0 || current.row >= maze.Length || current.index < 0 || current.index >= maze[0].Length)
      return false;

    var currentValue = maze[current.row][current.index];

    // Reached the End
    if (currentValue == 'E')
    {
      path.Push(current);
      return true;
    }

    // Hit a Wall
    if (currentValue == '#')
      return false;

    path.Push(current); // Valid cell to continue from

    #endregion Base Case

    #region Recursive Case

    foreach (var (rowDir, indexDir) in directions)
      if (FindPath(maze, current: (current.row + rowDir, current.index + indexDir), path)) // Recursion
        return true;

    #endregion Recursive Case

    path.Pop(); // Go back to the previous cell

    return false; // No path found
  }
}
