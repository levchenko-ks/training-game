public interface IStateService
{
    bool GamePaused { get; set; }
    bool GameIsOver { get; set; }
    bool PlayerIsDead { get; set; }
    bool SessionStarted { get; set; }
}
