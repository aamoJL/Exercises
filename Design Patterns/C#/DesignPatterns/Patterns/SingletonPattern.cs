namespace DesignPatterns.Patterns;
public class SingletonPattern : IRunnable
{
  public string Name => "Singleton Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    Console.WriteLine(SingletonService.Instance.Name);

    // SingletonService
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
}
