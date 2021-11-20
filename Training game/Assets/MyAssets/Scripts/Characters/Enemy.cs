using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar HealthBar;
    public Billboard Billboard;
    public EnemyCharacteristic EnemyCharacteristic;

    private ISoundManager _soundManager;
    private ICharacteristicControl _enemyCharacteristic;
    private Rigidbody _rb;
    private Transform _target;
    private Transform _cam;

    private float _maxHealth;
    private float _currentHealth;
    private float _moveSpeed;
    private float _meleeDamage;

    private float _attackSpeed = 2f;
    private float _timeToAttack = 0f;

    public Transform Target { set => _target = value; }
    public Transform Cam
    {
        set
        {
            _cam = value;
            Billboard.Cam = _cam;
        }
    }

    private void Awake()
    {
        _soundManager = ServiceLocator.GetSoundManagerStatic();

        _rb = GetComponent<Rigidbody>();
        _enemyCharacteristic = EnemyCharacteristic;
    }

    private void OnEnable()
    {
        _rb.isKinematic = true;
        _rb.useGravity = false;
        transform.rotation = Quaternion.identity;

        StartCoroutine(Mumble());
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

        var sound = Sounds.ZombieDamage_1;
        if (Random.value < 0.5f)
        {
            sound = Sounds.ZombieDamage_2;
        }
        _soundManager.PlayEffect(sound);


        HealthBar.SetHP(_currentHealth);
        if (_currentHealth <= 0f)
        {
            StartCoroutine(Die());
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

    private IEnumerator Die()
    {
        _target = null;
        _rb.isKinematic = false;
        _rb.useGravity = true;
        _soundManager.PlayEffect(Sounds.ZombieDeth_1);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    private IEnumerator Mumble()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            var sound = Sounds.ZombieMoving_1;
            if (Random.value < 0.5f)
            {
                sound = Sounds.ZombieMoving_2;
            }
            _soundManager.PlayEffect(sound);

        }
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
