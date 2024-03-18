namespace BuilderPattern;

internal class Program
{
  static void Main(string[] args)
  {
    // With constructor
    new ObjectWithAPIs(new FirstAPI(), new SecondAPI()).Log();

    // With builder pattern
    new ObjectWithAPIs.Builder()
      .WithPrimaryAPI(new FirstAPI())
      .WithSecondaryAPI(new SecondAPI())
      .Build()
      .Log();

    // With builder pattern inside a try-catch. Can be used to throw exceptions if the properties are not right
    try
    {
      new ObjectWithAPIs.Builder()
        .Build()
        .Log();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }

    // With properties. Can be used to make constructor parameter list smaller if the parameters are not required
    // Properties needs to have public setters / initializers
    new ObjectWithAPIs()
    {
      PrimaryAPI = new FirstAPI(),
      SecondaryAPI = new SecondAPI(),
    }.Log();
  }

  /* Console logs:
    FirstAPI : SecondAPI
    FirstAPI : SecondAPI
    APIs can't be null
    FirstAPI : SecondAPI
   */
}

public class ObjectWithAPIs
{
  public IAPI PrimaryAPI { get; init; } = new FirstAPI();
  public IAPI SecondaryAPI { get; init; } = new SecondAPI();

  public ObjectWithAPIs() { }

  public ObjectWithAPIs(IAPI primaryAPI, IAPI secondaryAPI)
  {
    PrimaryAPI = primaryAPI;
    SecondaryAPI = secondaryAPI;
  }

  public void Log() => Console.WriteLine($"{PrimaryAPI.GetName()} : {SecondaryAPI.GetName()}");

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

    public ObjectWithAPIs Build()
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
