using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<float> ReloadTimeChanged;
    public event Action<float> ReloadStatusChanged;
    public event Action<int> MaxAmmoChanged;
    public event Action<int> CurrentAmmoChanged;
    public event Action<int> WeaponIconUpdate;

    public Transform _firePoint;

    protected ICharacteristicControl _weaponCharacteristic;
    protected IObjectPooler _objectPooler;
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
    private IGameHUD _gameHUD;

    private bool _isFire;
    private bool _isReload;
    private int _currentAmmo;
    private float _timeToFire = 0f;

    public InputControls InputControls
    {
        _inputManager = ServiceLocator.GetInputManagerStatic();
        _weaponCharacteristic = ServiceLocator.GetPlayerStatic().GetComponent<PlayerCharacteristics>();
        _objectPooler = ServiceLocator.GetObjectPoolerStatic();
        _soundManager = ServiceLocator.GetSoundManagerStatic();

    }
    public Transform ProjectileHolder { get => _projectileHolder; set => _projectileHolder = value; }

    public IGameHUD GameHUD { get => _gameHUD; set => _gameHUD = value; }


    private void Awake()
    {
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

        if (_gameHUD == null)
        {
            return;
        }

        _gameHUD.SetReloadTime(reloadTime);
        _gameHUD.SetMaxAmmo(maxAmmo);
        _gameHUD.SetAmmo(_currentAmmo);
        _gameHUD.SetReloadStatus(0f);  
        
        if(_isReload) { Reload(); }
    }

    private void FixedUpdate()
    {
        if (_isFire && Time.time >= _timeToFire && !_isReload)
        {
            Firing();
        }

        if (_isReload)
        {
            Reloading();
        }
    }

    abstract public void SetupProperties();

    public void OnFire()
    {
        _isFire = true;
    }

    private void Shoot(int numberOfShot)
    {
        for (int i = 1; i <= numberOfShot; i++)
        {
            var spray = Quaternion.Euler(0f, Random.Range(-sprayAngle, sprayAngle), 0f);
            Quaternion fireDirection = _firePoint.rotation * spray;

            var projectile = _objectPooler.GetObject<Projectiles, Projectile>(projectileName);

            projectile.SetActive(true);
            projectile.transform.position = _firePoint.position;
            projectile.transform.rotation = fireDirection;
            projectile.transform.SetParent(_projectileHolder);
        }

        _soundManager.PlaySound(sound);

        _timeToFire = Time.time + 60f / rateOfFire;
        _currentAmmo--;
        _gameHUD.SetAmmo(_currentAmmo);
    }
    private void Reload()
    {
        _isReload = true;
        _timeToFire = Time.time + reloadTime;
    }

    private void Firing()
    {
        _isFire = false;

        if (_currentAmmo != 0) { Shoot(numberOfShot); }
        else { Reload(); }        
    }

    private void Reloading()
    {
        _gameHUD.SetReloadStatus(reloadTime - (_timeToFire - Time.time));

        if (Time.time >= _timeToFire)
        {
            _gameHUD.SetReloadStatus(0f);
            _currentAmmo = maxAmmo;
            _gameHUD.SetAmmo(_currentAmmo);
            _isReload = false;
        }
    }
}
