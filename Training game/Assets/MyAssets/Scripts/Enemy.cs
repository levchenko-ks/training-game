using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float moveSpeed = 2f;

    private Rigidbody _rb;
    private Transform _playerPosition;
    private HealthBar _healthBar;

    private float _damage = 25f;
    private float _attackSpeed = 2f;
    private float _timeToAttack = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        _healthBar = transform.Find("Canvas").Find("Health Bar").GetComponent<HealthBar>();

        _healthBar.SetMaxHealth(maxHealth);

    }

    private void FixedUpdate()
    {
        Moving();
    }
    private void OnTriggerStay(Collider other)
    {
        DoDamage(other);
    }
    private void Moving()
    {
        Vector3 moveDirection = _playerPosition.position - transform.position;
        Vector3 newPosition = transform.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _playerPosition.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        _rb.MoveRotation(newRotation);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _healthBar.SetCurrentHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void DoDamage(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && Time.time >= _timeToAttack)
        {
            _timeToAttack = Time.time + 1f / _attackSpeed;
            player.TakeDamage(_damage);
        }
    }
}
