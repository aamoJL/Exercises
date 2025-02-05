using System.Collections;

namespace Algorithms.DataStructures;

public interface ILinkedList<T> : IEnumerable<T>
{
  public int Count { get; }

  public void Append(T item);
  public T? Get(int index);
  public void InsertAt(int index, T item);
  public void Prepend(T item);
  public void Remove(T item);
  public void RemoveAt(int index);
}

public class LinkedList<T>() : ILinkedList<T>
{
  public class Node(T value)
  {
    public T Value { get; } = value;
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
  }

  public class LinkedListEnumerator(Node? headNode) : IEnumerator<T>
  {
    private Node? HeadNode { get; } = headNode;
    private Node? CurrentNode { get; set; } = null;

    private bool Started { get; set; } = false;

    public T Current
    {
      get
      {
        if (CurrentNode == null)
          throw new InvalidOperationException("Current node is null");

        return CurrentNode.Value;
      }
    }

    public bool MoveNext()
    {
      if (Started)
        CurrentNode = CurrentNode?.Next;
      else
      {
        CurrentNode = HeadNode;
        Started = true;
      }

      return CurrentNode != null;
    }

    public void Reset()
    {
      CurrentNode = null;
      Started = false;
    }

    public void Dispose() => GC.SuppressFinalize(this);

    object? IEnumerator.Current => Current;
  }

  public LinkedList(T[] items) : this()
  {
    foreach (var item in items)
      Append(item);
  }

  public Node? HeadNode { get; protected set; }
  public Node? TailNode { get; protected set; }

  public int Count { get; private set; } = 0;

  /// <summary>
  /// Adds item at the end of the list.
  /// </summary>
  public void Append(T item)
  {
    var newNode = new Node(item);

    if (TailNode == null)
      HeadNode = TailNode = newNode;
    else
    {
      // Set new node as the tail node
      LinkNodes(TailNode, newNode);
      TailNode = newNode;
    }

    Count++;
  }

  public T? Get(int index)
  {
    if (index >= Count)
      throw new IndexOutOfRangeException();

    var node = HeadNode;

    for (var i = 0; i < index; i++)
      node = node?.Next;

    return node == null ? throw new NullReferenceException() : node.Value;
  }

  public void InsertAt(int index, T item)
  {
    if (index >= Count + 1)
      throw new IndexOutOfRangeException();

    if (index == Count)
      Append(item);
    else if (index == 0)
      Prepend(item);
    else
    {
      // New node will be inserted before the old node
      var newNode = new Node(item);
      var leftNode = GetNode(index - 1);
      var rightNode = leftNode?.Next;

      if (leftNode != null)
        LinkNodes(leftNode, newNode);

      if (rightNode != null)
        LinkNodes(newNode, rightNode);

      Count++;
    }
  }

  /// <summary>
  /// Adds item at the start of the list.
  /// </summary>
  public void Prepend(T item)
  {
    var newNode = new Node(item);

    if (HeadNode == null)
      HeadNode = TailNode = newNode;
    else
    {
      // Set new node as the head node
      LinkNodes(newNode, HeadNode);
      HeadNode = newNode;
    }

    Count++;
  }

  public void Remove(T item)
  {
    var currentNode = HeadNode;

    do
    {
      if (currentNode?.Value?.Equals(item) == true)
      {
        if (currentNode == HeadNode)
          HeadNode = currentNode.Next;

        if (currentNode == TailNode)
          TailNode = currentNode.Previous;

        LinkNodes(currentNode.Previous, currentNode.Next);

        currentNode.Next = null;
        currentNode.Previous = null;

        Count--;

        break;
      }
    }
    while ((currentNode = currentNode?.Next) != null);
  }

  public void RemoveAt(int index)
  {
    if (index >= Count)
      throw new IndexOutOfRangeException();

    var currentNode = GetNode(index) ?? throw new NullReferenceException("Node is null");

    if (currentNode == HeadNode)
      HeadNode = currentNode.Next;

    if (currentNode == TailNode)
      TailNode = currentNode.Previous;

    LinkNodes(currentNode.Previous, currentNode.Next);

    currentNode.Previous = null;
    currentNode.Next = null;

    Count--;
  }

  protected Node? GetNode(int index)
  {
    if (index >= Count)
      throw new IndexOutOfRangeException();

    var node = HeadNode;

    for (var i = 0; i < index; i++)
      node = node?.Next;

    return node;
  }

  protected static void LinkNodes(Node? left, Node? right)
  {
    if (left != null)
      left.Next = right;

    if (right != null)
      right.Previous = left;
  }

  public IEnumerator<T> GetEnumerator() => new LinkedListEnumerator(HeadNode);

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class LinkedListExtensions
{
  public static LinkedList<T> GetReversedList<T>(this LinkedList<T> self)
  {
    var reversedValues = new T[self.Count];
    var currentNode = self.TailNode;

    for (var i = 0; i < self.Count; i++)
    {
      if (currentNode == null)
        break;

      reversedValues[i] = currentNode.Value;

      currentNode = currentNode.Previous;
    }

    return new(reversedValues);
  }
}