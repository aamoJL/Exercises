namespace DesignPatterns.Patterns;
public class StatePattern : IRunnable
{
  public string Name => "State Pattern";

  public void Run()
  {
    Console.WriteLine(Name + "\n");

    var player = new AudioPlayer(new AudioPlayer.StandbyState());

    while (player.PowerIsOn)
    {
      Console.Clear();

      Console.WriteLine("Current state: " + player.CurrentState.GetType().Name);
      Console.WriteLine();
      Console.WriteLine("1. Play Button");
      Console.WriteLine("2. Stop Button");
      Console.WriteLine("3. Power Button");
      Console.WriteLine();
      Console.Write("Press a button: ");

      switch (Console.ReadKey(true).Key)
      {
        case ConsoleKey.D1: player.PressPlayButton(); break;
        case ConsoleKey.D2: player.PressStopButton(); break;
        case ConsoleKey.D3: player.PressPowerButton(); break;
        default: break;
      }
    }

    Console.Clear();
    Console.WriteLine("Player was stopped.");
    Console.WriteLine("Current state: " + player.CurrentState.GetType().Name);
  }

  public interface IAudioPlayer
  {
    void PressPowerButton();
    void PressPlayButton();
    void PressStopButton();
  }

  public class AudioPlayer(AudioPlayer.AudioPlayerState? state = default) : IAudioPlayer
  {
    public AudioPlayerState CurrentState { get; set; } = state ?? new PowerOffState();
    public bool PowerIsOn => CurrentState.GetType() != typeof(PowerOffState);

    public void PressPowerButton() => CurrentState = CurrentState.PressPowerButton();
    public void PressPlayButton() => CurrentState = CurrentState.PressPlayButton();
    public void PressStopButton() => CurrentState = CurrentState.PressStopButton();

    public abstract class AudioPlayerState
    {
      public virtual AudioPlayerState PressPlayButton() => this;
      public virtual AudioPlayerState PressPowerButton() => this;
      public virtual AudioPlayerState PressStopButton() => this;
    }

    public class PowerOffState : AudioPlayerState
    {
      public override AudioPlayerState PressPowerButton() => new StandbyState();
    }

    public class StandbyState : AudioPlayerState
    {
      public override AudioPlayerState PressPlayButton() => new PlayingState();
      public override AudioPlayerState PressPowerButton() => new PowerOffState();
    }

    public class PlayingState : AudioPlayerState
    {
      public override AudioPlayerState PressPlayButton() => new PausedState();
      public override AudioPlayerState PressPowerButton() => new PowerOffState();
      public override AudioPlayerState PressStopButton() => new StandbyState();
    }

    public class PausedState : AudioPlayerState
    {
      public override AudioPlayerState PressPlayButton() => new PlayingState();
      public override AudioPlayerState PressStopButton() => new StandbyState();
      public override AudioPlayerState PressPowerButton() => new PowerOffState();
    }
  }
}
