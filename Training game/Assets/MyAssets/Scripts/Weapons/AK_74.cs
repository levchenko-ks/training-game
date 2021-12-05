public class AK_74 : BaseWeapon, IWeapon
{
    private int _baseNumberOfShot = 1;
    private int _baseMaxAmmo = 30;
    private float _baserateOfFire = 400f;
    private float _baseReloadTime = 3f;
    private float _baseSprayAngle = 20f;
    private Sounds _sound = Sounds.AK_74_Fire;

    override protected void SetupProperties()
    {
        weaponIndex = 0;
        projectileName = Projectiles.Bullet;

        numberOfShot = _baseNumberOfShot;
        maxAmmo = _baseMaxAmmo;
        rateOfFire = _baserateOfFire;
        sound = _sound;

        if (_weaponCharacteristic == null)
        {            
            reloadTime = _baseReloadTime;
            sprayAngle = _baseSprayAngle;
        }
        else
        {
            reloadTime = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.ReloadSpeed) * _baseReloadTime;
            sprayAngle = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy) * _baseSprayAngle;
        }               
    }
}
