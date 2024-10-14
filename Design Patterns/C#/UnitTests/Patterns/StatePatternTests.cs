using static DesignPatterns.Patterns.StatePattern;

namespace UnitTests.Patterns;
[TestClass]
public class StatePatternTests
{
  [TestMethod]
  public void PowerOff()
  {
    var player = new AudioPlayer(new AudioPlayer.PowerOffState());
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PowerOffState());
    player.PressPlayButton();
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PowerOffState());
    player.PressStopButton();
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PowerOffState());
    player.PressPowerButton();
    Assert.AreEqual(typeof(AudioPlayer.StandbyState), player.CurrentState.GetType());
  }

  [TestMethod]
  public void Standby()
  {
    var player = new AudioPlayer(new AudioPlayer.StandbyState());
    Assert.AreEqual(typeof(AudioPlayer.StandbyState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.StandbyState());
    player.PressPlayButton();
    Assert.AreEqual(typeof(AudioPlayer.PlayingState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.StandbyState());
    player.PressStopButton();
    Assert.AreEqual(typeof(AudioPlayer.StandbyState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.StandbyState());
    player.PressPowerButton();
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());
  }

  [TestMethod]
  public void Playing()
  {
    var player = new AudioPlayer(new AudioPlayer.PlayingState());
    Assert.AreEqual(typeof(AudioPlayer.PlayingState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PlayingState());
    player.PressPlayButton();
    Assert.AreEqual(typeof(AudioPlayer.PausedState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PlayingState());
    player.PressStopButton();
    Assert.AreEqual(typeof(AudioPlayer.StandbyState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PlayingState());
    player.PressPowerButton();
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());
  }

  [TestMethod]
  public void Paused()
  {
    var player = new AudioPlayer(new AudioPlayer.PausedState());
    Assert.AreEqual(typeof(AudioPlayer.PausedState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PausedState());
    player.PressPlayButton();
    Assert.AreEqual(typeof(AudioPlayer.PlayingState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PausedState());
    player.PressStopButton();
    Assert.AreEqual(typeof(AudioPlayer.StandbyState), player.CurrentState.GetType());

    player = new AudioPlayer(new AudioPlayer.PausedState());
    player.PressPowerButton();
    Assert.AreEqual(typeof(AudioPlayer.PowerOffState), player.CurrentState.GetType());
  }
}
