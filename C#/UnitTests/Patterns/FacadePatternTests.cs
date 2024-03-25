using static DesignPatterns.Patterns.FacadePattern;

namespace UnitTests.Patterns;
[TestClass]
public class FacadePatternTests
{
  [TestMethod]
  public void OrderFacade_MakeOrder()
  {
    using var sw = new StringWriter();
    Console.SetOut(sw);

    var amount = 22f;
    new OrderFacade(new EmailService(), new PaymentService()).MakeOrder(amount);
    Assert.AreEqual($"Paid: {amount}{Console.Out.NewLine}Email sent.{Console.Out.NewLine}", sw.ToString());
  }
}
