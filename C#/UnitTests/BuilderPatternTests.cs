using BuilderPattern;

namespace UnitTests;
[TestClass]
public class BuilderPatternTests
{
  [TestMethod]
  public void Build()
  {
    var build = new ObjectWithAPIs.Builder()
      .WithPrimaryAPI(new SecondAPI())
      .WithSecondaryAPI(new FirstAPI())
      .Build();

    Assert.AreEqual(new SecondAPI().GetType().Name, build.PrimaryAPI.GetName());
    Assert.AreEqual(new FirstAPI().GetType().Name, build.SecondaryAPI.GetName());
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void Build_Exception()
  {
    new ObjectWithAPIs.Builder()
      .WithSecondaryAPI(new FirstAPI())
      .Build();
  }
}
