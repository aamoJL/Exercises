namespace DesignPatterns.Patterns;
public class ObserverPattern : IRunnable
{
  public string Name => "Observer Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var bankAccount = new BankAccount(10);
    bankAccount.OnPropertyChanged += (s, e) =>
    {
      Console.WriteLine("Money changed: " + bankAccount.Balance);
    };

    Console.WriteLine("Money: " + bankAccount.Balance);
    bankAccount.Balance += 15;
    bankAccount.Balance -= 2;
    bankAccount.Balance += 5;
  }

  public interface INotifyPropertyChanged
  {
    public event EventHandler OnPropertyChanged;
  }

  public class BankAccount(int balance) : INotifyPropertyChanged
  {
    public int Balance
    {
      get => balance;
      set
      {
        if(balance != value)
        {
          balance = value;
          OnPropertyChanged?.Invoke(this, new EventArgs());
        }
      }
    }

    public event EventHandler? OnPropertyChanged;
  }
}
