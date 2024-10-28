using Algorithms.DataStructures;

namespace Algorithms.Algorithms.Search;

public static class BinaryTreeSearch
{
  public static bool Exists<T>(BinaryTreeNode<T> tree, T value)
    => Traversal(tree, value);

  private static bool Traversal<T>(BinaryTreeNode<T>? root, T value)
  {
    if (root == null)
      return false;

    if (root?.Value?.Equals(value) == true)
      return true;

    if (Traversal(root?.Left, value) || Traversal(root?.Right, value))
      return true;

    return false;
  }
}
