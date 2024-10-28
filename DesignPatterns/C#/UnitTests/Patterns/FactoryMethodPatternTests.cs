using static DesignPatterns.Patterns.FactoryMethodPattern;

namespace UnitTests.Patterns;
[TestClass]
public class FactoryMethodPatternTests
{
  [TestMethod]
  public void CreateDatabase_Online()
  {
    var options = "testOptions";
    var db = new OnlineDatabaseFactory(options).CreateDatabase();
    Assert.AreEqual(typeof(OnlineDatabase), db.GetType());
    Assert.AreEqual(options, db.Options);
  }

  [TestMethod]
  public void CreateDatabase_Offline()
  {
    var options = "testOptions";
    var db = new OfflineDatabaseFactory(options).CreateDatabase();
    Assert.AreEqual(typeof(OfflineDatabase), db.GetType());
    Assert.AreEqual(options, db.Options);
  }
}
