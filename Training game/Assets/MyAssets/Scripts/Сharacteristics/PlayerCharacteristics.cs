public class PlayerCharacteristics : CharacteristicControl, ICharacteristicControl
{
    public float StartHealth = 5f;
    public float StartStamina = 5f;
    public float StartMoveSpeed = 5f;
    public float StartReloadSpeed = 5f;
    public float StartAccuracy = 5f;

    private void Awake()
    {
        AddCharacteristic(CharacteristicsNames.Health, StartHealth);
        AddCharacteristic(CharacteristicsNames.Stamina, StartStamina);
        AddCharacteristic(CharacteristicsNames.MoveSpeed, StartMoveSpeed);
        AddCharacteristic(CharacteristicsNames.ReloadSpeed, StartReloadSpeed);
        AddCharacteristic(CharacteristicsNames.Accuracy, StartAccuracy);
    }
}
