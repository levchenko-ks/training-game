using System;

public interface IHUBScreenView
{
    event Action UpgradeHPCliked;
    event Action UpgradeSTCliked;
    event Action UpgradeRSCliked;
    event Action UpgradeMSCliked;
    event Action UpgradeACCliked;

    void Show();
    void Hide();
    void SetScoreCounter(float score);
    void SetCounter(CharacteristicsNames name, float value);
    void SetUpgradePrice(CharacteristicsNames name, float value);
    void HideUpgradeButton(CharacteristicsNames name);
    void ShowUpgradeButton(CharacteristicsNames name);
    void OnUpgradeHPClicked();
    void OnUpgradeSTClicked();
    void OnUpgradeRSClicked();
    void OnUpgradeMSClicked();
    void OnUpgradeACClicked();    
}
