namespace Algorithms.Algorithms.PathFinding;

public static class BasicGridPathFinder
{
  public readonly struct Cell(int row, int col)
  {
    public int Row { get; } = row;
    public int Col { get; } = col;
  };

  private static readonly (int row, int col)[] _directions = [
      (-1, 0), // Up
      (0, -1), // Left
      (1, 0), // Down
      (0, 1)]; // Right

  public static bool FindPath<T>(T[][] grid, T startValue, T endValue, T[] invalidCellValues, out Cell[] steps)
  {
    var path = new DataStructures.Stack<Cell>();
    var found = false;

    if (FindCell(grid, startValue) is Cell startingCell && FindCell(grid, endValue) is not null)
      found = WalkPath(grid, invalidCellValues, endValue, startingCell, path);

    steps = path.ToArray(DataStructures.Stack<Cell>.ArrayOrder.LastIsFirst);

    return found;
  }

  private static bool WalkPath<T>(T[][] grid, T[] invalidCellValues, T endValue, Cell current, DataStructures.Stack<Cell> path)
  {
    #region Base Case

    // Path overlap
    if (path.Contains(current))
      return false;

    // Out of Bounds
    if (current.Row < 0 || current.Row >= grid.Length || current.Col < 0 || current.Col >= grid[0].Length)
      return false;

    var currentValue = grid[current.Row][current.Col];

    // Reached the End
    if (currentValue?.Equals(endValue) is true)
    {
      path.Push(current);
      return true;
    }

    // Current cell is invalid (wall etc.)
    if (invalidCellValues.Contains(currentValue))
      return false;

    path.Push(current); // Valid cell

    #endregion

    #region Recursive Case

    foreach (var (rowDir, colDir) in _directions)
      if (WalkPath(grid, invalidCellValues, endValue, current: new Cell(current.Row + rowDir, current.Col + colDir), path))
        return true;

    #endregion

    path.Pop(); // Go back to the previous cell

    return false; // No path found
  }

  private static Cell? FindCell<T>(T[][] grid, T value)
  {
    for (var row = 0; row < grid.Length; row++)
      if (Array.IndexOf(grid[row], value) is var index && index != -1)
        return new Cell(row, index);

    return null;
  }
}