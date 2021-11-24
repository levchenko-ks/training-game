using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour, ILevelScore
{
    public event Action<float> ScoreChanged;

    private ISaveService _saveService;
    private IUnitRepository _unitRepository;

    private Dictionary<string, float> _enemyPrices;

    private float _currentScore;


    private void Awake()
    {
        _saveService = ServiceLocator.GetSaveService();
        _unitRepository = ServiceLocator.GetUnitRepository();

        _currentScore = _saveService.GetFloat(SavesKeys.Score);
        _unitRepository.EnemyDied += AddEnemyScore;

        _enemyPrices = new Dictionary<string, float>();
        _enemyPrices.Add(Characters.Zombie.ToString(), 50f);
    }

    private void Start()
    {
        ScoreChanged?.Invoke(_currentScore);
    }

    public void AddEnemyScore(IEnemy enemy)
    {
        var name = enemy.GetType().Name;

        if(_enemyPrices.ContainsKey(name))
        {
            _currentScore += _enemyPrices[name];
            ScoreChanged?.Invoke(_currentScore);
            _saveService.SetFloat(SavesKeys.Score, _currentScore);
        }        
    }
}
