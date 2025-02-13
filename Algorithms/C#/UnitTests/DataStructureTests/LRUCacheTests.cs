using Algorithms.DataStructures;

namespace UnitTests.DataStructureTests;

[TestClass]
public class LRUCacheTests
{
  [TestMethod]
  public void Init_NoItems()
  {
    var cache = new LRUCache<string, int>(5);

    Assert.AreEqual(0, cache.Count);
  }

  [TestMethod]
  public void Init_WithItems()
  {
    var values = new int[] { 1, 2, 3, 4, 5 };
    var items = values.Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    Assert.AreEqual(items.Length, cache.Count);
    CollectionAssert.AreEqual(values, cache.ToArray());

    foreach (var (Key, Value) in items)
      Assert.IsTrue(cache.Exists(Key));
  }

  [TestMethod]
  public void Update_New_UnderCapacity_Added()
  {
    var cache = new LRUCache<string, int>(5);
    var item = new { Key = "1", Value = 1 };

    cache.Update(item.Key, item.Value);

    Assert.AreEqual(1, cache.Count);

    var expected = new int[] { item.Value };

    CollectionAssert.AreEquivalent(expected, cache.ToArray());
    Assert.IsTrue(cache.Exists(item.Key));
  }

  [TestMethod]
  public void Update_New_OverCapacity_TailRemoved()
  {
    var values = new int[] { 1, 2, 3, 4, 5 };
    var items = values.Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    var item = new { Key = "6", Value = 6 };

    cache.Update(item.Key, item.Value);

    Assert.AreEqual(items.Length, cache.Count);

    var expected = new int[] { 6, 1, 2, 3, 4 };

    CollectionAssert.AreEqual(expected, cache.ToArray());
    Assert.IsFalse(cache.Exists(items.Last().Key));
  }

  [TestMethod]
  public void Update_Existing_Updated()
  {
    var values = new int[] { 1, 2, 3, 4, 5 };
    var items = values.Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    var (Key, Value) = items[3];

    cache.Update(Key, 6);

    var expected = new int[] { 6, 1, 2, 3, 5 };

    Assert.AreEqual(items.Length, cache.Count);
    CollectionAssert.AreEquivalent(expected, cache.ToArray());
    Assert.IsTrue(cache.Exists(Key));
  }

  [TestMethod]
  public void Get_NotFound_ReturnNull()
  {
    var values = new int[] { 1, 2, 3, 4, 5 };
    var items = values.Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    var result = cache.Get(string.Empty, out var _);

    Assert.IsFalse(result);
    CollectionAssert.AreEqual(values, cache.ToArray());

    foreach (var (Key, Value) in items)
      Assert.IsTrue(cache.Exists(Key));
  }

  [TestMethod]
  public void Get_Found_ReturnValue()
  {
    var items = Enumerable.Range(0, 5).Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    var index = 3;
    var result = cache.Get(items[index].Key, out var value);

    Assert.IsTrue(result);
    Assert.AreEqual(items[index].Value, value);

    foreach (var (Key, Value) in items)
      Assert.IsTrue(cache.Exists(Key));
  }

  [TestMethod]
  public void Get_Found_HeadChanged()
  {
    var values = new int[] { 1, 2, 3, 4, 5 };
    var items = values.Select(x => (Key: x.ToString(), Value: x)).ToArray();
    var cache = new LRUCache<string, int>(items);

    var index = 3;
    cache.Get(items[index].Key, out var _);

    var expected = new int[] { 4, 1, 2, 3, 5 };
    CollectionAssert.AreEqual(expected, cache.ToArray());

    foreach (var (Key, Value) in items)
      Assert.IsTrue(cache.Exists(Key));
  }
}