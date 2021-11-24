using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public event Action<IEnemy> Died;

    public Billboard Billboard;
    public HealthBar HealthBar;
        
    protected Transform _target;
    protected Transform _cam;

    protected float _maxHealth;
    protected float _currentHealth;
    protected float _moveSpeed;    

    public Transform Target { set => _target = value; }
    public Transform Cam
    {
        set
        {
            _cam = value;
            Billboard.Cam = _cam;
        }
    }

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
