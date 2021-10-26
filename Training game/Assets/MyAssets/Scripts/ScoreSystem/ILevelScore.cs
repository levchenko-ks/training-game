public interface ILevelScore
{
    public int EnemyKilled { get; }
    IGameHUD GameHUD { set; }
    void AddScore(ScoreGainers name);
    void AddScoreContainer(ScoreContainer container);
}
