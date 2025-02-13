using System.Collections;

namespace Algorithms.DataStructures;

/// <summary>
/// The Least Recently Used cache
/// </summary>
/// <typeparam name="K">Key type</typeparam>
/// <typeparam name="V">Value type</typeparam>
public class LRUCache<K, V>(int capacity) : IEnumerable<V> where K : notnull
{
  public LRUCache(IEnumerable<(K Key, V Value)> items) : this(items.Count())
  {
    foreach (var (Key, Value) in items.Reverse())
      Update(Key, Value);
  }

  public int Count { get; private set; } = 0;

  protected int Capacity { get; } = capacity;
  protected List<(K Key, LinkedList<V>.Node Node)>[] NodeMap { get; } = [.. Enumerable.Range(0, capacity).Select(x => new List<(K, LinkedList<V>.Node)>())];
  protected List<(LinkedList<V>.Node Node, K Key)>[] NodeKeyMap { get; } = [.. Enumerable.Range(0, capacity).Select(x => new List<(LinkedList<V>.Node Node, K Key)>())];

  protected LinkedList<V>.Node? HeadNode { get; set; }
  protected LinkedList<V>.Node? TailNode { get; set; }

  public void Update(K key, V value)
  {
    var mapIndex = GetMapIndex(key);

    if (NodeMap[mapIndex]?.FirstOrDefault(x => x.Key.Equals(key)).Node is LinkedList<V>.Node node)
    {
      // Update value
      node.Value = value;

      // Unlink node
      LinkNodes(node.Previous, node.Next);
      node.Previous = null;
      node.Next = null;

      // Move to head
      if (node != HeadNode)
      {
        LinkNodes(node, HeadNode);
        HeadNode = node;
      }
    }
    else
    {
      // Remove tail if cache is full
      if (Count >= Capacity)
      {
        var oldTail = TailNode;

        // Remove tail
        if (oldTail != null)
        {
          TailNode = oldTail.Previous;

          if (TailNode != null)
            TailNode.Next = null;

          RemoveNode(oldTail);
        }

        Count--;
      }

      // Add new head
      var oldHead = HeadNode;
      var newHead = new LinkedList<V>.Node(value);

      LinkNodes(newHead, oldHead);

      HeadNode = newHead;
      TailNode ??= HeadNode;

      NodeMap[mapIndex].Add(new(key, newHead));
      NodeKeyMap[GetMapIndex(newHead)].Add(new(newHead, key));

      Count++;
    }
  }

  public bool Get(K key, out V? value)
  {
    value = default;

    var mapIndex = GetMapIndex(key);

    if (NodeMap[mapIndex]?.FirstOrDefault(x => x.Key.Equals(key)).Node is not LinkedList<V>.Node node)
      return false;

    // Unlink node
    LinkNodes(node.Previous, node.Next);

    // Move to head
    node.Previous = null;
    LinkNodes(node, HeadNode);

    HeadNode = node;

    value = node.Value;

    return true;
  }

  public bool Exists(K key)
    => NodeMap[GetMapIndex(key)].Any(x => x.Key.Equals(key));

  public IEnumerator<V> GetEnumerator() => new LinkedList<V>.LinkedListEnumerator(HeadNode);

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  private int GetMapIndex(object key)
    => Math.Abs(key.GetHashCode()) % NodeMap.Length;

  private void RemoveNode(LinkedList<V>.Node node)
  {
    // Unlink
    node.Previous = null;
    node.Next = null;

    var nodeKeyMapIndex = GetMapIndex(node);

    if (NodeKeyMap[nodeKeyMapIndex].FindIndex(x => x.Node.Equals(node)) is int nodeKeyMapItemIndex && nodeKeyMapItemIndex == -1)
      return;

    var nodeKey = NodeKeyMap[nodeKeyMapIndex][nodeKeyMapItemIndex].Key;
    var nodeMapIndex = GetMapIndex(nodeKey);

    // Remove node from NodeKeyMap
    NodeKeyMap[nodeKeyMapIndex].RemoveAt(nodeKeyMapItemIndex);

    // Remove node from NodeMap
    if (NodeMap[nodeMapIndex].FindIndex(x => x.Node.Equals(node)) is int itemIndex && itemIndex != -1)
      NodeMap[nodeMapIndex].RemoveAt(itemIndex);
  }

  protected static void LinkNodes(LinkedList<V>.Node? left, LinkedList<V>.Node? right)
  {
    if (left != null)
      left.Next = right;

    if (right != null)
      right.Previous = left;
  }
}