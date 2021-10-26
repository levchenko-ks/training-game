using UnityEngine;

public class LevelScore : MonoBehaviour, ILevelScore
{
    private float _currentScore;
    private int _enemyKilled = 0;
    private IGameHUD _gameHUD;

    public float CurrentScore { get => _currentScore; }
    public int EnemyKilled { get => _enemyKilled; }
    public IGameHUD GameHUD
    {
        set
        {
            _gameHUD = value;
            _gameHUD.SetScore(_currentScore);
        }
    }

    private void Awake()
    {
        _currentScore = PlayerPrefs.GetFloat(SavesKeys.Score.ToString(), 0f);        
    }

    public void AddScore(ScoreGainers name)
    {
        switch (name)
        {
            case ScoreGainers.Zombie:
                _currentScore += 100f;
                _enemyKilled++;
                break;
            case ScoreGainers.Score_Capsule:
                _currentScore += 500;
                break;
        }
        _gameHUD.SetScore(_currentScore);
        PlayerPrefs.SetFloat(SavesKeys.Score.ToString(), _currentScore);
    }

    public void AddScoreContainer(ScoreContainer container)
    {
        container.GainScore += AddScore;
    }

}
