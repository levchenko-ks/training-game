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
    void SetCounter(SavesKeys name, float value);
    void SetUpgradePrice(SavesKeys name, float value);
    void HideUpgradeButton(SavesKeys name);
    void ShowUpgradeButton(SavesKeys name);
    void OnUpgradeHPClicked();
    void OnUpgradeSTClicked();
    void OnUpgradeRSClicked();
    void OnUpgradeMSClicked();
    void OnUpgradeACClicked();
    void OnNextLevelClicked();
    void SetNextLevelCounter(int counter);
}
