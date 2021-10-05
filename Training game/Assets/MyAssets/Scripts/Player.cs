using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private Rigidbody _rb;
    private Transform _target;
    private HealthBar _healthBar;
    private InputControls _gameplayControls;
    private Transform _weaponHolder;

    private float _horizontal;
    private float _vertical;
    private List<GameObject> _weaponList;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _weaponList = new List<GameObject>();
        _healthBar.SetMaxHealth(maxHealth);

        _gameplayControls.Move += OnMove;
        _gameplayControls.SelectWeapon += OnSelectWeapon;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void AddWeapon(GameObject Weapon)
    {
        var weapon = Instantiate(Weapon, transform.position, Quaternion.identity, _weaponHolder);
        weapon.SetActive(false);
        _weaponList.Add(weapon);
        Debug.Log("Set");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0f)
        {
            GameOver();
        }
    }

    public void SetTarget(Transform target)
    {

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
        Debug.Log("GameOver");
        SceneManager.LoadScene("SampleScene");
    }

}
