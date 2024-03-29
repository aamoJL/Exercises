using static DesignPatterns.Patterns.ObserverPattern;

namespace UnitTests.Patterns;
[TestClass]
public class ObserverPatternTests
{
  [TestMethod]
  public void Notify()
  {
    var money = 10;
    var bankAccount = new BankAccount(money);
    var propertyChanged = false;

    bankAccount.OnPropertyChanged += (s, e) =>
    {
      propertyChanged = true;
      Assert.AreEqual(money + 10, bankAccount.Balance);
    };

    Assert.AreEqual(money, bankAccount.Balance);

    bankAccount.Balance += 10;
    Assert.IsTrue(propertyChanged);
  }
}
