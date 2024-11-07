namespace Algorithms.Algorithms.PathFinding;

public static class DijkstrasPathFinder
{
  // Weight can't be negative in Dijkstra's algorithm
  public record class Connection(int To, uint Weight);

  /// <summary>
  /// Returns shortest path between <paramref name="from"/> and <paramref name="to"/> nodes
  /// </summary>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static uint[] Solve(Connection[][] graph, uint from, uint to)
  {
    ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(from, (uint)graph.Length);

    if (to >= graph.Length)
      return [];

    if (from == to)
      return [to];

    var visited = new bool[graph.Length];
    var previous = new uint?[graph.Length];

    var distances = new uint[graph.Length];
    Array.Fill(distances, uint.MaxValue);
    distances[0] = 0;

    while (HasUnvisited(visited))
    {
      var lowest = GetLowestUnvisited(visited, distances);

      visited[lowest] = true;

      var connections = graph[lowest];

      foreach (var connection in connections)
      {
        var dist = distances[lowest] + connection.Weight;

        if (distances[connection.To] > dist)
        {
          distances[connection.To] = dist;
          previous[connection.To] = lowest;
        }
      }
    }

    var prevIndex = to;
    var path = new DataStructures.Stack<uint>();

    // Walk the previus indexes from the target to the start
    while (previous[prevIndex] != null)
    {
      path.Push(prevIndex);
      prevIndex = previous[prevIndex]!.Value;
    }

    if (path.Count != 0)
      path.Push(from); // Add first node

    return path.ToArray(DataStructures.Stack<uint>.ArrayOrder.FirstIsFirst);
  }

  private static bool HasUnvisited(bool[] visited)
    => visited.Any(x => !x);

  private static uint GetLowestUnvisited(bool[] visited, uint[] distances)
  {
    var lowest = (uint)Array.IndexOf(visited, false);

    for (uint i = 0; i < distances.Length; i++)
      if (!visited[i] && distances[i] < distances[lowest])
        lowest = i;

    return lowest;
  }
}