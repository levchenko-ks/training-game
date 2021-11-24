using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : MonoBehaviour
{
    public event Action<float> ReloadTimeChanged;
    public event Action<float> ReloadStatusChanged;
    public event Action<int> MaxAmmoChanged;
    public event Action<int> CurrentAmmoChanged;
    public event Action<int> WeaponIconUpdate;

    public Transform _firePoint;

    protected ICharacteristicControl _weaponCharacteristic;
    protected IResourcesManager _resourcesManger;
    protected ISoundManager _soundManager;

    protected Projectiles projectileName;
    protected int weaponIndex;
    protected int numberOfShot;
    protected int maxAmmo;
    protected float rateOfFire; // per minute    
    protected float reloadTime;
    protected float sprayAngle; // per side    
    protected Sounds sound;

    private IInputManager _inputManager;
    private Transform _projectileHolder;

    private bool _isReload;
    private int _currentAmmo;
    private float _timeToFire = 0f;

    public int WeaponIndex { get; }

    private void Awake()
    {
        _inputManager = ServiceLocator.GetInputManager();
        _weaponCharacteristic = ServiceLocator.GetPlayer().GetComponent<PlayerCharacteristics>();
        _resourcesManger = ServiceLocator.GetResourcesManager();
        _soundManager = ServiceLocator.GetSoundManager();

        SetupProperties();

        var name = gameObject.name + PlaceHolders.ProjectilesHolder.ToString();
        var go = new GameObject(name);
        _projectileHolder = go.transform;

        _currentAmmo = maxAmmo;
        MaxAmmoChanged?.Invoke(maxAmmo);
        _inputManager.LeftClick += OnFire;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ReloadTimeChanged?.Invoke(reloadTime);
        ReloadStatusChanged?.Invoke(0f);
        MaxAmmoChanged?.Invoke(maxAmmo);
        CurrentAmmoChanged?.Invoke(_currentAmmo);
        WeaponIconUpdate?.Invoke(weaponIndex);

        if (_isReload) { Reload(); }
    }

    private void Update()
    {
        if (_isReload)
        {
            Reloading();
        }
    }

    private void OnDestroy()
    {
        _inputManager.LeftClick -= OnFire;
    }

    abstract public void SetupProperties();

    public void OnFire()
    {
        if (Time.time >= _timeToFire && !_isReload)
        {
            Firing();
        }
    }

    private void Shoot(int numberOfShot)
    {
        for (int i = 1; i <= numberOfShot; i++)
        {
            var spray = Quaternion.Euler(0f, Random.Range(-sprayAngle, sprayAngle), 0f);
            Quaternion fireDirection = _firePoint.rotation * spray;

            var projectile = _resourcesManger.GetPooledObject<Projectiles, Projectile>(projectileName);

            projectile.transform.position = _firePoint.position;
            projectile.transform.rotation = fireDirection;
            projectile.transform.SetParent(_projectileHolder);
            projectile.SetActive(true);
        }

        _soundManager.PlayEffect(sound);

        _timeToFire = Time.time + 60f / rateOfFire;
        _currentAmmo--;
        CurrentAmmoChanged?.Invoke(_currentAmmo);
    }
    private void Reload()
    {
        _isReload = true;
        _timeToFire = Time.time + reloadTime;
    }

    private void Firing()
    {
        if (_currentAmmo != 0) { Shoot(numberOfShot); }
        else { Reload(); }
    }

    private void Reloading()
    {
        ReloadStatusChanged?.Invoke(reloadTime - (_timeToFire - Time.time));

        if (Time.time >= _timeToFire)
        {
            ReloadStatusChanged?.Invoke(0f);
            _currentAmmo = maxAmmo;
            CurrentAmmoChanged?.Invoke(_currentAmmo);
            _isReload = false;
        }
    }
}
