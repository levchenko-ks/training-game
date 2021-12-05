public class Bennelli_M4 : BaseWeapon, IWeapon
{
    private int _baseNumberOfShot = 8;
    private int _baseMaxAmmo = 8;
    private float _baserateOfFire = 5f;
    private float _baseReloadTime = 5f;
    private float _baseSprayAngle = 15f;   

    override protected void SetupProperties()
    {
        weaponIndex = 1;
        projectileName = Projectiles.Buckshot;

        numberOfShot = _baseNumberOfShot;
        maxAmmo = _baseMaxAmmo;
        rateOfFire = _baserateOfFire;
        reloadTime = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.ReloadSpeed) * _baseReloadTime;
        sprayAngle = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy) * _baseSprayAngle;
    }
}
