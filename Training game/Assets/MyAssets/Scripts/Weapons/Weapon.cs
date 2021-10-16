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
    private ReloadBar _reloadBar;
    private AmmoCounter _ammoCounter;

    private bool _fire;
    private bool _reload;
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
    public ReloadBar ReloadBar { get => _reloadBar; set => _reloadBar = value; }
    public AmmoCounter AmmoCounter
    {
        get => _ammoCounter;
        set
        {
            _ammoCounter = value;
            _ammoCounter.SetCounter(_currentAmmo);
        }
    }

    private void Awake()
    {
        _currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        if (_reloadBar == null)
        {
            return;
        }
        _reloadBar.SetReloadTime(reloadTime);
        _reloadBar.SetCurrentStatus(0f);

    }

    private void FixedUpdate()
    {
        if (_fire && Time.time >= _timeToFire)
        {
            if (_currentAmmo != 0) { Shoot(numberOfShot); }
            else { Reload(); }

            _fire = false;
        }

        if (_reload)
        {
            _reloadBar.SetCurrentStatus(reloadTime - (_timeToFire - Time.time));

            if (Time.time >= _timeToFire)
            {
                _reloadBar.SetCurrentStatus(0);
                _ammoCounter.SetCounter(_currentAmmo);
                _reload = false;
            }
        }
    }

    public void OnFire()
    {
        _fire = true;
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
        _ammoCounter.SetCounter(_currentAmmo);
    }
    private void Reload()
    {
        _reload = true;

        _timeToFire = Time.time + reloadTime;
        _currentAmmo = maxAmmo;
    }
}
