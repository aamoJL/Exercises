using DesignPatterns.Patterns;

namespace DesignPatterns;
internal class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine($"Select pattern:");
    for (var i = 0; i < _runnables.Length; i++)
    {
      Console.WriteLine($"{i + 1}: {_runnables[i].Name}");
    }

    Console.Write("Selection: ");

    if (Console.ReadLine() is string input
      && int.TryParse(input, out var selection)
      && selection > 0 && _runnables.Length > selection - 1)
    {
      Console.Clear();
      _runnables[selection - 1].Run();
    }
  }

  public static IRunnable[] _runnables = [
    new AdapterPattern(),
    new BuilderPattern(),
    new FactoryMethodPattern(),
    new SingletonPattern(),
    new DecoratorPattern(),
  ];
}

internal interface IRunnable
{
  public string Name { get; }
  public void Run();
}
