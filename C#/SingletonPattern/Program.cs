namespace SingletonPattern;

internal class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine(SingletonService.Instance.Name);

    /* Console logs:
     * SingletonService
     */
  }
}

public interface IService
{
  public string Name { get; }
}

public class SingletonService : IService
{
  private static IService? _instance;
  public static IService Instance
  {
    get => _instance ??= new SingletonService();
    private set => Instance = value;
  }

  public string Name => GetType().Name;

  private SingletonService() { }
}
