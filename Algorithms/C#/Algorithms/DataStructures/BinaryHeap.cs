namespace Algorithms.DataStructures;

// Also known as a priority queue
public interface IBinaryHeap<T>
{
  public enum Side { Left, Right }

  public class Node(T value)
  {
    public T Value { get; set; } = value;
  }

  public int Count { get; }

  public void Insert(T value);
  public T Remove();
}

/// <summary>
/// BinaryHeap (complete binary tree) that has values ordered in ascending order
/// </summary>
/// Performance: O(log(n))
public class MinHeap<T>() : IBinaryHeap<T>
{
  protected List<IBinaryHeap<T>.Node> List { get; set; } = [];

  public int Count => List.Count;

  /// <summary>
  /// Initialize items in the same order as they wound be returned with <see cref="ToArray"/>
  /// </summary>
  public MinHeap(T[] items) : this() => List = new(items.Select(x => new IBinaryHeap<T>.Node(x)));

  public void Insert(T value)
  {
    var index = List.Count;
    var node = new IBinaryHeap<T>.Node(value);

    List.Add(node);

    HeapifyUp(index);
  }

  public T Remove()
  {
    if (List.FirstOrDefault() is not IBinaryHeap<T>.Node item)
      throw new InvalidOperationException();

    Swap(0, Count - 1);

    List.RemoveAt(Count - 1);

    HeapifyDown(0);

    return item.Value;
  }

  public T[] ToArray() => List.Select(x => x.Value).ToArray();

  private IBinaryHeap<T>.Node? GetParent(int index, out int parentIndex)
  {
    parentIndex = (index - 1) / 2;

    return parentIndex >= 0 ? List[parentIndex] : null;
  }

  private IBinaryHeap<T>.Node? GetChild(int index, IBinaryHeap<T>.Side side, out int childIndex)
  {
    childIndex = side == IBinaryHeap<T>.Side.Left ? 2 * index + 1 : 2 * index + 2;

    return List.Count - 1 >= childIndex ? List[childIndex] : null;
  }

  /// <summary>
  /// Swaps child node recursively with the root, if the child is smaller than the root
  /// </summary>
  private void HeapifyUp(int index)
  {
    // Compare with parent and swap if parent is bigger than the child.
    // Repeat until parent is smaller than the child
    if (GetParent(index, out var pIndex) is IBinaryHeap<T>.Node parent
      && Comparer<T>.Default.Compare(List[index].Value, parent.Value) < 0)
    {
      Swap(index, pIndex);
      HeapifyUp(pIndex);
    }
  }

  /// <summary>
  /// Swaps root node recursively with the smallest child, if the child is smaller than the root
  /// </summary>
  private void HeapifyDown(int index)
  {
    if (index >= List.Count)
      return;

    var rightChild = GetChild(index, IBinaryHeap<T>.Side.Right, out var ri);
    var leftChild = GetChild(index, IBinaryHeap<T>.Side.Left, out var li);

    var smallest = index;

    if (rightChild != null && Comparer<T>.Default.Compare(rightChild.Value, List[smallest].Value) < 0)
      smallest = ri;

    if (leftChild != null && Comparer<T>.Default.Compare(leftChild.Value, List[smallest].Value) < 0)
      smallest = li;

    if (!Equals(List[index].Value, List[smallest].Value))
    {
      Swap(index, smallest);
      HeapifyDown(smallest);
    }
  }

  private void Swap(int indexA, int indexB) => (List[indexB], List[indexA]) = (List[indexA], List[indexB]);
}
