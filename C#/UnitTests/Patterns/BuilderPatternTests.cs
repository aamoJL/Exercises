using DesignPatterns.Patterns;

namespace UnitTests.Patterns;
[TestClass]
public class BuilderPatternTests
{
  [TestMethod]
  public void Build()
  {
    var build = new Service.Builder()
      .WithPrimaryAPI(new SecondAPI())
      .WithSecondaryAPI(new FirstAPI())
      .Build();

    Assert.AreEqual(new SecondAPI().GetType().Name, build.PrimaryAPI.GetName());
    Assert.AreEqual(new FirstAPI().GetType().Name, build.SecondaryAPI.GetName());
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void Build_ArgumentException()
  {
    new Service.Builder()
      .WithSecondaryAPI(new FirstAPI())
      .Build();
  }
}
