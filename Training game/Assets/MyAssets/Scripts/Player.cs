using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Transform Target;
    public HealthBar HealthBar;
    public GameplayControls gameplayControls;
    public Transform WeaponHolder;

    // Temporary
    public Weapon AK74;
    public Weapon Benelli;
    // Temporary

    public float moveSpeed = 5.0f;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private Rigidbody _rb;

    private float _horizontal;
    private float _vertical;
    private List<Weapon> _weaponList;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        HealthBar.SetMaxHealth(maxHealth);

        AddWeapon(AK74);
        AddWeapon(Benelli);

        gameplayControls.Move += OnMove;
        gameplayControls.SelectWeapon += OnSelectWeapon;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void AddWeapon(Weapon Weapon)
    {
        _weaponList.Add(Weapon);

        var weapon = Instantiate(Weapon, transform.position, Quaternion.identity, WeaponHolder);
        weapon.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.SetCurrentHealth(currentHealth);

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

        for (int i = 1; i < _weaponList.Count; i++)
        {
            if (i == index)
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

        Vector3 lookDirection = Target.position - transform.position;
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
