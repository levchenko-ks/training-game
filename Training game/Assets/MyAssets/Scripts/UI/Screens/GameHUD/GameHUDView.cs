using UnityEngine;
using UnityEngine.UI;

public class GameHUDView : MonoBehaviour, IGameHUDView
{
    public Slider healthBar;
    public Slider reloadBar;
    public Text AmmoCounter;
   

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
        throw new System.NotImplementedException();
    }

    public void SetWeaponIcon(int count)
    {
        throw new System.NotImplementedException();
    }
}
