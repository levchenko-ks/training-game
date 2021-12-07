using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUBScreen : MonoBehaviour /*, IHUBScreen*/
{
    /*
    public event Action Hided;

    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;

    private Canvas _canvasFHD;
    private IHUBScreenView View;


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _saveService = ServiceLocator.GetSaveService();
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, HUBScreenView>(UIViews.HUBScreenView);
        View.SetCanvas(_canvasFHD);

        View.UpgradeHPClicked += OnUpgradeHPCliked;
        View.UpgradeSTClicked += OnUpgradeSTCliked;
        View.UpgradeRSClicked += OnUpgradeRSCliked;
        View.UpgradeMSClicked += OnUpgradeMSCliked;
        View.UpgradeACClicked += OnUpgradeACCliked;
        View.NextLevelClicked += OnNextLevelClicked;
    }

    private void Start()
    {
        var score = _saveService.GetScore();
        var level = _saveService.GetLevel();

        SetScoreCounter(score);
        CheckButtons(score);

        // Update counters
        var HP = _saveService.GetHealth();
        var ST = _saveService.GetStamina();
        var RS = _saveService.GetReloadSpeed();
        var MS = _saveService.GetMoveSpeed();
        var AC = _saveService.GetAccuracy();

        SetCounter(SavesKeys.Health, HP);
        SetCounter(SavesKeys.Stamina, ST);
        SetCounter(SavesKeys.ReloadSpeed, RS);
        SetCounter(SavesKeys.MoveSpeed, MS);
        SetCounter(SavesKeys.Accuracy, AC);
        SetNextLevelCounter(level);
        CheckUprgadePrices();
    }

    private void OnDestroy()
    {
        View.UpgradeHPClicked -= OnUpgradeHPCliked;
        View.UpgradeSTClicked -= OnUpgradeSTCliked;
        View.UpgradeRSClicked -= OnUpgradeRSCliked;
        View.UpgradeMSClicked -= OnUpgradeMSCliked;
        View.UpgradeACClicked -= OnUpgradeACCliked;
        View.NextLevelClicked -= OnNextLevelClicked;
    }

    public void SetHolder(Transform holder)
    {
        transform.SetParent(holder, false);
    }

    public void Hide() => View.Hide();

    public void SetScoreCounter(float score) => View.SetScoreCounter(score);

    public void HideUpgradeButton(SavesKeys name) => View.HideUpgradeButton(name);

    public void SetCounter(SavesKeys name, float value) => View.SetCounter(name, value);

    public void SetUpgradePrice(SavesKeys name, float value) => View.SetUpgradePrice(name, value);

    public void Show() => View.Show();

    public void ShowUpgradeButton(SavesKeys name) => View.ShowUpgradeButton(name);

    public void SetNextLevelCounter(int counter) => View.SetNextLevelCounter(counter);

    private float CalculatePrice(SavesKeys name)
    {
        float value = _saveService.GetFloat(name);
        float price = (value - 4f) * 100f;
        return price;
    }

    private void OnUpgradeACCliked()
    {
        var name = SavesKeys.Accuracy;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeMSCliked()
    {
        var name = SavesKeys.MoveSpeed;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeRSCliked()
    {
        var name = SavesKeys.ReloadSpeed;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeSTCliked()
    {
        var name = SavesKeys.Stamina;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeHPCliked()
    {
        var name = SavesKeys.Health;
        UpgradeCharacteristic(name);
    }
    private void OnNextLevelClicked()
    {
        SceneManager.LoadScene("Level");
    }

    private void UpgradeCharacteristic(SavesKeys name)
    {
        var value = _saveService.GetFloat(name);
        var score = _saveService.GetFloat(SavesKeys.Score);
        score -= CalculatePrice(name);
        value++;
        _saveService.SetFloat(name, value);
        var newprice = CalculatePrice(name);

        _saveService.SetFloat(name, value);
        _saveService.SetFloat(SavesKeys.Score, score);
        SetCounter(name, value);
        SetScoreCounter(score);
        SetUpgradePrice(name, newprice);
        CheckButtons(score);
    }

    private void CheckButtonPrice(SavesKeys name, float score)
    {
        if (CalculatePrice(name) > score)
        {
            HideUpgradeButton(name);
        }
        else
        {
            ShowUpgradeButton(name);
        }
    }

    private void CheckButtons(float score)
    {
        foreach (SavesKeys name in _characteristicsList)
        {
            CheckButtonPrice(name, score);
        }
    }

    private void CheckUprgadePrices()
    {
        foreach (SavesKeys name in _characteristicsList)
        {
            var price = CalculatePrice(name);
            SetUpgradePrice(name, price);
        }
    }
*/
}
