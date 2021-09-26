using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 2f;

    private Rigidbody rb;
    private Transform PlayerPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        Moving();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Moving()
    {
        Vector3 moveDirection = PlayerPosition.position - transform.position;
        Vector3 newPosition = transform.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = PlayerPosition.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        rb.MovePosition(newPosition);
        rb.MoveRotation(newRotation);

    }
}
