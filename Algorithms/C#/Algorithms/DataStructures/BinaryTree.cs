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
      TraversalStrategy.PreOrder => ToArrayTraversal(this, new Queue<T>(), strategy).ToArray(),
      TraversalStrategy.InOrder => ToArrayTraversal(this, new Queue<T>(), strategy).ToArray(),
      TraversalStrategy.PostOrder => ToArrayTraversal(this, new Queue<T>(), strategy).ToArray(),
      TraversalStrategy.BreadthFirst => ToArrayTraversal(this, new Queue<T>(), strategy).ToArray(),
      _ => throw new NotImplementedException(),
    };
  }

  private static Queue<T> ToArrayTraversal(BinaryTreeNode<T>? root, Queue<T> items, TraversalStrategy strategy)
  {
    if (root == null)
      return items;

    switch (strategy)
    {
      case TraversalStrategy.PreOrder:
        items.Enqueue(root.Value);
        ToArrayTraversal(root.Left, items, strategy);
        ToArrayTraversal(root.Right, items, strategy);
        break;
      case TraversalStrategy.InOrder:
        ToArrayTraversal(root.Left, items, strategy);
        items.Enqueue(root.Value);
        ToArrayTraversal(root.Right, items, strategy);
        break;
      case TraversalStrategy.PostOrder:
        ToArrayTraversal(root.Left, items, strategy);
        ToArrayTraversal(root.Right, items, strategy);
        items.Enqueue(root.Value);
        break;
      case TraversalStrategy.BreadthFirst:
        var queue = new Queue<BinaryTreeNode<T>?>([root]);

        while (queue.Count > 0)
        {
          if (queue.Dequeue() is not BinaryTreeNode<T> node)
            continue;

          items.Enqueue(node.Value);

          queue.Enqueue(node.Left);
          queue.Enqueue(node.Right);
        }
        break;
    }

    return items;
  }
}
