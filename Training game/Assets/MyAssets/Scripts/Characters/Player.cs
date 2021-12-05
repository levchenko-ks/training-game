using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IPlayer
{
    public event Action<IPlayer> PlayerDied;
    public event Action<float> CurrentHPChanged;
    public event Action<float> MaxHPChanged;
    public event Action<CharacteristicsNames, float> CharacteristicChanged;
    public event Action<IWeapon> WeaponAdded;
    public event Action<EnvironmentComponents> ObjectFinded;

    public Transform weaponHolder;

    private Rigidbody _rb;
    private IMovable _target;
    private IInputManager _inputManager;
    private IResourcesManager _resourcesManager;
    private ICharacteristicControl _playerCharacteristic;
    private ISoundManager _soundManager;

    private float _maxHealth;
    private float _moveSpeed;
    private float _maxStamina;

    private float _currentHealth;
    private float _stamina;
    private float _horizontal;
    private float _vertical;
    private List<IWeapon> _weaponList;
    private List<Characteristic> _characteristicsList;

    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;
    public Vector3 Forward => transform.forward;

    private void Awake()
    {
        _inputManager = ServiceLocator.GetInputManager();
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _soundManager = ServiceLocator.GetSoundManager();

        _rb = GetComponent<Rigidbody>();
        _playerCharacteristic = GetComponent<PlayerCharacteristics>();
        var target = _resourcesManager.GetInstance<Characters, Target>(Characters.Target);
        _target = target;

        _inputManager.Move += OnMove;
        _inputManager.AlphaSelect += SelectWeapon;

        _weaponList = new List<IWeapon>();
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

    private void OnDestroy()
    {
        _inputManager.Move -= OnMove;
        _inputManager.AlphaSelect -= SelectWeapon;
    }

    public void AddWeapon(Weapons weapon)
    {
        IWeapon weaponInstance = _resourcesManager.GetInstance<Weapons, BaseWeapon>(weapon);

        _weaponList.Add(weaponInstance);
        weaponInstance.SetHolder(weaponHolder);
        weaponInstance.SetWeaponCharacterisctics(_playerCharacteristic);
        WeaponAdded?.Invoke(weaponInstance);
    }

    public void CollectBonus(CharacteristicsNames name, Modifier modifier)
    {
        _playerCharacteristic.AddModifier(name, modifier);
        CalculateMyCharacteristic();
        UpdateHUD();
        _soundManager.PlayEffect(Sounds.Bonus);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CurrentHPChanged?.Invoke(_currentHealth);
        PlayDamagingSound();

        if (_currentHealth <= 0f)
        {
            Diyng();
        }
    }

    public void TakeHeal(float heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0f, _maxHealth);
        UpdateHUD();
    }

    public void FindObject(EnvironmentComponents obj)
    {
        ObjectFinded?.Invoke(obj);
        _soundManager.PlayEffect(Sounds.Bonus);
    }

    private void OnMove(Vector2 obj)
    {
        _horizontal = obj.x;
        _vertical = obj.y;
    }

    private void SelectWeapon(int index)
    {
        bool weaponExist = false;

        foreach (IWeapon weapon in _weaponList)
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

        foreach (IWeapon weapon in _weaponList)
        {
            if (weapon.WeaponIndex == index)
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }

    private void Moving()
    {
        Vector3 moveDirection = Vector3.right * _horizontal + Vector3.forward * _vertical;
        Vector3 newPosition = transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _target.Position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        if (lookDirection != null)
        {
            _rb.MoveRotation(newRotation);
        }
    }

    private void CalculateMyCharacteristic()
    {
        _maxHealth = _playerCharacteristic.CalculateAmount(CharacteristicsNames.Health);
        _moveSpeed = _playerCharacteristic.CalculateAmount(CharacteristicsNames.MoveSpeed);
        _maxStamina = _playerCharacteristic.CalculateAmount(CharacteristicsNames.Stamina);
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
    private void PlayDamagingSound()
    {
        Sounds sound = Sounds.Player_Damage_1;
        var value = Random.value;
        if (value < 0.25f) { sound = Sounds.Player_Damage_2; }
        else if (value < 0.5f) { sound = Sounds.Player_Damage_3; }
        else if (value < 0.75f) { sound = Sounds.Player_Damage_4; }

        _soundManager.PlayEffect(sound);
    }

    private void Diyng()
    {
        Debug.Log("Player Died");

        _soundManager.PlayEffect(Sounds.PlayerDeth);

        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}
