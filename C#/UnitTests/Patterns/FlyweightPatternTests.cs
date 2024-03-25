using static DesignPatterns.Patterns.FlyweightPattern;

namespace UnitTests.Patterns;
[TestClass]
public class FlyweightPatternTests
{
  [TestMethod]
  public void SharedDataInstances()
  {
    IEnemy enemy1 = new BasicEnemy("test enemy 1");
    IEnemy enemy2 = new BasicEnemy("test enemy 2");

    Assert.AreNotSame(enemy1, enemy2);
    Assert.AreSame(enemy1.Data, enemy2.Data);

    IEnemy heavyEnemy = new HeavyEnemy("Heavy");

    Assert.AreNotSame(heavyEnemy, enemy1);
    Assert.AreNotSame(heavyEnemy.Data, enemy1.Data);
  }
}
