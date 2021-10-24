using UnityEngine;

public class PlayerCharacteristics : CharacteristicControl, ICharacteristicControl
{
    public float StartHealth;
    public float StartStamina;
    public float StartMoveSpeed;
    public float StartReloadSpeed;
    public float StartAccuracy;

    private void Awake()
    {
        SetupCharacteristic(CharacteristicsNames.Health);
        SetupCharacteristic(CharacteristicsNames.Stamina);
        SetupCharacteristic(CharacteristicsNames.MoveSpeed);
        SetupCharacteristic(CharacteristicsNames.ReloadSpeed);
        SetupCharacteristic(CharacteristicsNames.Accuracy);


        AddCharacteristic(CharacteristicsNames.Health, StartHealth);
        AddCharacteristic(CharacteristicsNames.Stamina, StartStamina);
        AddCharacteristic(CharacteristicsNames.MoveSpeed, StartMoveSpeed);
        AddCharacteristic(CharacteristicsNames.ReloadSpeed, StartReloadSpeed);
        AddCharacteristic(CharacteristicsNames.Accuracy, StartAccuracy);
    }

    private void SetupCharacteristic(CharacteristicsNames name)
    {
        if (PlayerPrefs.HasKey(name.ToString()))
        {
            StartHealth = PlayerPrefs.GetFloat(name.ToString());
        }
        else
        {
            StartHealth = 5f;
            PlayerPrefs.SetFloat(name.ToString(), StartHealth);
        }
    }
}
