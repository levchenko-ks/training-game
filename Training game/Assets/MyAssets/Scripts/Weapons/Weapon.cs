using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;

    public Transform _firePoint;

    public int numberOfShot = 1;
    public int maxAmmo = 15;
    public float rateOfFire = 10f; // per minute    
    public float reloadTime = 3f;
    public float sprayAngle = 1f; // per side

    private InputControls _gameplayControls;
    private Transform _projectileHolder;
    private IGameHUD _gameHUD;

    private bool _isFire;
    private bool _isReload;
    private int _currentAmmo;
    private float _timeToFire = 0f;

    public InputControls InputControls
    {
        get => _gameplayControls;
        set
        {
            _gameplayControls = value;
            _gameplayControls.Fire += OnFire;
        }

    }
    public Transform ProjectileHolder { get => _projectileHolder; set => _projectileHolder = value; }

    public IGameHUD GameHUD { get => _gameHUD; set => _gameHUD = value; }


    private void Awake()
    {
        _currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        _isFire = false;

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

            GameObject bullet = Instantiate(Projectile, _firePoint.position, fireDirection, _projectileHolder);
            Destroy(bullet, 2f);
        }

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
        if (_currentAmmo != 0) { Shoot(numberOfShot); }
        else { Reload(); }

        _isFire = false;
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
