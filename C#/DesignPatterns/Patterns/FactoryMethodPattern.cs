namespace DesignPatterns.Patterns;
public class FactoryMethodPattern : IRunnable
{
  public string Name => "Factory Method Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    Console.WriteLine(new Repository(new OfflineDatabaseFactory("filename.db")).Database);
    Console.WriteLine(new Repository(new OnlineDatabaseFactory("connection")).Database);

    // OfflineDatabase : filename.db
    // OnlineDatabase : connection
  }

  public abstract class Database(string options)
  {
    public string Options { get; } = options;

    public override string ToString() => $"{GetType().Name} : {Options}";
  }

  public class OnlineDatabase(string options) : Database(options) { }

  public class OfflineDatabase(string options) : Database(options) { }

  public interface IDatabaseFactory
  {
    public Database CreateDatabase();
  }

  public class OnlineDatabaseFactory(string options) : IDatabaseFactory
  {
    public Database CreateDatabase() => new OnlineDatabase(options);
  }

  public class OfflineDatabaseFactory(string options) : IDatabaseFactory
  {
    public Database CreateDatabase() => new OfflineDatabase(options);
  }

  public class Repository(IDatabaseFactory databaseFactory)
  {
    public Database Database { get; } = databaseFactory.CreateDatabase();
  }
}
