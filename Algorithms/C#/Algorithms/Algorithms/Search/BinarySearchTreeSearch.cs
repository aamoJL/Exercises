using Algorithms.DataStructures;

namespace Algorithms.Algorithms.Search;

/// <summary>
/// Search algorithm for BinarySearchTree
/// </summary>
public static class BinarySearchTreeSearch
{
  /// <summary>
  /// Returns true if the value exists in the tree. The tree must be ordered BinarySearchTree (left &lt;= node &lt; right)
  /// </summary>
  public static bool Exists<T>(BinaryTreeNode<T>? root, T value)
  {
    if (root == null)
      return false;

    if (Equals(root.Value, value))
      return true;

    return (Comparer<T>.Default.Compare(value, root.Value) < 0)
      ? Exists(root.Left, value)
      : Exists(root.Right, value);
  }
}
