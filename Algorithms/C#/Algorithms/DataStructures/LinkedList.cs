namespace Algorithms.DataStructures;

public interface ILinkedList<T>
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
  private class Node(T? value)
  {
    public T? Value { get; } = value;
    public Node? Next { get; set; }
  }

  public LinkedList(T[] items) : this()
  {
    foreach (var item in items)
      Append(item);
  }

  private Node? HeadNode { get; set; }
  private Node? TailNode { get; set; }

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
      TailNode.Next = newNode;
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
        leftNode.Next = newNode;

      newNode.Next = rightNode;

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
      newNode.Next = HeadNode;
      HeadNode = newNode;
    }

    Count++;
  }

  public void Remove(T item)
  {
    if (item == null) return;

    Node? lastNode = null;
    var currentNode = HeadNode;

    for (var i = 0; i < Count; i++)
    {
      if (currentNode?.Value?.Equals(item) == true)
      {
        // Item found

        var nextNode = currentNode?.Next;

        if (lastNode == null)
        {
          // Current node is head node
          HeadNode = nextNode;
        }

        if (nextNode == null)
        {
          // current node is tail node
          if (lastNode != null)
            lastNode.Next = null;

          TailNode = lastNode;
        }
        else
        {
          if (lastNode != null)
            lastNode.Next = nextNode;

          currentNode!.Next = null;
        }

        Count--;

        break;
      }

      lastNode = currentNode;
      currentNode = lastNode?.Next;
    }
  }

  public void RemoveAt(int index)
  {
    if (index >= Count)
      throw new IndexOutOfRangeException();

    var lastNode = index > 0 ? GetNode(index - 1) : null;
    var currentNode = lastNode?.Next ?? HeadNode;

    if (currentNode == HeadNode)
    {
      HeadNode = currentNode?.Next;
      currentNode!.Next = null;

      if (HeadNode == null)
        TailNode = null;
    }

    if (currentNode == TailNode)
      TailNode = lastNode;

    if (lastNode != null)
      lastNode.Next = currentNode!.Next;

    currentNode!.Next = null;

    Count--;
  }

  private Node? GetNode(int index)
  {
    if (index >= Count)
      throw new IndexOutOfRangeException();

    var node = HeadNode;

    for (var i = 0; i < index; i++)
      node = node?.Next;

    return node;
  }
}
