using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider reloadBar;

    public void SetReloadTime(float reloadTime)
    {
        reloadBar.maxValue = reloadTime;
        reloadBar.value = reloadTime;
    }

    public void SetCurrentStatus(float reloadTime)
    {
        reloadBar.value = reloadTime;
    }
}
