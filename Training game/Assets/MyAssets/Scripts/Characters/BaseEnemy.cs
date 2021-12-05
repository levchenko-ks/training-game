using System;
using System.Collections;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IEnemy
{
    public event Action<IEnemy> Died;

    public Billboard Billboard;
    public HealthBar HealthBar;
        
    protected IMovable _target;    

    protected float _maxHealth;
    protected float _currentHealth;
    protected float _moveSpeed;    

    public IMovable Target { set => _target = value; }
    public IMovable BillboardCam { set => Billboard.Cam = value; }

    private void Start()
    {
        CalculateMyCharacteristic();

        _currentHealth = _maxHealth;
        HealthBar.SetMaxHP(_maxHealth);
        HealthBar.SetHP(_currentHealth);
    }    

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        TakeDamageScream();
        HealthBar.SetHP(_currentHealth);
        if (_currentHealth <= 0f)
        {
            StartCoroutine(Dying());
        }
    }

    protected void DiedNotify(IEnemy enemy)
    {
        Died?.Invoke(enemy);
    }

    protected abstract void TakeDamageScream();

    protected abstract void Moving();

    protected abstract IEnumerator Dying();   
        
    protected abstract void CalculateMyCharacteristic();

}
