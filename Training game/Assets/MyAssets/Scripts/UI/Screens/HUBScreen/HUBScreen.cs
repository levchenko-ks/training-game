using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUBScreen : MonoBehaviour, IHUBScreen
{
    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;

    private Canvas _canvasFHD;
    private IHUBScreenView View;
    private readonly List<SavesKeys> _characteristicsList = new List<SavesKeys>();


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
        _saveService = ServiceLocator.GetSaveServiceStatic();
        _canvasFHD = ServiceLocator.GetCanvasStatic();

        View = _resourcesManager.GetInstance<UIViews, HUBScreenView>(UIViews.HUBScreen);
        View.SetCanvas(_canvasFHD);

        View.UpgradeHPClicked += OnUpgradeHPCliked;
        View.UpgradeSTClicked += OnUpgradeSTCliked;
        View.UpgradeRSClicked += OnUpgradeRSCliked;
        View.UpgradeMSClicked += OnUpgradeMSCliked;
        View.UpgradeACClicked += OnUpgradeACCliked;
        View.NextLevelClicked += OnNextLevelClicked;

        _characteristicsList.Add(SavesKeys.Health);
        _characteristicsList.Add(SavesKeys.Stamina);
        _characteristicsList.Add(SavesKeys.ReloadSpeed);
        _characteristicsList.Add(SavesKeys.MoveSpeed);
        _characteristicsList.Add(SavesKeys.Accuracy);

        Hide();
    }

    private void Start()
    {
        var score = _saveService.GetFloat(SavesKeys.Score);
        var level = _saveService.GetInt(SavesKeys.Level);

        SetScoreCounter(score);
        CheckButtons(score);

        // Update counters
        var HP = _saveService.GetFloat(SavesKeys.Health);
        var ST = _saveService.GetFloat(SavesKeys.Stamina);
        var RS = _saveService.GetFloat(SavesKeys.ReloadSpeed);
        var MS = _saveService.GetFloat(SavesKeys.MoveSpeed);
        var AC = _saveService.GetFloat(SavesKeys.ReloadSpeed);

        SetCounter(SavesKeys.Health, HP);
        SetCounter(SavesKeys.Stamina, ST);
        SetCounter(SavesKeys.ReloadSpeed, RS);
        SetCounter(SavesKeys.MoveSpeed, MS);
        SetCounter(SavesKeys.Accuracy, AC);
        SetNextLevelCounter(level);
        CheckUprgadePrices();
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

}
