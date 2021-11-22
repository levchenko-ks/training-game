using System;

public interface ILevelScore
{
    event Action<float> ScoreChanged;
    event Action<Characters> EnemyKilled;
       
    void AddScore(ScoreGainers name);
    void AddScoreContainer(ScoreContainer container);
}
