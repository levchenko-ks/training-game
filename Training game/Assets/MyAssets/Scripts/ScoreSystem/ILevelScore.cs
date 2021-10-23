public interface ILevelScore
{
    IGameHUD GameHUD { set; }
    void AddScore(ScoreGainers name);
    void AddScoreContainer(ScoreContainer container);
}
