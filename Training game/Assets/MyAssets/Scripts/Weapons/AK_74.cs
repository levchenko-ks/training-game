public class AK_74 : Weapon
{
    private int _baseNumberOfShot = 1;
    private int _baseMaxAmmo = 30;
    private float _baserateOfFire = 400f;
    private float _baseReloadTime = 3f;
    private float _baseSprayAngle = 20f;
    private Sounds _sound = Sounds.AK_74_Fire;

    override public void SetupProperties()
    {
        weaponIndex = 0;
        projectileName = Projectiles.Bullet;

        numberOfShot = _baseNumberOfShot;
        maxAmmo = _baseMaxAmmo;
        rateOfFire = _baserateOfFire;
        reloadTime = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.ReloadSpeed) * _baseReloadTime;
        sprayAngle = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy) * _baseSprayAngle;
        sound = _sound;
    }
}
