namespace DesignPatterns.Patterns;
public class StrategyPattern : IRunnable
{
  public string Name => "Strategy Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var items = new string[] { "b", "d", "a", "c" };

    items = Sorter.Sort(items, new AlphabeticalSortStrategy());
    Console.WriteLine("Alphabetical: ");
    foreach (var item in items) { Console.Write(item); }

    Console.WriteLine();

    items = Sorter.Sort(items, new ReverseAlphabeticalSortStrategy());
    Console.WriteLine("Reverse alphabetical: ");
    foreach (var item in items) { Console.Write(item); }

    Console.WriteLine();
  }

  public interface ISortStrategy
  {
    string[] Sort(string[] items);
  }

  public static class Sorter
  {
    public static string[] Sort(string[] items, ISortStrategy strategy) => strategy.Sort(items);
  }

  public class AlphabeticalSortStrategy : ISortStrategy
  {
    public string[] Sort(string[] items)
    {
      var list = items.ToList();
      list.Sort();
      return [.. list];
    }
  }

  public class ReverseAlphabeticalSortStrategy : ISortStrategy
  {
    public string[] Sort(string[] items)
    {
      var list = items.ToList();
      list.Sort();
      list.Reverse();
      return [.. list];
    }
  }
}
