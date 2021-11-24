using System;
using UnityEngine;

public interface IUnitRepository
{
    event Action<IEnemy> EnemyDied;

    void AddEnemy(IEnemy enemy);
}
