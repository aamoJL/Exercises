namespace Algorithms.DataStructures;

public abstract class BinaryTree
{
  public enum TraversalStrategy
  {
    /// <summary>From top, root before left leaf</summary>
    PreOrder,
    /// <summary>From botttom, left leaf before root</summary>
    InOrder,
    /// <summary>From bottom, left and right leaves before root</summary>
    PostOrder,
    /// <summary>From top, roots level by level</summary>
    BreadthFirst,
  }

  /// <summary>
  /// Compares two binary trees structurally.
  /// </summary>
  /// <returns><see langword="true"/> if the trees are structurally equal, and has the same values; otherwise <see langword="false"/></returns>
  public static bool Compare<T>(BinaryTreeNode<T>? rootA, BinaryTreeNode<T>? rootB)
  {
    if (rootA == null && rootB == null)
      return true;

    if (rootA == null || rootB == null)
      return false;

    if (!Equals(rootA.Value, rootB.Value))
      return false;

    return Compare(rootA?.Left, rootB?.Left) && Compare(rootA?.Right, rootB?.Right);
  }
}

/// <summary>
/// Tree structure with two leaves per node
/// </summary>
public class BinaryTreeNode<T>(T value) : BinaryTree
{
  public T Value { get; set; } = value;
  public BinaryTreeNode<T>? Left { get; set; }
  public BinaryTreeNode<T>? Right { get; set; }

  public T?[] ToArray(TraversalStrategy strategy)
  {
    return strategy switch
    {
      TraversalStrategy.PreOrder => PreOrderTraversal(this, new Queue<T>()).ToArray(),
      TraversalStrategy.InOrder => InOrderTraversal(this, new Queue<T>()).ToArray(),
      TraversalStrategy.PostOrder => PostOrderTraversal(this, new Queue<T>()).ToArray(),
      TraversalStrategy.BreadthFirst => BreadthFirstTraversal(this, new Queue<T>()).ToArray(),
      _ => throw new NotImplementedException(),
    };
  }

  private static Queue<T> PreOrderTraversal(BinaryTreeNode<T>? root, Queue<T> items)
  {
    if (root == null)
      return items;

    items.Enqueue(root.Value);
    PreOrderTraversal(root.Left, items);
    PreOrderTraversal(root.Right, items);

    return items;
  }

  private static Queue<T> InOrderTraversal(BinaryTreeNode<T>? root, Queue<T> items)
  {
    if (root == null)
      return items;

    InOrderTraversal(root.Left, items);
    items.Enqueue(root.Value);
    InOrderTraversal(root.Right, items);

    return items;
  }

  private static Queue<T> PostOrderTraversal(BinaryTreeNode<T>? root, Queue<T> items)
  {
    if (root == null)
      return items;

    PostOrderTraversal(root.Left, items);
    PostOrderTraversal(root.Right, items);
    items.Enqueue(root.Value);

    return items;
  }

  private static Queue<T> BreadthFirstTraversal(BinaryTreeNode<T>? root, Queue<T> items)
  {
    if (root == null)
      return items;

    var queue = new Queue<BinaryTreeNode<T>?>([root]);

    while (queue.Count > 0)
    {
      if (queue.Dequeue() is not BinaryTreeNode<T> node)
        continue;

      items.Enqueue(node.Value);

      queue.Enqueue(node.Left);
      queue.Enqueue(node.Right);
    }

    return items;
  }
}
