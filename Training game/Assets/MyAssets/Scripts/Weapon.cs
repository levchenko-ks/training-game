using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Projectiles;
    public ReloadBar ReloadBar;
    public AmmoCounter AmmoCounter;
    public Transform _firePoint;

    public int numberOfShot = 1;
    public int maxAmmo = 15;
    public float rateOfFire = 10f; // per minute    
    public float reloadTime = 3f;
    public float sprayAngle = 1f; // per side
        
    InputControls gameplayControls;

    private bool _fire;
    private bool _reload;
    private int _currentAmmo;
    private float _timeToFire = 0f;


    private void Awake()
    {
       gameplayControls.Fire += OnFire;

        _currentAmmo = maxAmmo;
        AmmoCounter.SetCounter(_currentAmmo);

    }

    private void OnEnable()
    {
        ReloadBar.SetReloadTime(reloadTime);
        ReloadBar.SetCurrentStatus(0f);

    }

    private void FixedUpdate()
    {
        if (_fire && Time.time >= _timeToFire)
        {
            if (_currentAmmo != 0) { Shoot(numberOfShot); }
            else { Reload(); }
        }

        if (_reload)
        {
            ReloadBar.SetCurrentStatus(reloadTime - (_timeToFire - Time.time));

            if (Time.time >= _timeToFire)
            {
                ReloadBar.SetCurrentStatus(0);
                AmmoCounter.SetCounter(_currentAmmo);
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

            UnityEngine.GameObject bullet = Instantiate(Projectile, _firePoint.position, fireDirection, Projectiles.transform);
            Destroy(bullet, 2f);
        }

        _timeToFire = Time.time + 60f / rateOfFire;
        _currentAmmo--;
        AmmoCounter.SetCounter(_currentAmmo);
    }
    private void Reload()
    {
        _reload = true;

        _timeToFire = Time.time + reloadTime;
        _currentAmmo = maxAmmo;
    }
}