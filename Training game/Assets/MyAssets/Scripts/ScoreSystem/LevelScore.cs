using UnityEngine;

public class LevelScore : MonoBehaviour, ILevelScore
{
    private float _currentScore = 0f;
    private IGameHUD _gameHUD;

    public float CurrentScore { get => _currentScore; }
    public IGameHUD GameHUD
    {
        set
        {
            _gameHUD = value;
            _gameHUD.SetScore(_currentScore);
        }
    }

    public void AddScore(ScoreGainers name)
    {
        switch (name)
        {
            case ScoreGainers.Zombie:
                _currentScore += 100f;
                break;
            case ScoreGainers.Score_Capsule:
                _currentScore += 500;
                break;
        }
        _gameHUD.SetScore(_currentScore);
    }

    public void AddScoreContainer(ScoreContainer container)
    {
        container.GainScore += AddScore;
    }

}
