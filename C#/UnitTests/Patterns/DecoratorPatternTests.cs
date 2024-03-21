using static DesignPatterns.Patterns.DecoratorPattern;

namespace UnitTests.Patterns;
[TestClass]
public class DecoratorPatternTests
{
  [TestMethod]
  public void Calculator_Calculate()
  {
    ICalculator calculator = new Calculator(initValue: 5);
    Assert.AreEqual(5, calculator.Calculate());

    calculator = new Addition(calculator, 10);
    Assert.AreEqual(5 + 10, calculator.Calculate());

    calculator = new Subtraction(calculator, 2);
    Assert.AreEqual((5 + 10) - 2, calculator.Calculate());

    calculator = new Multiplication(calculator, 2);
    Assert.AreEqual(((5 + 10) - 2) * 2, calculator.Calculate());
  }
}
