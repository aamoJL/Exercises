namespace DesignPatterns.Patterns;
public class CommandPattern : IRunnable
{
  public string Name => "Command Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    ICommand command = new Command<string>(
      method: (arg) => Console.WriteLine($"Argument: {arg}"),
      canExecute: (arg) => { return !string.IsNullOrEmpty(arg); });

    Console.Write("Give argument (can't be empty): ");
    Console.CursorVisible = true;
    var arg = Console.ReadLine();

    if (command.CanExecute(arg)) command.Execute(arg);
    else Console.WriteLine("Invalid argument");
  }

  public interface ICommand
  {
    public void Execute(object? arg);
    public bool CanExecute(object? arg);
  }

  public class Command<T>(Action<T?> method, Func<T?, bool>? canExecute = null) : ICommand
  {
    public bool CanExecute(object? arg) => arg is T? && (canExecute == null || canExecute((T)arg));

    public void Execute(object? arg)
    {
      if (CanExecute(arg)) { method((T?)arg); }
    }
  }
}
