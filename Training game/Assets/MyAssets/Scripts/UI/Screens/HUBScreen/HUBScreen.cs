using System.Collections.Generic;
using UnityEngine;

public class HUBScreen : MonoBehaviour, IHUBScreen
{
    public HUBScreenView _viewPrefab;

    private Canvas _canvasFHD;
    private IHUBScreenView View;
    private readonly List<CharacteristicsNames> _characteristicsList = new List<CharacteristicsNames>();

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            Hide();
            View.UpgradeHPCliked += OnUpgradeHPCliked;
            View.UpgradeSTCliked += OnUpgradeSTCliked;
            View.UpgradeRSCliked += OnUpgradeRSCliked;
            View.UpgradeMSCliked += OnUpgradeMSCliked;
            View.UpgradeACCliked += OnUpgradeACCliked;
        }
    }

    private void Awake()
    {
        _characteristicsList.Add(CharacteristicsNames.Health);
        _characteristicsList.Add(CharacteristicsNames.Stamina);
        _characteristicsList.Add(CharacteristicsNames.ReloadSpeed);
        _characteristicsList.Add(CharacteristicsNames.MoveSpeed);
        _characteristicsList.Add(CharacteristicsNames.Accuracy);
    }

    private void Start()
    {
        var score = PlayerPrefs.GetFloat(SavesKeys.Score.ToString());

        SetScoreCounter(score);
        CheckButtons(score);

        var HP = PlayerPrefs.GetFloat(SavesKeys.Health.ToString());
        var ST = PlayerPrefs.GetFloat(SavesKeys.Stamina.ToString());
        var RS = PlayerPrefs.GetFloat(SavesKeys.ReloadSpeed.ToString());
        var MS = PlayerPrefs.GetFloat(SavesKeys.MoveSpeed.ToString());
        var AC = PlayerPrefs.GetFloat(SavesKeys.ReloadSpeed.ToString());

        SetCounter(CharacteristicsNames.Health, HP);
        SetCounter(CharacteristicsNames.Stamina, ST);
        SetCounter(CharacteristicsNames.ReloadSpeed, RS);
        SetCounter(CharacteristicsNames.MoveSpeed, MS);
        SetCounter(CharacteristicsNames.Accuracy, AC);
    }

    public void Hide() => View.Hide();

    public void SetScoreCounter(float score) => View.SetScoreCounter(score);

    public void HideUpgradeButton(CharacteristicsNames name) => View.HideUpgradeButton(name);

    public void SetCounter(CharacteristicsNames name, float value) => View.SetCounter(name, value);

    public void SetUpgradePrice(CharacteristicsNames name, float value) => View.SetUpgradePrice(name, value);

    public void Show() => View.Show();

    public void ShowUpgradeButton(CharacteristicsNames name) => View.ShowUpgradeButton(name);

    private float CalculatePrice(CharacteristicsNames name)
    {
        float value = PlayerPrefs.GetFloat(name.ToString());
        float price = (value - 4f) * 100f;
        return price;
    }

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

    private void UpgradeCharacteristic(CharacteristicsNames name)
    {
        var value = PlayerPrefs.GetFloat(name.ToString());
        var score = PlayerPrefs.GetFloat(SavesKeys.Score.ToString());
        score -= CalculatePrice(name);
        value++;
        PlayerPrefs.SetFloat(name.ToString(), value);
        var newprice = CalculatePrice(name);

        PlayerPrefs.SetFloat(name.ToString(), value);
        PlayerPrefs.SetFloat(SavesKeys.Score.ToString(), score);
        SetCounter(name, value);
        SetScoreCounter(score);
        SetUpgradePrice(name, newprice);
        CheckButtons(score);
    }

    private void CheckButtonPrice(CharacteristicsNames name, float score)
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
        foreach (CharacteristicsNames name in _characteristicsList)
        {
            CheckButtonPrice(name, score);
        }
    }
}
