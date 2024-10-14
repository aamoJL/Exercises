using static DesignPatterns.Patterns.ChainOfResponsibilityPattern;

namespace UnitTests.Patterns;
[TestClass]
public class ChainOfResponsibilityPatternTests
{
  public class TicketNotHandledException(string message) : Exception
  {
    public override string Message => message;
  }

  public class ExceptionTicketHandler() : TicketHandler
  {
    public override void Handle(TicketType ticket) => throw new TicketNotHandledException("Ticket was not handled");
  }

  [TestMethod]
  public void TicketHandler_First()
  {
    var handler = new LowTicketHandler()
    {
      NextHandler = new ExceptionTicketHandler()
    };

    handler.Handle(TicketType.Low);
  }

  [TestMethod]
  public void TicketHandler_Last()
  {
    var handler = new LowTicketHandler()
    {
      NextHandler = new MediumTicketHandler()
      {
        NextHandler = new HighTicketHandler()
        {
          NextHandler = new ExceptionTicketHandler()
        }
      }
    };

    handler.Handle(TicketType.High);
  }

  [TestMethod]
  [ExpectedException(typeof(TicketNotHandledException))]
  public void TicketHandler_NotHandled()
  {
    var handler = new LowTicketHandler()
    {
      NextHandler = new ExceptionTicketHandler()
    };

    handler.Handle(TicketType.Medium);
  }
}
