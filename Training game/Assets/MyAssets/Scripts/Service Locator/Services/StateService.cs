public class StateService : IStateService
{
    private static bool _gamePaused = false;
    private static bool _gameIsOver = false;
    private static bool _playerIsDead = false;
    private static bool _sessionStarted = false;

    public bool GamePaused { get => _gamePaused; set => _gamePaused = value; }
    public bool GameIsOver { get => _gameIsOver; set => _gameIsOver = value; }
    public bool PlayerIsDead { get => _playerIsDead; set => _playerIsDead = value; }
    public bool SessionStarted { get => _sessionStarted; set => _sessionStarted = value; }
}
