public interface IHUBScreen: IScreen
{
    void SetScoreCounter(float score);
    void SetCounter(SavesKeys name, float value);
    void SetUpgradePrice(SavesKeys name, float value);
    void HideUpgradeButton(SavesKeys name);
    void ShowUpgradeButton(SavesKeys name);
    void SetNextLevelCounter(int counter);
}
