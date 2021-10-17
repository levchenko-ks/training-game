using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    public void SetMaxHP(float amount)
    {
        healthBar.maxValue = amount;
        healthBar.value = amount;
    }

    public void SetHP(float amount)
    {
        healthBar.value = amount;
    }
}
