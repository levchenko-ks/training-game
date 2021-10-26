using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;

    public Transform weaponHolder;
    public PlayerCharacteristics playerCharacteristic;

    private Rigidbody _rb;
    private Transform _target;
    private IGameHUD _gameHUD;
    private InputControls _gameplayControls;
    private ICharacteristicControl _playerCharacteristic;

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
    private List<Characteristic> _characteristicsList;

    public Transform Target { set => _target = value; }

    public IGameHUD GameHUD
    {
        get => _gameHUD;
        set
        {
            _gameHUD = value;
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
        _playerCharacteristic = playerCharacteristic;
        _characteristicsList = _playerCharacteristic.CharacteristicsList;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(PlayerPrefs.GetFloat(SavesKeys.Health.ToString()));
        }
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
        _currentHealth = _maxHealth;
        UpdateHUD();
        OnSelectWeapon(0);
    }

    public void CollectBonus(CharacteristicsNames name, Modifier modifier)
    {
        _playerCharacteristic.AddModifier(name, modifier);
        CalculateMyCharacteristic();
        UpdateHUD();
        Debug.Log("CollectBonus");
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

    public void TakeHeal(float heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0f, _maxHealth);
        UpdateHUD();
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
        _maxHealth = _playerCharacteristic.CalculateAmount(CharacteristicsNames.Health);
        _moveSpeed = _playerCharacteristic.CalculateAmount(CharacteristicsNames.MoveSpeed);        
        _maxStamina = _playerCharacteristic.CalculateAmount(CharacteristicsNames.Stamina);
        _accuracy = _playerCharacteristic.CalculateAmount(CharacteristicsNames.Accuracy);
    }

    private void UpdateHUD()
    {
        _gameHUD.SetMaxHP(_maxHealth);
        _gameHUD.SetHP(_currentHealth);
        foreach (Characteristic characteristic in _characteristicsList)
        {
            _gameHUD.SetCharacteristic(characteristic.Name, characteristic.Value);
        }        
    }

    private void GameOver()
    {
        Debug.Log("Player Died");
        PlayerDied();
    }

}
