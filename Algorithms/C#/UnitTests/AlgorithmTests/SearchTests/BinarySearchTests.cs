using Algorithms.Algorithms.Search;

namespace UnitTests.AlgorithmTests.SearchTests;

[TestClass]
public class BinarySearchTests
{
  private static int[] CreateSet(int count, int start = 1)
  {
    var array = new int[count];

    for (var i = 0; i < array.Length; i++)
      array[i] = start + i;

    return array;
  }

  [TestMethod]
  public void Exists_Found_ReturnTrue()
  {
    var set = CreateSet(100, start: -20);

    for (var i = 1; i < set.Length; i++)
    {
      var items = set.Take(i).ToArray();

      foreach (var item in items)
        Assert.IsTrue(BinarySearch.Exists(items, item), $"{item} was not found");
    }
  }

  [TestMethod]
  public void Exists_ZeroItems_NotFound_ReturnFalse()
  {
    var items = CreateSet(0);

    foreach (var item in items)
      Assert.IsFalse(BinarySearch.Exists(items, item), $"{item} was found");

    Assert.IsFalse(BinarySearch.Exists(items, 1));
  }

  [TestMethod]
  public void Exists_NotFound_ReturnFalse()
  {
    var set = CreateSet(10);

    Assert.IsFalse(BinarySearch.Exists(set, 11));
    Assert.IsFalse(BinarySearch.Exists(set, 0));
    Assert.IsFalse(BinarySearch.Exists(set, -1));
  }

  [TestMethod]
  public void ExistsAlternative_Found_ReturnTrue()
  {
    var set = CreateSet(100, start: -20);

    for (var i = 1; i < set.Length; i++)
    {
      var items = set.Take(i).ToArray();

      foreach (var item in items)
        Assert.IsTrue(BinarySearch.ExistsAlternative(items, item), $"{item} was not found");
    }
  }

  [TestMethod]
  public void ExistsAlternative_ZeroItems_NotFound_ReturnFalse()
  {
    var items = CreateSet(0);

    foreach (var item in items)
      Assert.IsFalse(BinarySearch.ExistsAlternative(items, item), $"{item} was found");

    Assert.IsFalse(BinarySearch.ExistsAlternative(items, 1));
  }

  [TestMethod]
  public void ExistsAlternative_NotFound_ReturnFalse()
  {
    var set = CreateSet(10);

    Assert.IsFalse(BinarySearch.ExistsAlternative(set, 11));
    Assert.IsFalse(BinarySearch.ExistsAlternative(set, 0));
    Assert.IsFalse(BinarySearch.ExistsAlternative(set, -1));
  }
}
