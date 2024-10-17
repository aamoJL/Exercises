﻿namespace Algorithms.DataStructures;

public interface IStack<T>
{
  int Count { get; }
  T? Pop();
  void Push(T item);
  T? Peek();
}

public class Stack<T>() : IStack<T>
{
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
}
