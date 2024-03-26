namespace DesignPatterns.Patterns;
public class ProxyPattern : IRunnable
{
  public string Name => "Proxy Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var person = new Person("John");
    Console.WriteLine("Current name: " + person.Name);

    try
    {
      Console.CursorVisible = true;
      Console.Write("Input new name: ");
      new PersonValidator(person).Name = Console.ReadLine();
    }
    catch (ArgumentException e)
    {
      Console.WriteLine(e.Message);
    }

    Console.WriteLine("Current name: " + person.Name);
  }

  public interface IPerson
  {
    public string Name { get; set; }
  }

  public class Person(string name) : IPerson
  {
    public string Name { get; set; } = name;
  }

  // Person Proxy
  public class PersonValidator(Person person) : IPerson
  {
    public string? Name
    {
      get => person.Name;
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new ArgumentException("Invalid name");
        }
        else person.Name = value;
      }
    }
  }
}
