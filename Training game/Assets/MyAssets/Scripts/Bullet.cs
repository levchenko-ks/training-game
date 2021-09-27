using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 30f;
    public float _damage = 20f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
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

    private void Move()
    {
        var newpos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(newpos);
    }
}

