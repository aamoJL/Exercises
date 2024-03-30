using static DesignPatterns.Patterns.StrategyPattern;

namespace UnitTests.Patterns;
[TestClass]
public class StrategyPatternTests
{
  [TestMethod]
  public void Alphabetical()
  {
    var items = new string[] { "b", "d", "a", "c" };
    items = Sorter.Sort(items, new AlphabeticalSortStrategy());

    var expected = new string[] { "a", "b", "c", "d" };
    CollectionAssert.AreEqual(expected, items);
  }

  [TestMethod]
  public void ReverseAlphabetical()
  {
    var items = new string[] { "b", "d", "a", "c" };
    items = Sorter.Sort(items, new ReverseAlphabeticalSortStrategy());

    var expected = new string[] { "d", "c", "b", "a" };
    CollectionAssert.AreEqual(expected, items);
  }
}
