namespace Algorithms.DataStructures;

public interface IStack<T>
{
  int Count { get; }
  T? Pop();
  void Push(T item);
  T? Peek();
}

public class Stack<T>() : IStack<T>
{
  public enum ArrayOrder { FirstIsFirst, LastIsFirst }

  private class Node(T? value)
  {
    public T? Value { get; } = value;
    public Node? Next { get; set; }
  }

  public Stack(T[] items) : this()
  {
    foreach (var item in items)
      Push(item);
  }

  public int Count { get; private set; } = 0;

  private Node? HeadNode { get; set; }

  public T? Pop()
  {
    if (HeadNode != null)
    {
      var node = HeadNode;
      var next = node?.Next;

      HeadNode = next;

      Count--;

      return node!.Value;
    }
    else
      throw new InvalidOperationException();
  }

  public void Push(T item)
  {
    var old = HeadNode;
    var node = new Node(item);

    HeadNode = node;
    node.Next = old;

    Count++;
  }

  public T? Peek() => HeadNode != null ? HeadNode.Value : throw new InvalidOperationException();

  public bool Contains(T item)
  {
    var node = HeadNode;

    for (var i = 0; i < Count; i++)
    {
      if (node != null && node.Value?.Equals(item) is true)
        return true;
      else
        node = node?.Next;
    }

    return false;
  }

  /// <summary>
  /// Returns the stack as an array. The stack stays unchanged.
  /// </summary>
  /// <param name="order">Order of the items in the returned array. FirstIsFirst returns the items in the same order as <see cref="Pop"/></param>
  public T?[] ToArray(ArrayOrder order)
  {
    var array = new T?[Count];
    var node = HeadNode;

    for (var i = 0; i < Count; i++)
    {
      if (node != null)
      {
        if (order == ArrayOrder.FirstIsFirst)
          array[i] = node.Value;
        else
          array[Count - 1 - i] = node.Value;

        node = node.Next;
      }
    }

    return array;
  }
}