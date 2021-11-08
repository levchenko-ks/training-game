using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public event Action<float> ReloadTimeChanged;
    public event Action<float> ReloadStatusChanged;
    public event Action<int> MaxAmmoChanged;
    public event Action<int> CurrentAmmoChanged;
    public event Action<int> WeaponIconStatus;

    public Transform _firePoint;

    protected ICharacteristicControl _weaponCharacteristic;
    protected IResourcesManager _resourcesManager;
    protected Projectile _projectilePref;

    protected int weaponIndex;
    protected int numberOfShot;
    protected int maxAmmo;
    protected float rateOfFire; // per minute    
    protected float reloadTime;
    protected float sprayAngle; // per side    

    private IInputManager _inputManager;        
    private Transform _projectileHolder;

    private bool _isReload;
    private int _currentAmmo;
    private float _timeToFire = 0f;

    public Transform ProjectileHolder { set => _projectileHolder = value; }
    public int WeaponIndex { get => weaponIndex; }

    private void Awake()
    {
        _inputManager = ServiceLocator.GetInputManagerStatic();
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
        _weaponCharacteristic = ServiceLocator.GetPlayerStatic().GetComponent<PlayerCharacteristics>();

        SetupProperties();

        _currentAmmo = maxAmmo;
        _inputManager.LeftClick += OnFire;
    }

    private void OnEnable()
    {
        ReloadTimeChanged?.Invoke(reloadTime);
        ReloadStatusChanged?.Invoke(0f);
        MaxAmmoChanged?.Invoke(maxAmmo);
        CurrentAmmoChanged?.Invoke(_currentAmmo);
        WeaponIconStatus?.Invoke(weaponIndex);

        if (_isReload)
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        if (_isReload)
        {
            Reloading();
        }
    }

    public void OnFire()
    {
        if (Time.time >= _timeToFire && !_isReload)
        {
            if (_currentAmmo != 0) { Shoot(numberOfShot); }
            else { Reload(); }
        }
    }

    private void Shoot(int numberOfShot)
    {
        for (int i = 1; i <= numberOfShot; i++)
        {
            var spray = Quaternion.Euler(0f, Random.Range(-sprayAngle, sprayAngle), 0f);
            Quaternion fireDirection = _firePoint.rotation * spray;

            Instantiate(_projectilePref, _firePoint.position, fireDirection, _projectileHolder);            
        }

        _timeToFire = Time.time + 60f / rateOfFire;
        _currentAmmo--;
        CurrentAmmoChanged?.Invoke(_currentAmmo);
    }
    private void Reload()
    {
        _isReload = true;
        _timeToFire = Time.time + reloadTime;
    }

    private void Reloading()
    {
        var status = reloadTime - (_timeToFire - Time.time);
        ReloadStatusChanged?.Invoke(status);

        if (Time.time >= _timeToFire)
        {
            ReloadStatusChanged?.Invoke(0f);
            _currentAmmo = maxAmmo;
            CurrentAmmoChanged?.Invoke(_currentAmmo);
            _isReload = false;
        }
    }

    virtual public void SetupProperties()
    {
        // Override for each weapon
        return;
    }
}
