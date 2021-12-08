using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUBScreen : MonoBehaviour, IHUBScreen
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;

    private Canvas _canvasFHD;
    private IHUBScreenView View;

    private readonly string _level = Scenes.Level.ToString();


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

        var HP = _saveService.GetHealth();
        var ST = _saveService.GetStamina();
        var RS = _saveService.GetReloadSpeed();
        var MS = _saveService.GetMoveSpeed();
        var AC = _saveService.GetAccuracy();

        SetScoreCounter(score);
        SetCounter(CharacteristicsNames.Health, HP);
        SetCounter(CharacteristicsNames.Stamina, ST);
        SetCounter(CharacteristicsNames.ReloadSpeed, RS);
        SetCounter(CharacteristicsNames.MoveSpeed, MS);
        SetCounter(CharacteristicsNames.Accuracy, AC);
        SetUpgradePrice(CharacteristicsNames.Health, CalculatePrice(HP));
        SetUpgradePrice(CharacteristicsNames.Stamina, CalculatePrice(ST));
        SetUpgradePrice(CharacteristicsNames.ReloadSpeed, CalculatePrice(RS));
        SetUpgradePrice(CharacteristicsNames.MoveSpeed, CalculatePrice(MS));
        SetUpgradePrice(CharacteristicsNames.Accuracy, CalculatePrice(AC));
        SetNextLevelCounter(level);
        CheckButtons();
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

    public void HideUpgradeButton(CharacteristicsNames name) => View.HideUpgradeButton(name);

    public void SetCounter(CharacteristicsNames name, float value) => View.SetCounter(name, value);

    public void SetUpgradePrice(CharacteristicsNames name, float value) => View.SetUpgradePrice(name, value);

    public void Show() => View.Show();

    public void ShowUpgradeButton(CharacteristicsNames name) => View.ShowUpgradeButton(name);

    public void SetNextLevelCounter(int counter) => View.SetNextLevelCounter(counter);


    private void OnUpgradeACCliked()
    {
        var name = CharacteristicsNames.Accuracy;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeMSCliked()
    {
        var name = CharacteristicsNames.MoveSpeed;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeRSCliked()
    {
        var name = CharacteristicsNames.ReloadSpeed;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeSTCliked()
    {
        var name = CharacteristicsNames.Stamina;
        UpgradeCharacteristic(name);
    }

    private void OnUpgradeHPCliked()
    {
        var name = CharacteristicsNames.Health;
        UpgradeCharacteristic(name);
    }
    private void OnNextLevelClicked()
    {
        SceneManager.LoadScene(_level);
    }

    private void UpgradeCharacteristic(CharacteristicsNames name)
    {
        var value = GetCharacteristicValue(name);
        var score = _saveService.GetScore();

        score -= CalculatePrice(value);
        value++;
        SetCharacteristicValue(name, value);
        _saveService.SetScore(score);

        var newprice = CalculatePrice(value);
        SetCounter(name, value);
        SetScoreCounter(score);
        SetUpgradePrice(name, newprice);
        CheckButtons();
    }

    private float GetCharacteristicValue(CharacteristicsNames name)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                return _saveService.GetHealth();
            case CharacteristicsNames.Stamina:
                return _saveService.GetStamina();
            case CharacteristicsNames.ReloadSpeed:
                return _saveService.GetReloadSpeed();
            case CharacteristicsNames.MoveSpeed:
                return _saveService.GetMoveSpeed();
            case CharacteristicsNames.Accuracy:
                return _saveService.GetAccuracy();
            default:
                return 0f;
        }
    }

    private void SetCharacteristicValue(CharacteristicsNames name, float value)
    {
        switch (name)
        {
            case CharacteristicsNames.Health:
                _saveService.SetHealth(value);
                break;
            case CharacteristicsNames.Stamina:
                _saveService.SetStamina(value);
                break;
            case CharacteristicsNames.ReloadSpeed:
                _saveService.SetReloadSpeed(value);
                break;
            case CharacteristicsNames.MoveSpeed:
                _saveService.SetMoveSpeed(value);
                break;
            case CharacteristicsNames.Accuracy:
                _saveService.SetAccuracy(value);
                break;
        }
    }

    private float CalculatePrice(float value)
    {
        float price = (value - 4f) * 100f;
        return price;
    }

    private void CheckButtonPrice(CharacteristicsNames name)
    {
        var value = GetCharacteristicValue(name);
        var score = _saveService.GetScore();

        if (CalculatePrice(value) > score)
        {
            HideUpgradeButton(name);
        }
        else
        {
            ShowUpgradeButton(name);
        }
    }

    private void CheckButtons()
    {
        CheckButtonPrice(CharacteristicsNames.Health);
        CheckButtonPrice(CharacteristicsNames.Stamina);
        CheckButtonPrice(CharacteristicsNames.ReloadSpeed);
        CheckButtonPrice(CharacteristicsNames.MoveSpeed);
        CheckButtonPrice(CharacteristicsNames.Accuracy);
    }
}
