using static DesignPatterns.Patterns.SingletonPattern;

namespace UnitTests.Patterns;
[TestClass]
public class SingletonPatternTests
{
  [TestMethod]
  public void SingletonService_IsSingleton()
  {
    Assert.IsNotNull(SingletonService.Instance);
    Assert.AreSame(SingletonService.Instance, SingletonService.Instance);
  }
}
