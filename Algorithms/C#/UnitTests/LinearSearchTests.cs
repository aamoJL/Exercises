using Algorithms;

namespace UnitTests;

[TestClass]
public class LinearSearchTests
{
  private static int[] Items => [1, 4, 3, 5, 6]; // Unordered

  [TestMethod]
  public void Search_Found_ReturnIndex()
  {
    for (var i = 0; i < Items.Length; i++)
      Assert.AreEqual(i, LinearSearch.IndexOf(Items, Items[i]));
  }

  [TestMethod] public void Search_NotFound_ReturnDefault() => Assert.AreEqual(-1, LinearSearch.IndexOf(Items, 2));
}