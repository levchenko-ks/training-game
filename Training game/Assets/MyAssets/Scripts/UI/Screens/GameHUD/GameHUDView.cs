using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDView : MonoBehaviour, IGameHUDView
{
    public Slider healthBar;
    public Slider reloadBar;
    public Text AmmoCounter;
    public Text MaxAmmo;
    public Text Score;

    public Text HP;
    public Text ST;
    public Text RS;
    public Text MS;
    public Text AC;

    public List<Image> WeaponImages;


    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetAmmo(int count)
    {
        AmmoCounter.text = count.ToString();
    }

    public void SetMaxHP(float amount)
    {
        healthBar.maxValue = amount;
        healthBar.value = amount;
    }

    public void SetHP(float amount)
    {
        healthBar.value = amount;
    }

    public void SetReloadTime(float amount)
    {
        reloadBar.maxValue = amount;
        reloadBar.value = amount;
    }

    public void SetReloadStatus(float amount)
    {
        reloadBar.value = amount;
    }

    public void SetMaxAmmo(float amount)
    {
        MaxAmmo.text = amount.ToString();
    }

    public void ShowWeaponIcon(int index)
    {
        WeaponImages[index].enabled = true;
    }

    public void HideWeaponIcon(int index)
    {
        WeaponImages[index].enabled = false;
    }

    public void SetCharacteristic(CharacteristicsNames name, float count)
    {
        switch (name)
        {
            case CharacteristicsNames.Accuracy:
                AC.text = count.ToString();
                return;
            case CharacteristicsNames.Health:
                HP.text = count.ToString();
                return;
            case CharacteristicsNames.MoveSpeed:
                MS.text = count.ToString();
                return;
            case CharacteristicsNames.ReloadSpeed:
                RS.text = count.ToString();
                return;
            case CharacteristicsNames.Stamina:
                ST.text = count.ToString();
                return;
            default: throw new Exception("Characteristic does not exist");
        }
    }

    public void SetScore(float score)
    {
        Score.text = score.ToString();
    }
}
