using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar HealthBar;
    public Billboard Billboard;
    public EnemyCharacteristic EnemyCharacteristic;

    private Rigidbody _rb;
    private Transform _target;
    private Transform _cam;
    private ICharacteristicControl _enemyCharacteristic;

    private float _maxHealth;
    private float _currentHealth;
    private float _moveSpeed;
    private float _meleeDamage;

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
        _enemyCharacteristic = EnemyCharacteristic;
    }

    private void Start()
    {
        CalculateMyCharacteristic();
        HealthBar.SetMaxHP(_maxHealth);
        _currentHealth = _maxHealth;
        HealthBar.SetHP(_currentHealth);
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
        _currentHealth -= damage;
        HealthBar.SetHP(_currentHealth);
        if (_currentHealth <= 0f)
        {
            Die();
        }
    }
    private void Moving()
    {
        Vector3 moveDirection = _target.position - transform.position;
        Vector3 newPosition = transform.position + moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime;
        
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
            player.TakeDamage(_meleeDamage);
        }
    }

    private void CalculateMyCharacteristic()
    {
        _maxHealth = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.Health);
        _moveSpeed = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.MoveSpeed);
        _meleeDamage = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.MeleeDamage);        
    }
}
