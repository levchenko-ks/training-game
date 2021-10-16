using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar HealthBar;
    public Billboard Billboard;

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float moveSpeed = 2f;

    private Rigidbody _rb;
    private Transform _target;
    private Transform _cam;

    private float _damage = 25f;
    private float _attackSpeed = 2f;
    private float _timeToAttack = 0f;

    public Transform Target { get => _target; set => _target = value; }
    public Transform Cam
    {
        get => _cam;
        set
        {
            _cam = value;
            Billboard.Cam = _cam;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        HealthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Moving();
    }
    private void OnTriggerStay(Collider other)
    {
        DoDamage(other);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.SetCurrentHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    private void Moving()
    {
        Vector3 moveDirection = _target.position - transform.position;
        Vector3 newPosition = transform.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        _rb.MoveRotation(newRotation);
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
