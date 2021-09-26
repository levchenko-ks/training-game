using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform Target;
    public float moveSpeed = 5.0f;

    private Rigidbody rb;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;
    }

    private void Movement()
    {
        Vector3 moveDirection = Vector3.right * _horizontal + Vector3.forward * _vertical;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        Vector3 lookDirection = Target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);

        rb.MovePosition(newPosition);
        rb.MoveRotation(newRotation);
    }

}
