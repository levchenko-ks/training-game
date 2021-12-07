using System;
using UnityEngine;
using UnityEngine.UI;

public class HUBScreenView : BaseView /*, IHUBScreenView*/
{
    /*
    public event Action UpgradeHPClicked;
    public event Action UpgradeSTClicked;
    public event Action UpgradeRSClicked;
    public event Action UpgradeMSClicked;
    public event Action UpgradeACClicked;
    public event Action NextLevelClicked;

    public Text Score;
    public Text HP;
    public Text ST;
    public Text RS;
    public Text MS;
    public Text AC;

    public Button UpgradeHP;
    public Button UpgradeST;
    public Button UpgradeRS;
    public Button UpgradeMS;
    public Button UpgradeAC;
    public Button NextLevel;
    public Text PriceHP;
    public Text PriceST;
    public Text PriceRS;
    public Text PriceMS;
    public Text PriceAC;
    public Text LevelCounter;

    private void Awake()
    {
        UpgradeHP.onClick.AddListener(OnUpgradeHPClicked);
        UpgradeST.onClick.AddListener(OnUpgradeSTClicked);
        UpgradeRS.onClick.AddListener(OnUpgradeRSClicked);
        UpgradeMS.onClick.AddListener(OnUpgradeMSClicked);
        UpgradeAC.onClick.AddListener(OnUpgradeACClicked);
        NextLevel.onClick.AddListener(OnNextLevelClicked);
    }       

    public void HideUpgradeButton(SavesKeys name)
    {
        switch (name)
        {
            case SavesKeys.Health:
                UpgradeHP.interactable = false;
                break;
            case SavesKeys.Stamina:
                UpgradeST.interactable = false;
                break;
            case SavesKeys.ReloadSpeed:
                UpgradeRS.interactable = false;
                break;
            case SavesKeys.MoveSpeed:
                UpgradeMS.interactable = false;
                break;
            case SavesKeys.Accuracy:
                UpgradeAC.interactable = false;
                break;
        }
    }

    public void SetCounter(SavesKeys name, float value)
    {
        switch (name)
        {
            case SavesKeys.Health:
                HP.text = value.ToString();
                break;
            case SavesKeys.Stamina:
                ST.text = value.ToString();
                break;
            case SavesKeys.ReloadSpeed:
                RS.text = value.ToString();
                break;
            case SavesKeys.MoveSpeed:
                MS.text = value.ToString();
                break;
            case SavesKeys.Accuracy:
                AC.text = value.ToString();
                break;
        }
    }

    public void SetUpgradePrice(SavesKeys name, float value)
    {
        switch (name)
        {
            case SavesKeys.Health:
                PriceHP.text = "Upgrade: " + value.ToString();
                break;
            case SavesKeys.Stamina:
                PriceST.text = "Upgrade: " + value.ToString();
                break;
            case SavesKeys.ReloadSpeed:
                PriceRS.text = "Upgrade: " + value.ToString();
                break;
            case SavesKeys.MoveSpeed:
                PriceMS.text = "Upgrade: " + value.ToString();
                break;
            case SavesKeys.Accuracy:
                PriceAC.text = "Upgrade: " + value.ToString();
                break;
        }
    }

    public void ShowUpgradeButton(SavesKeys name)
    {
        switch (name)
        {
            case SavesKeys.Health:
                UpgradeHP.interactable = true;
                break;
            case SavesKeys.Stamina:
                UpgradeST.interactable = true;
                break;
            case SavesKeys.ReloadSpeed:
                UpgradeRS.interactable = true;
                break;
            case SavesKeys.MoveSpeed:
                UpgradeMS.interactable = true;
                break;
            case SavesKeys.Accuracy:
                UpgradeAC.interactable = true;
                break;
        }
    }

    public void OnUpgradeHPClicked() => UpgradeHPClicked();

    public void OnUpgradeSTClicked() => UpgradeSTClicked();

    public void OnUpgradeRSClicked() => UpgradeRSClicked();

    public void OnUpgradeMSClicked() => UpgradeMSClicked();

    public void OnUpgradeACClicked() => UpgradeACClicked();

    public void SetScoreCounter(float score) => Score.text = score.ToString();

    public void OnNextLevelClicked() => NextLevelClicked();

    public void SetNextLevelCounter(int counter)
    {
        LevelCounter.text = "Go to next level: " + counter.ToString();
    }
    */
}
