namespace Algorithms.DataStructures;

public interface IQueue<T>
{
  int Count { get; }

  void Enqueue(T item); // "Push"
  T? Dequeue(); // "Pop"
  T? Peek();    // "First"
}

public class Queue<T>() : IQueue<T>
{
  private class Node(T? value)
  {
    public T? Value { get; } = value;
    public Node? Next { get; set; }
  }

  public Queue(T[] items) : this()
  {
    foreach (var item in items)
      Enqueue(item);
  }

  private Node? HeadNode { get; set; }
  private Node? TailNode { get; set; }

  public int Count { get; private set; } = 0;

  /// <summary>
  /// Returns and removes the first item of the queue.
  /// </summary>
  public T? Dequeue()
  {
    if (HeadNode == null)
      throw new InvalidOperationException("Head should not be null");

    var node = HeadNode;
    var value = node.Value;

    HeadNode = node.Next;
    node.Next = null;

    if (HeadNode == null)
      TailNode = null;

    Count--;

    return value;
  }

  /// <summary>
  /// Adds the item at the end of the queue
  /// </summary>
  public void Enqueue(T item)
  {
    var node = new Node(item);

    if (TailNode == null)
      HeadNode = TailNode = node;
    else
    {
      TailNode.Next = node;
      TailNode = node;
    }

    Count++;
  }

  /// <summary>
  /// Returns the value of the first item without removing it.
  /// </summary>
  /// <exception cref="InvalidOperationException"></exception>
  public T? Peek() => HeadNode != null ? HeadNode.Value : throw new InvalidOperationException("Head should not be null");
}
