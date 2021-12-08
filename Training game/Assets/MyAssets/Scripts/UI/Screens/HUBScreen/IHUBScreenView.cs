using System;
using UnityEngine;

public interface IHUBScreenView : IView
{  
    event Action UpgradeHPClicked;
    event Action UpgradeSTClicked;
    event Action UpgradeRSClicked;
    event Action UpgradeMSClicked;
    event Action UpgradeACClicked;
    event Action NextLevelClicked;

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
    void OnNextLevelClicked();
    void SetNextLevelCounter(int counter);  
}
