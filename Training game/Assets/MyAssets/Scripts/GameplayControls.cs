using System;
using UnityEngine;


public class GameplayControls : MonoBehaviour
{
    public event Action Fire;
    public event Action<Vector2> Move;
    public event Action<Vector2> Look;
    public event Action<int> SelectWeapon;

    private void Update()
    {
        OnFireInput();
        OnMoveInput();
        OnLookInput();
        OnWeaponChoiceInput();
    }

    private void OnFireInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void OnMoveInput()
    {
        Vector2 moveVector = Vector2.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        Move(moveVector.normalized);

    }

    private void OnLookInput()
    {
        Look(Input.mousePosition);
    }

    private void OnWeaponChoiceInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectWeapon(1); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectWeapon(2); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SelectWeapon(3); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { SelectWeapon(4); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { SelectWeapon(5); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { SelectWeapon(6); }
    }
}
