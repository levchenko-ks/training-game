using System;

public interface IUnitRepository
{
    event Action<IEnemy> EnemyDied;

    void AddEnemy(IEnemy enemy);
}
