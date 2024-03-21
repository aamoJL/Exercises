namespace DesignPatterns.Patterns;
public class BuilderPattern : IRunnable
{
  public string Name => "Builder Pattern";

  public void Run()
  {
    // With constructor
    Console.WriteLine($"With Constructor: {new Service(new FirstAPI(), new SecondAPI())}");

    // With builder pattern
    Console.WriteLine($"With Builder Pattern: {new Service.Builder()
      .WithPrimaryAPI(new FirstAPI())
      .WithSecondaryAPI(new SecondAPI())
      .Build()}");

    // With builder pattern inside a try-catch. Can be used to throw exceptions if the properties are not right
    try
    {
      Console.WriteLine($"With Builder Pattern: {new Service.Builder()
        .Build()}");
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }

    // With properties. Can be used to make constructor parameter list smaller if the parameters are not required
    // Properties needs to have public setters / initializers
    Console.WriteLine($"With Properties: {new Service()
    {
      PrimaryAPI = new FirstAPI(),
      SecondaryAPI = new SecondAPI(),
    }}");
  }

  /* Console logs:
   * With Constructor: FirstAPI : SecondAPI
   * With Builder Pattern: FirstAPI : SecondAPI
   * APIs can't be null (Parameter 'PrimaryAPI')
   * With Properties: FirstAPI : SecondAPI
   */
}

public class Service
{
  public IAPI PrimaryAPI { get; init; } = new FirstAPI();
  public IAPI SecondaryAPI { get; init; } = new SecondAPI();

  public Service() { }

  public Service(IAPI primaryAPI, IAPI secondaryAPI)
  {
    PrimaryAPI = primaryAPI;
    SecondaryAPI = secondaryAPI;
  }

  public override string ToString() => $"{PrimaryAPI.GetName()} : {SecondaryAPI.GetName()}";

  public class Builder
  {
    private IAPI? PrimaryAPI { get; set; }
    private IAPI? SecondaryAPI { get; set; }

    public Builder WithPrimaryAPI(IAPI primaryAPI)
    {
      PrimaryAPI = primaryAPI;
      return this;
    }

    public Builder WithSecondaryAPI(IAPI secondaryAPI)
    {
      SecondaryAPI = secondaryAPI;
      return this;
    }

    public Service Build()
    {
      if (PrimaryAPI == null) throw new ArgumentException("APIs can't be null", nameof(PrimaryAPI));
      if (SecondaryAPI == null) throw new ArgumentException("APIs can't be null", nameof(SecondaryAPI));

      return new(PrimaryAPI, SecondaryAPI);
    }
  }
}

public interface IAPI
{
  public string GetName() => GetType().Name;
}

public class FirstAPI() : IAPI { }

public class SecondAPI() : IAPI { }
