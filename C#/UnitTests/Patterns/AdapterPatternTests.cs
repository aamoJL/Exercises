using static DesignPatterns.Patterns.AdapterPattern;

namespace UnitTests.Patterns;
[TestClass]
public class AdapterPatternTests
{
  [TestMethod]
  public void PaintProducerRGBAdapter_Produce()
  {
    var adapter = new PaintProducerRGBAdapter(new PaintProducer());
    var color = new RGBColor(240, 200, 20);
    var paint = adapter.Produce(color);

    Assert.AreEqual(Math.Round(49.09f, 2), Math.Round(paint.Color.H, 2));
    Assert.AreEqual(Math.Round(.88f, 2), Math.Round(paint.Color.S, 2));
    Assert.AreEqual(Math.Round(.51f, 2), Math.Round(paint.Color.L, 2));
  }
}
