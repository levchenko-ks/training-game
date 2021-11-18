using UnityEngine;

public class PlayerCharacteristics : CharacteristicControl, ICharacteristicControl
{
    private void Awake()
    {
        SetupCharacteristic(CharacteristicsNames.Health);
        SetupCharacteristic(CharacteristicsNames.Stamina);
        SetupCharacteristic(CharacteristicsNames.MoveSpeed);
        SetupCharacteristic(CharacteristicsNames.ReloadSpeed);
        SetupCharacteristic(CharacteristicsNames.Accuracy);
    }

    private void SetupCharacteristic(CharacteristicsNames name)
    {
        var StartChar = 5f;

        if (PlayerPrefs.HasKey(name.ToString()))
        {
            StartChar = PlayerPrefs.GetFloat(name.ToString());            
        }
        else
        {            
            PlayerPrefs.SetFloat(name.ToString(), StartChar);           
        }

        AddCharacteristic(name, StartChar);
    }
}
