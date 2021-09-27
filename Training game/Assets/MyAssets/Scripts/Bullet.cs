using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody _rb;

    private float _speed = 30f;
    private float _damage = 20f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var newpos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;

        _rb.MovePosition(newpos);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}

