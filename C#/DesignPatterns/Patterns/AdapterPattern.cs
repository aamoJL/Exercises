using System.Drawing;

namespace DesignPatterns.Patterns;
public class AdapterPattern : IRunnable
{
  public string Name => "Adapter Pattern";

  public void Run()
  {
    var colorGenerator = new ColorGenerator(); // Only generates RGB colors
    var paintProducer = new PaintProducer(); // Only takes HSL colors
    var adapter = new PaintProducerRGBAdapter(paintProducer); // Adapter to use RGB on the producer

    Console.WriteLine(adapter.Produce(colorGenerator.GenerateColor(240, 200, 20)).Color.ToString());
    // H: 49,090908, S: 0,88, L: 0,50980395
  }

  public interface IPaintProducer
  {
    public Paint Produce(float h, float s, float l);
  }

  public class PaintProducer : IPaintProducer
  {
    public Paint Produce(float h, float s, float l) => new(new(h, s, l));
  }

  public class ColorGenerator()
  {
    public RGBColor GenerateColor(int r, int g, int b) => new(r, g, b);
  }

  /// <summary>
  /// Adapter for <see cref="IPaintProducer"/> to produce paint using <see cref="RGBColor"/>
  /// </summary>
  public class PaintProducerRGBAdapter(IPaintProducer producer)
  {
    private readonly IPaintProducer _paintProducer = producer;

    public Paint Produce(RGBColor rgb)
    {
      var hsl = RGBtoHSLConversion(rgb);

      return _paintProducer.Produce(hsl.H, hsl.S, hsl.L);
    }

    private HSLColor RGBtoHSLConversion(RGBColor rgb)
    {
      var color = Color.FromArgb(rgb.R, rgb.G, rgb.B);
      return new(color.GetHue(), color.GetSaturation(), color.GetBrightness());
    }
  }

  public class Paint(HSLColor color)
  {
    public HSLColor Color { get; } = color;
  }

  public class RGBColor(int r, int g, int b)
  {
    public int R { get; } = r;
    public int G { get; } = g;
    public int B { get; } = b;
  }

  public class HSLColor(float h, float s, float l)
  {
    public float H { get; } = h;
    public float S { get; } = s;
    public float L { get; } = l;

    public override string ToString() => $"H: {H}, S: {S}, L: {L}";
  }
}
