using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action PlayerDied;
    public event Action<float> CurrentHPChanged;
    public event Action<float> MaxHPChanged;
    public event Action<CharacteristicsNames, float> CharacteristicChanged;
    public event Action<Weapon> WeaponAdded;

    public Transform weaponHolder;

    private Rigidbody _rb;
    private Transform _target;
    private IInputManager _inputManager;
    private IResourcesManager _resourcesManager;
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


    private void Awake()
    {
        _inputManager = ServiceLocator.GetInputManagerStatic();
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();

        _rb = GetComponent<Rigidbody>();
        _playerCharacteristic = GetComponent<PlayerCharacteristics>();        
        _target = _resourcesManager.GetInstance<Characters, Target>(Characters.Target).transform;
        _weaponList = new List<Weapon>();        

        _inputManager.Move += OnMove;
        _inputManager.AlphaSelect += SelectWeapon;

        _characteristicsList = _playerCharacteristic.CharacteristicsList;

    }

    private void Start()
    {
        CalculateMyCharacteristic();
        _currentHealth = _maxHealth;
        UpdateHUD();
        SelectWeapon(0);
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void AddWeapon(Weapons weapon)
    {
        var weaponInstance = _resourcesManager.GetInstance<Weapons, Weapon>(weapon);

        weaponInstance.transform.SetParent(weaponHolder, false);
        _weaponList.Add(weaponInstance);
        WeaponAdded?.Invoke(weaponInstance);

        weaponInstance.gameObject.SetActive(true);
    }

    public void CollectBonus(CharacteristicsNames name, Modifier modifier)
    {
        _playerCharacteristic.AddModifier(name, modifier);
        CalculateMyCharacteristic();
        UpdateHUD();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CurrentHPChanged?.Invoke(_currentHealth);

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

    private void SelectWeapon(int index)
    {
        bool weaponExist = false;

        foreach (Weapon weapon in _weaponList)
        {
            if (weapon.WeaponIndex == index)
            {
                weaponExist = true;
            }
        }

        if (weaponExist == false)
        {
            return;
        }

        foreach (Weapon weapon in _weaponList)
        {
            if (weapon.WeaponIndex == index)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
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
        MaxHPChanged?.Invoke(_maxHealth);
        CurrentHPChanged?.Invoke(_currentHealth);
        foreach (Characteristic characteristic in _characteristicsList)
        {
            CharacteristicChanged?.Invoke(characteristic.Name, characteristic.Value);
        }
    }

    private void GameOver()
    {
        Debug.Log("Player Died");
        PlayerDied();
    }
}
