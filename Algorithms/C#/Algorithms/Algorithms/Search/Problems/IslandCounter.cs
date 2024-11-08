namespace Algorithms.Algorithms.Search.Problems;

/*
 * Problem: Count the islands on a grid
 * 
 * Example grid with 3 islands (1 is land):
 * [0,1,0,0,1]
 * [0,0,0,1,1]
 * [0,0,1,0,1]
 * [0,0,0,0,0]
 */

public static class IslandCounter
{
  public static int Solve(int[][] grid)
  {
    var visited = new bool[grid.Length][];

    for (var i = 0; i < grid.Length; i++)
      visited[i] = new bool[grid[i].Length];

    var islandCount = 0;

    for (var y = 0; y < grid.Length; y++)
    {
      for (var x = 0; x < grid[y].Length; x++)
      {
        if (visited[y][x])
          continue;

        if (grid[y][x] == 1)
        {
          islandCount++;
          WalkIsland(grid, visited, (x, y));
        }
        else
          visited[y][x] = true;
      }
    }

    return islandCount;
  }

  /// <summary>
  /// Sets all land cells thats connected to the <paramref name="cell"/> as visited
  /// </summary>
  private static void WalkIsland(int[][] grid, bool[][] visited, (int x, int y) cell)
  {
    var (x, y) = cell;

    // Out of bounds
    if (y < 0 || y >= grid.Length || x < 0 || x >= grid[y].Length)
      return;

    if (visited[y][x])
      return;

    if (grid[y][x] == 1)
    {
      visited[y][x] = true;

      WalkIsland(grid, visited, (x - 1, y)); // Left
      WalkIsland(grid, visited, (x, y - 1)); // Up
      WalkIsland(grid, visited, (x + 1, y)); // Right
      WalkIsland(grid, visited, (x, y + 1)); // Down
    }
  }
}
