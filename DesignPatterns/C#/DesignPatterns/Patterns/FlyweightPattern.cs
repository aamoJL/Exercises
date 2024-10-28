namespace DesignPatterns.Patterns;
public class FlyweightPattern : IRunnable
{
  public string Name => "Flyweight Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var enemies = new IEnemy[]
    {
      new BasicEnemy("Basic 1"),
      new BasicEnemy("Basic 2"), // Has same data object instance as Basic 1
      new HeavyEnemy("Heavy"),
    };

    foreach (var item in enemies)
    {
      Console.WriteLine($"{item.Name} : {item.Data.BaseHP} : {item.Data.BasePower}");
    }
  }

  public class BasicEnemyData : IEnemyData
  {
    private static IEnemyData? _instance;
    public static IEnemyData Instance
    {
      get => _instance ??= new BasicEnemyData();
      set => _instance = value;
    }

    private BasicEnemyData() { }

    public int BaseHP => 100;
    public int BasePower => 1;
    public int BaseStamina => 10;
  }

  public class HeavyEnemyData : IEnemyData
  {
    private static IEnemyData? _instance;
    public static IEnemyData Instance
    {
      get => _instance ??= new HeavyEnemyData();
      set => _instance = value;
    }

    private HeavyEnemyData() { }

    public int BaseHP => 1000;
    public int BasePower => 2;
    public int BaseStamina => 20;
  }

  public class BasicEnemy(string name) : IEnemy
  {
    public IEnemyData Data => BasicEnemyData.Instance;

    public string Name => name;
  }

  public class HeavyEnemy(string name) : IEnemy
  {
    public IEnemyData Data => HeavyEnemyData.Instance;

    public string Name => name;
  }

  public interface IEnemy
  {
    public IEnemyData Data { get; }

    public string Name { get; }
  }

  public interface IEnemyData
  {
    public int BaseHP { get; }
    public int BasePower { get; }
    public int BaseStamina { get; }
  }
}
