namespace Algorithms.DataStructures;

public abstract class BinaryTree
{
  public enum TraversalStrategy
  {
    /// <summary>Value -> Left -> Right</summary>
    PreOrder,
    /// <summary>Left -> Value -> Right</summary>
    InOrder,
    /// <summary>Left -> Right -> Value</summary>
    PostOrder
  }
}

/// <summary>
/// Tree structure with two leaves per node
/// </summary>
public class BinaryTree<T>() : BinaryTree
{
  public class Node(T value, Node? left = null, Node? right = null)
  {
    public T Value { get; set; } = value;
    public Node? Left { get; set; } = left;
    public Node? Right { get; set; } = right;
  }

  public BinaryTree(Node root) : this()
    => Root = root;

  public Node? Root { get; set; }

  public T?[] ToArray(TraversalStrategy strategy)
  {
    return strategy switch
    {
      TraversalStrategy.PreOrder => ToArrayTraversal(Root, new Queue<T>(), strategy).ToArray(),
      TraversalStrategy.InOrder => ToArrayTraversal(Root, new Queue<T>(), strategy).ToArray(),
      TraversalStrategy.PostOrder => ToArrayTraversal(Root, new Queue<T>(), strategy).ToArray(),
      _ => throw new NotImplementedException(),
    };
  }

  private static Queue<T> ToArrayTraversal(Node? root, Queue<T> items, TraversalStrategy strategy)
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
    }

    return items;
  }
}
