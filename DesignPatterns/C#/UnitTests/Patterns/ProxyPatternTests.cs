using static DesignPatterns.Patterns.ProxyPattern;

namespace UnitTests.Patterns;
[TestClass]
public class ProxyPatternTests
{
  [TestMethod]
  public void PersonValidation_Init()
  {
    var person = new Person("test");
    Assert.AreEqual("test", person.Name);

    var validator = new PersonValidator(person);
    Assert.AreEqual(person.Name, validator.Name);
  }

  [TestMethod]
  public void PersonValidation_Valid()
  {
    var validator = new PersonValidator(new Person("test"))
    {
      Name = "new name"
    };
    Assert.AreEqual("new name", validator.Name);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void PersonValidation_Invalid()
  {
    new PersonValidator(new Person("test"))
    {
      Name = null
    };
  }
}
