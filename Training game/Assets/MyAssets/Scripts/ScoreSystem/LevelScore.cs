using UnityEngine;

public class LevelScore : MonoBehaviour, ILevelScore
{
    private float _currentScore;
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
