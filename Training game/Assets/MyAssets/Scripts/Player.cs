using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform Target;
    public HealthBar HealthBar;

    public float moveSpeed = 5.0f;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    private Rigidbody _rb;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        HealthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene("SampleScene");
    }

}
