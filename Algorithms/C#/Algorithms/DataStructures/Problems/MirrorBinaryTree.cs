namespace Algorithms.DataStructures.Problems;

public class MirrorBinaryTree
{
  /// <summary>
  /// Mirrors the given binary tree
  /// </summary>
  public static void Mirror<T>(BinaryTreeNode<T> tree)
  {
    // mirror using breadth first traversal
    var queue = new Queue<BinaryTreeNode<T>>();
    var curr = tree;

    while (curr != null)
    {
      // mirror current node
      (curr.Right, curr.Left) = (curr.Left, curr.Right);

      // Add left and right to the queue
      if (curr.Left != null) queue.Enqueue(curr.Left);
      if (curr.Right != null) queue.Enqueue(curr.Right);

      curr = queue.Count != 0 ? queue.Dequeue() : null;
    }
  }
}
