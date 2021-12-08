public interface IHUBScreen: IScreen
{   
    void SetScoreCounter(float score);
    void SetCounter(CharacteristicsNames name, float value);
    void SetUpgradePrice(CharacteristicsNames name, float value);
    void HideUpgradeButton(CharacteristicsNames name);
    void ShowUpgradeButton(CharacteristicsNames name);
    void SetNextLevelCounter(int counter);    
}
