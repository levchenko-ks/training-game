using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action PlayerDied;

    public Transform weaponHolder;

    public float moveSpeed = 5.0f;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private Rigidbody _rb;
    private Transform _target;
    private IGameHUD _gameHUD;
    private InputControls _gameplayControls;

    private float _horizontal;
    private float _vertical;
    private List<GameObject> _weaponList;

    public Transform Target { get => _target; set => _target = value; }
    
    public IGameHUD GameHUD
    {
        get => _gameHUD;
        set
        {
            _gameHUD = value;
            _gameHUD.SetMaxHP(maxHealth);
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
        _weaponList = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void AddWeapon(GameObject Weapon)
    {
        _weaponList.Add(Weapon);
    }

    public void GetReady()
    {
        OnSelectWeapon(1);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _gameHUD.SetHP(currentHealth);

        if (currentHealth <= 0f)
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
        if (_weaponList.Count < index)
        {
            return;
        }

        for (int i = 0; i < _weaponList.Count; i++)
        {
            if (i + 1 == index) // +1, because count from 0
            {
                _weaponList[i].SetActive(true);
            }
            else
            {
                _weaponList[i].SetActive(false);
            }
        }
    }

    private void Moving()
    {
        Vector3 moveDirection = Vector3.right * _horizontal + Vector3.forward * _vertical;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        _rb.MovePosition(newPosition);
        _rb.MoveRotation(newRotation);
    }

    private void GameOver()
    {
        Debug.Log("Player Died");
        PlayerDied();
    }

}
