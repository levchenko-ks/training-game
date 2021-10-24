using System;
using UnityEngine;
using UnityEngine.UI;

public class HUBScreenView : MonoBehaviour, IHUBScreenView
{
    public event Action UpgradeHPCliked;
    public event Action UpgradeSTCliked;
    public event Action UpgradeRSCliked;
    public event Action UpgradeMSCliked;
    public event Action UpgradeACCliked;

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
    public Text PriceHP;
    public Text PriceST;
    public Text PriceRS;
    public Text PriceMS;
    public Text PriceAC;

    private void Awake()
    {
        UpgradeHP.onClick.AddListener(OnUpgradeHPClicked);
        UpgradeST.onClick.AddListener(OnUpgradeSTClicked);
        UpgradeRS.onClick.AddListener(OnUpgradeRSClicked);
        UpgradeMS.onClick.AddListener(OnUpgradeMSClicked);
        UpgradeAC.onClick.AddListener(OnUpgradeACClicked);        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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
                PriceHP.text = "Upgrade: " + value.ToString();
                break;
            case CharacteristicsNames.Stamina:
                PriceST.text = "Upgrade: " + value.ToString();
                break;
            case CharacteristicsNames.ReloadSpeed:
                PriceRS.text = "Upgrade: " + value.ToString();
                break;
            case CharacteristicsNames.MoveSpeed:
                PriceMS.text = "Upgrade: " + value.ToString();
                break;
            case CharacteristicsNames.Accuracy:
                PriceAC.text = "Upgrade: " + value.ToString();
                break;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
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

    public void OnUpgradeHPClicked()
    {
        UpgradeHPCliked();
        Debug.Log("HP Clicked");
    }

    public void OnUpgradeSTClicked() => UpgradeSTCliked();

    public void OnUpgradeRSClicked() => UpgradeRSCliked();

    public void OnUpgradeMSClicked() => UpgradeMSCliked();

    public void OnUpgradeACClicked() => UpgradeACCliked();

    public void SetScoreCounter(float score)
    {
        Score.text = score.ToString();
    }
}
