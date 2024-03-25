namespace DesignPatterns.Patterns;
public class FacadePattern : IRunnable
{
  public string Name => "Facade Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    new OrderFacade(new EmailService(), new PaymentService()).MakeOrder(10f);
  }

  public class OrderFacade(EmailService emailService, PaymentService paymentService)
  {
    public EmailService EmailService { get; } = emailService;
    public PaymentService PaymentService { get; } = paymentService;

    public bool MakeOrder(float amount) => PaymentService.MakePayment(amount) && EmailService.Send();
  }

  public class EmailService()
  {
    public bool Send()
    {
      Console.WriteLine("Email sent.");
      return true;
    }
  }

  public class PaymentService()
  {
    public bool MakePayment(float amount)
    {
      Console.WriteLine("Paid: " + amount);
      return true;
    }
  }
}
