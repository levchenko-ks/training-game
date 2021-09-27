using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Projectiles;
    public ReloadBar ReloadBar;
    public AmmoCounter AmmoCounter;

    public float rateOfFire = 10f; // per minute
    public int maxAmmo = 15;
    public float reloadTime = 3f;

    private bool _fire;
    private bool _reload;
    private float _timeToFire = 0f;
    private int _currentAmmo;
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = transform.Find("FirePoint").GetComponent<Transform>();

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

            if (_currentAmmo != 0) { Shoot(); }
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

    public void OnFireInput(bool fire)
    {
        _fire = fire;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(Projectile, _firePoint.position, _firePoint.rotation, Projectiles.transform);
        Destroy(bullet, 2f);

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
