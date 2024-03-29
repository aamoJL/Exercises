using System.Collections;

namespace DesignPatterns.Patterns;
public class IteratorPattern : IRunnable
{
  public string Name => "Iterator Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var collection = new Collection<string>(["First", "Second", "Third"]);

    Console.WriteLine("Items:");
    foreach (var item in collection)
    {
      Console.WriteLine(item);
    }
  }

  public class Iterator<T>(T[] array) : IEnumerator<T>
  {
    private int index = -1;

    public T Current => array[index];

    object IEnumerator.Current => Current;

    void IDisposable.Dispose() { }

    public bool MoveNext()
    {
      if (index + 1 >= array.Length) { return false; }
      else { index++; return true; }
    }

    public void Reset() => index = 0;
  }

  // Aggregate
  public class Collection<T>(T[] array) : IEnumerable<T>
  {
    public IEnumerator<T> GetEnumerator() => new Iterator<T>(array);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
