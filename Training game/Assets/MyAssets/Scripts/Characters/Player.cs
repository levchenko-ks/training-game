using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;

    public Transform weaponHolder;
    public ICharacteristicControl playerCharacteristic;    

    private Rigidbody _rb;
    private Transform _target;
    private IGameHUD _gameHUD;
    private InputControls _gameplayControls;

    private float _maxHealth;
    private float _moveSpeed;
    private float _maxStamina;
    private float _reloadSpeed;
    private float _accuracy;
    
    private float _currentHealth;
    private float _stamina;
    private float _horizontal;
    private float _vertical;
    private List<Weapon> _weaponList;

    public Transform Target { set => _target = value; }
    
    public IGameHUD GameHUD
    {
        get => _gameHUD;
        set
        {
            _gameHUD = value;
            _gameHUD.SetMaxHP(_maxHealth);
        }
    }
    

    public InputControls InputControls
    {
        get => _gameplayControls;
        set
        {
            _gameplayControls = value;
            _gameplayControls.Move += OnMove;
            _gameplayControls.SelectWeapon += OnSelectWeapon;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _weaponList = new List<Weapon>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void AddWeapon(Weapon Weapon)
    {
        _weaponList.Add(Weapon);
    }

    public void GetReady()
    {
        CalculateMyCharacteristic();
        OnSelectWeapon(0);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _gameHUD.SetHP(_currentHealth);

        if (_currentHealth <= 0f)
        {
            GameOver();
        }
    }

    private void OnMove(Vector2 obj)
    {
        _horizontal = obj.x;
        _vertical = obj.y;
    }

    private void OnSelectWeapon(int index)
    {
        if (_weaponList.Count <= index)
        {
            return;
        }

        for (int i = 0; i < _weaponList.Count; i++)
        {
            if (i == index)
            {
                _weaponList[i].gameObject.SetActive(true);
                _gameHUD.ShowWeaponIcon(i);
            }
            else
            {
                _weaponList[i].gameObject.SetActive(false);
                _gameHUD.HideWeaponIcon(i);
            }
        }
    }

    private void Moving()
    {
        Vector3 moveDirection = Vector3.right * _horizontal + Vector3.forward * _vertical;
        Vector3 newPosition = transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        _rb.MoveRotation(newRotation);
    }

    private void CalculateMyCharacteristic()
    {
        _maxHealth = playerCharacteristic.CalculateAmount(CharacteristicsNames.Health);
        _moveSpeed = playerCharacteristic.CalculateAmount(CharacteristicsNames.MoveSpeed);
        _maxStamina = playerCharacteristic.CalculateAmount(CharacteristicsNames.Stamina);
        _accuracy = playerCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy);
    }

    private void GameOver()
    {
        Debug.Log("Player Died");
        PlayerDied();
    }

}
