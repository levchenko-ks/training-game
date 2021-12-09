public class BonusMS : LevelBonusChar
{
    private void Awake()
    {
        Name = CharacteristicsNames.MoveSpeed;
        Type = ModifiersTypes.Flat;
        Amount = 2f;
    }
}
