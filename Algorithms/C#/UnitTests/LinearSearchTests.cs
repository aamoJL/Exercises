using Algorithms;

namespace UnitTests;

[TestClass]
public class LinearSearchTests
{
  private static int[] Items => [1, 4, 3, 5, 6];

  [TestMethod] public void Search_Found_ReturnIndex() => Assert.AreEqual(1, LinearSearch.IndexOf(Items, 4));

  [TestMethod] public void Search_NotFound_ReturnDefault() => Assert.AreEqual(-1, LinearSearch.IndexOf(Items, 2));
}
