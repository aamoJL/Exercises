namespace Algorithms.Algorithms.Search;

/*
 * Weighted adjucency matrix example:
 * 
 * Graph:
 * 0 → 1
 * ↑ ↘ ↑
 * 2 ← 3
 * 
 * Matrix:
 *    0  1  2  3
 * 0 [0, 1, 0, 1],
 * 1 [0, 0, 0, 0],
 * 2 [1, 0, 0, 0],
 * 3 [0, 1, 1, 0],
 */

/// <summary>
/// Breath-first search for weighted adjacency matrix
/// </summary>
public static class WeightedAdjacencyMatrixBreadthFirstSearch
{
  /// <summary>
  /// Returns path between <paramref name="from"/> and <paramref name="to"/> nodes
  /// </summary>
  /// <returns>Array of node indexes or empty array if no path was found</returns>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static int[] GetPath(int[][] graph, int from, int to)
  {
    ArgumentOutOfRangeException.ThrowIfNegative(from);
    ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(from, graph.Length);

    if (to < 0 || to >= graph.Length)
      return [];

    var seen = new bool[graph.Length];
    var prev = new int[graph.Length];
    var queue = new DataStructures.Queue<int>([from]);

    Array.Fill(prev, -1);
    seen[from] = true;

    while (queue.Count > 0)
    {
      var current = queue.Dequeue();

      if (Equals(current, to))
        break;

      var connections = graph[current];

      for (var i = 0; i < connections.Length; i++)
      {
        if (connections[i] == 0 || seen[i])
          continue;

        seen[i] = true;
        prev[i] = current;
        queue.Enqueue(i);
      }
    }

    var curr = to;
    var pathStack = new DataStructures.Stack<int>();

    while (prev[curr] != -1)
    {
      pathStack.Push(curr);
      curr = prev[curr];
    }

    return pathStack.Count == 0
      ? []
      : [from, .. pathStack.ToArray(DataStructures.Stack<int>.ArrayOrder.FirstIsFirst)];
  }
}
