using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public float damage = 20f;

    private Rigidbody _rb;

    private ISoundManager _soundManager;


   private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _soundManager = ServiceLocator.GetSoundManagerStatic();
    }

    private void OnEnable()
    {
        StartCoroutine(SelfDestroy());
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            _soundManager.PlayEffect(Sounds.Bulletimpact);
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        var newpos = transform.position + transform.forward * speed * Time.fixedDeltaTime;
        _rb.MovePosition(newpos);
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}

