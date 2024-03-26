using DesignPatterns.Patterns;

namespace DesignPatterns;
internal class Program
{
  public static int SelectionStartingLine = 2;

  static void Main(string[] args)
  {
    var run = false;
    var selection = 0;

    Console.WriteLine($"Select pattern:\n");
    
    SelectionStartingLine = Console.CursorTop;
    
    for (var i = 0; i < _runnables.Length; i++)
    {
      Console.WriteLine($"\t{_runnables[i].Name}");
    }

    Console.CursorVisible = false;
    SelectMenuItem(selection);

    do
    {
      switch (Console.ReadKey(true).Key)
      {
        case ConsoleKey.DownArrow:
          DeselectMenuItem(selection);
          SelectMenuItem(selection = selection != _runnables.Length - 1 ? selection + 1 : 0); break;
        case ConsoleKey.UpArrow:
          DeselectMenuItem(selection);
          SelectMenuItem(selection = selection != 0 ? selection - 1 : _runnables.Length - 1); break;
        case ConsoleKey.Enter: run = true; break;
        default: break;
      }
    } while (!run);

    Console.Clear();
    _runnables[selection].Run();

    Console.Write("\nPress any key to exit.");
    Console.ReadKey(true);

    Environment.Exit(0);
  }

  private static void DeselectMenuItem(int index)
  {
    Console.SetCursorPosition(0, index + SelectionStartingLine);
    Console.Write("   "); // Remove arrow
    Console.Write($"\t{_runnables[index].Name}");
  }

  private static void SelectMenuItem(int index)
  {
    Console.SetCursorPosition(0, index + SelectionStartingLine);
    Console.Write($"\t{_runnables[index].Name}");
    Console.CursorLeft = 0;
    Console.Write("-->");
  }

  public static IRunnable[] _runnables = [
    new AdapterPattern(),
    new BuilderPattern(),
    new DecoratorPattern(),
    new FacadePattern(),
    new FactoryMethodPattern(),
    new FlyweightPattern(),
    new ProxyPattern(),
    new SingletonPattern(),
  ];
}

internal interface IRunnable
{
  public string Name { get; }
  public void Run();
}
