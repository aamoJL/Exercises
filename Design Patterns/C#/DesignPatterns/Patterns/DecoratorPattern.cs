namespace DesignPatterns.Patterns;
public class DecoratorPattern : IRunnable
{
  public string Name => "Decorator Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    ICalculator calculator = new Calculator(initValue: 0);
    Console.WriteLine(calculator.Calculate().ToString());

    calculator = new Addition(calculator, 10);
    Console.WriteLine(calculator.Calculate().ToString());

    calculator = new Subtraction(calculator, 2);
    Console.WriteLine(calculator.Calculate().ToString());

    calculator = new Multiplication(calculator, 2);
    Console.WriteLine(calculator.Calculate().ToString());

    // 0
    // 10
    // 8
    // 16
  }

  public interface ICalculator
  {
    float Calculate();
  }

  public class Calculator(float initValue = 0) : ICalculator
  {
    public float Calculate() => initValue;
  }

  public abstract class Calculation(ICalculator calculator) : ICalculator
  {
    protected ICalculator _calculator = calculator;

    public virtual float Calculate() => _calculator.Calculate();
  }

  public class Addition(ICalculator calculator, float value) : Calculation(calculator)
  {
    public override float Calculate() => base.Calculate() + value;
  }

  public class Subtraction(ICalculator calculator, float value) : Calculation(calculator)
  {
    public override float Calculate() => base.Calculate() - value;
  }

  public class Multiplication(ICalculator calculator, float value) : Calculation(calculator)
  {
    public override float Calculate() => base.Calculate() * value;
  }
}
