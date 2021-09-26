using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody rb;

    private float _speed = 30f;
    private float _damage = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var newpos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;

        rb.MovePosition(newpos);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}

