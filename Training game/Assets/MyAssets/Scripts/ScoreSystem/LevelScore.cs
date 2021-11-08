using System;
using UnityEngine;

public class LevelScore : MonoBehaviour, ILevelScore
{
    public event Action<float> ScoreChanged;
    public event Action<int> EnemyKilled;
    
    private ISaveService _saveService;
    
    private float _currentScore;
    private int _enemyKillsCounter = 0;

    private float ZombieScore = 100f;
    private float CapsuleScore = 500f;




    private void Awake()
    {
        _saveService = ServiceLocator.GetSaveServiceStatic();

        _currentScore = _saveService.GetFloat(SavesKeys.Score);        
    }

    public void AddScore(ScoreGainers name)
    {
        switch (name)
        {
            case ScoreGainers.Zombie:
                _currentScore += ZombieScore;
                _enemyKillsCounter++;
                EnemyKilled?.Invoke(_enemyKillsCounter);
                break;
            case ScoreGainers.Score_Capsule:
                _currentScore += CapsuleScore;
                break;
        }

        ScoreChanged?.Invoke(_currentScore);
        _saveService.SetFloat(SavesKeys.Score, _currentScore);
    }

    public void AddScoreContainer(ScoreContainer container)
    {
        container.GainScore += AddScore;
    }

}
