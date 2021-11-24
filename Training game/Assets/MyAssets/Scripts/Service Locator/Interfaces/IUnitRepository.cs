using System;

public interface IUnitRepository
{
    event Action<IEnemy> EnemyDied;
    event Action<IEnemy> EnemyAdded;

    void AddEnemy(IEnemy enemy);
}
