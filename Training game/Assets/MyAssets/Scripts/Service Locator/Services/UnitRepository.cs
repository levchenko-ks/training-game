using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitRepository : MonoBehaviour, IUnitRepository
{
    public event Action<IEnemy> EnemyDied;

    private Dictionary<string, List<IEnemy>> _enemyLists = new();

    public void AddEnemy(IEnemy enemy)
    {
        var key = enemy.GetType().Name;

        if (_enemyLists.ContainsKey(key) == false)
        {
            _enemyLists.Add(key, new List<IEnemy>());
        }

        var list = _enemyLists[key];
        list.Add(enemy);
        enemy.Died += RemoveEnemy;
    }

    private void RemoveEnemy(IEnemy enemy)
    {
        var key = enemy.GetType().Name;
        var list = _enemyLists[key];

        enemy.Died -= RemoveEnemy;
        list.Remove(enemy);
        EnemyDied?.Invoke(enemy);
    }
}