using static DesignPatterns.Patterns.CommandPattern;

namespace UnitTests.Patterns;
[TestClass]
public class CommandPatternTests
{
  [TestMethod]
  public void Command_Valid()
  {
    var expected = "test";
    ICommand command = new Command<string>(method: (arg) => Assert.AreEqual(expected, arg));

    if (command.CanExecute(expected)) { command.Execute(expected); }
    else { Assert.Fail(); }
  }

  [TestMethod]
  public void Command_ShouldNotExecute()
  {
    ICommand command = new Command<string>(
      method: (arg) => Assert.Fail(),
      canExecute: (arg) => !string.IsNullOrEmpty(arg));

    command.Execute(string.Empty);
  }
}
