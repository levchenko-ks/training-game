using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Projectiles;

    public float rateOfFire = 10f; // per minute
    public int maxAmmo = 15;
    public float reloadTime = 3f;

    private bool _fire;
    private float _timeToFire = 0f;
    private int _currentAmmo;
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = transform.Find("FirePoint").GetComponent<Transform>();

        _currentAmmo = maxAmmo;

    }

    private void FixedUpdate()
    {
        if (_fire && Time.time >= _timeToFire)
        {
            
            if (_currentAmmo != 0) { Shoot(); }
            else { Reload(); }

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

    }
    private void Reload()
    {
        Debug.Log("Reload");

        _timeToFire = Time.time + reloadTime;
        _currentAmmo = maxAmmo;
    }
}
