public class EnemyCharacteristic : CharacteristicControl, ICharacteristicControl
{
    public float StartHealth = 5f;    
    public float StartMoveSpeed = 2f;    
    public float StartMeleeDamage = 5f;


    private void Awake()
    {
        AddCharacteristic(CharacteristicsNames.Health, StartHealth);        
        AddCharacteristic(CharacteristicsNames.MoveSpeed, StartMoveSpeed);        
        AddCharacteristic(CharacteristicsNames.MeleeDamage, StartMeleeDamage);
    }
}
