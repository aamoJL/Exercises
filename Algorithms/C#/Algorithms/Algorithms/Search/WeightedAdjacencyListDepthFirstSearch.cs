namespace Algorithms.Algorithms.Search;

public static class WeightedAdjacencyListDepthFirstSearch
{
  public record class Connection(uint To, int Weight = 1);

  /// <summary>
  /// Returns path between <paramref name="from"/> and <paramref name="to"/> nodes.
  /// </summary>
  /// <param name="graph">List of node connection lists</param>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static uint[] GetPath(Connection[][] graph, uint from, uint to)
  {
    var seen = new bool[graph.Length];
    var path = new DataStructures.Stack<uint>();

    Traversal(graph, from, to, seen, path);

    return path.ToArray(DataStructures.Stack<uint>.ArrayOrder.LastIsFirst);
  }

  private static bool Traversal(Connection[][] graph, uint current, uint target, bool[] seen, DataStructures.Stack<uint> path)
  {
    ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(current, (uint)graph.Length);

    if (seen[current])
      return false;

    if (Equals(current, target))
    {
      path.Push(current);
      return true;
    }

    path.Push(current);
    seen[current] = true;

    foreach (var connection in graph[current])
      if (Traversal(graph, connection.To, target, seen, path))
        return true;

    path.Pop();

    return false;
  }
}
