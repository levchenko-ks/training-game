using System;
using UnityEngine;
using UnityEngine.UI;

public class HUBScreenView : BaseView , IHUBScreenView
{    
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

    public void HideUpgradeButton(CharacteristicsNames name)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                UpgradeHP.interactable = false;
                break;
            case CharacteristicsNames.Stamina:
                UpgradeST.interactable = false;
                break;
            case CharacteristicsNames.ReloadSpeed:
                UpgradeRS.interactable = false;
                break;
            case CharacteristicsNames.MoveSpeed:
                UpgradeMS.interactable = false;
                break;
            case CharacteristicsNames.Accuracy:
                UpgradeAC.interactable = false;
                break;
        }
    }

    public void SetCounter(CharacteristicsNames name, float value)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                HP.text = value.ToString();
                break;
            case CharacteristicsNames.Stamina:
                ST.text = value.ToString();
                break;
            case CharacteristicsNames.ReloadSpeed:
                RS.text = value.ToString();
                break;
            case CharacteristicsNames.MoveSpeed:
                MS.text = value.ToString();
                break;
            case CharacteristicsNames.Accuracy:
                AC.text = value.ToString();
                break;
        }
    }

    public void SetUpgradePrice(CharacteristicsNames name, float value)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                PriceHP.text = $"Upgrade: {value}";
                break;
            case CharacteristicsNames.Stamina:
                PriceST.text = $"Upgrade: {value}";
                break;
            case CharacteristicsNames.ReloadSpeed:
                PriceRS.text = $"Upgrade: {value}";
                break;
            case CharacteristicsNames.MoveSpeed:
                PriceMS.text = $"Upgrade: {value}";
                break;
            case CharacteristicsNames.Accuracy:
                PriceAC.text = $"Upgrade: {value}";
                break;
        }
    }

    public void ShowUpgradeButton(CharacteristicsNames name)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                UpgradeHP.interactable = true;
                break;
            case CharacteristicsNames.Stamina:
                UpgradeST.interactable = true;
                break;
            case CharacteristicsNames.ReloadSpeed:
                UpgradeRS.interactable = true;
                break;
            case CharacteristicsNames.MoveSpeed:
                UpgradeMS.interactable = true;
                break;
            case CharacteristicsNames.Accuracy:
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
        LevelCounter.text = $"Go to next level: {counter}";
    }    
}
