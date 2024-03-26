namespace DesignPatterns.Patterns;
public class ChainOfResponsibilityPattern : IRunnable
{
  public string Name => "Chain of Responsibility Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var handler = new LowTicketHandler()
    {
      NextHandler = new MediumTicketHandler()
      {
        NextHandler = new HighTicketHandler()
      }
    };

    handler.Handle(TicketType.Low);
    handler.Handle(TicketType.Medium);
    handler.Handle(TicketType.High);

    // LowTicketHandler handled the ticket: Low
    // MediumTicketHandler handled the ticket: Medium
    // HighTicketHandler handled the ticket: High
  }

  public abstract class TicketHandler()
  {
    public TicketHandler? NextHandler { get; set; }

    public abstract void Handle(TicketType ticket);
  }

  public class LowTicketHandler() : TicketHandler
  {
    public override void Handle(TicketType ticket)
    {
      if (ticket == TicketType.Low)
        Console.WriteLine(GetType().Name + " handled the ticket: " + ticket.ToString());
      else
        NextHandler?.Handle(ticket);
    }
  }

  public class MediumTicketHandler() : TicketHandler
  {
    public override void Handle(TicketType ticket)
    {
      if (ticket == TicketType.Medium)
        Console.WriteLine(GetType().Name + " handled the ticket: " + ticket.ToString());
      else
        NextHandler?.Handle(ticket);
    }
  }

  public class HighTicketHandler() : TicketHandler
  {
    public override void Handle(TicketType ticket)
    {
      if (ticket == TicketType.High)
        Console.WriteLine(GetType().Name + " handled the ticket: " + ticket.ToString());
      else
        NextHandler?.Handle(ticket);
    }
  }

  public enum TicketType { Low, Medium, High }
}
