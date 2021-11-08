public class AK_74 : Weapon
{
    private int _baseNumberOfShot = 1;
    private int _baseMaxAmmo = 30;
    private float _baserateOfFire = 10f;
    private float _baseReloadTime = 3f;
    private float _baseSprayAngle = 5f;

    override public void SetupProperties()
    {
        weaponIndex = 0;

        numberOfShot = _baseNumberOfShot;
        maxAmmo = _baseMaxAmmo;
        rateOfFire = _baserateOfFire;
        reloadTime = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.ReloadSpeed) * _baseReloadTime;
        sprayAngle = _weaponCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy) * _baseSprayAngle;

        _projectilePref = _resourcesManager.GetPrefab<Projectiles, Projectile>(Projectiles.Bullet);
    }
}
