using System;

public interface ILevelScore
{
    event Action<float> ScoreChanged;

    void AddEnemyScore(IEnemy enemy);
}
