using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zombie : BaseEnemy, IEnemy
{
    private Rigidbody _rb;
    private ICharacteristicControl _enemyCharacteristic;

    private float _meleeDamage;
    protected ISoundManager _soundManager;

    private readonly float _attackSpeed = 2f;
    private float _timeToAttack = 0f;


    private void Awake()
    {
        _soundManager = ServiceLocator.GetSoundManager();

        _rb = GetComponent<Rigidbody>();
        _enemyCharacteristic = GetComponent<EnemyCharacteristic>();        
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Moving();
    }

    private void OnEnable()
    {
        _rb.isKinematic = true;
        _rb.useGravity = false;
        transform.rotation = Quaternion.identity;

        _currentHealth = _maxHealth;

        StartCoroutine(Mumble());
    }

    private void OnTriggerStay(Collider other)
    {
        DoDamage(other);
    }

    protected override void CalculateMyCharacteristic()
    {
        _maxHealth = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.Health);
        _moveSpeed = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.MoveSpeed);
        _meleeDamage = _enemyCharacteristic.CalculateAmount(CharacteristicsNames.MeleeDamage);
    }

    protected override void TakeDamageScream()
    {
        var sound = Sounds.ZombieDamage_1;
        if (Random.value < 0.5f)
        {
            sound = Sounds.ZombieDamage_2;
        }
        _soundManager.PlayEffect(sound);
    }

    protected override void Moving()
    {
        Vector3 moveDirection = _target.Position - transform.position;
        Vector3 newPosition = transform.position + moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _target.Position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        _rb.MoveRotation(newRotation);
    }

    protected override IEnumerator Dying()
    {
        StopCoroutine(Mumble());

        _target = null;
        _rb.isKinematic = false;
        _rb.useGravity = true;
        _soundManager.PlayEffect(Sounds.ZombieDeth_1);
        yield return new WaitForSeconds(1.5f);
        DiedNotify(this);
        gameObject.SetActive(false);
    }

    private void DoDamage(Collider other)
    {
        var player = other.GetComponent<IPlayer>();
        if (player != null && Time.time >= _timeToAttack)
        {
            _timeToAttack = Time.time + 1f / _attackSpeed;
            player.TakeDamage(_meleeDamage);
        }
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
}
