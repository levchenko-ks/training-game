using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void SetCurrentHealth(float health)
    {
        healthBar.value = health;
    }
}
