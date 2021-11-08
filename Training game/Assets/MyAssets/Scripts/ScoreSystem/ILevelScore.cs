using System;

public interface ILevelScore
{
    event Action<float> ScoreChanged;
    event Action<int> EnemyKilled;
       
    void AddScore(ScoreGainers name);
    void AddScoreContainer(ScoreContainer container);
}
