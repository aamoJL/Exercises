using static DesignPatterns.Patterns.IteratorPattern;

namespace UnitTests.Patterns;
[TestClass]
public class IteratorPatternTests
{
  [TestMethod]
  public void Iteration()
  {
    var array = new string[] { "First", "Second", "Third" };
    var collection = new Collection<string>(array);
    var index = 0;

    foreach (var item in collection)
    {
      Assert.AreEqual(array[index++], item);
    }
  }
}
