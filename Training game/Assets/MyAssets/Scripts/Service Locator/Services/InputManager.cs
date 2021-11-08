using System;
using UnityEngine;


public class InputManager : MonoBehaviour, IInputManager
{
    public event Action LeftClick;
    public event Action<Vector2> Move;
    public event Action<Vector2> Look;
    public event Action<int> AlphaSelect;
    public event Action Pause;

    private void Update()
    {
        CheckLeftClickInput();
        CheckMoveInput();
        CheckLookInput();
        CheckAlphaSelectInput();
        CheckPauseInput();
    }

    private void CheckPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void CheckLeftClickInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftClick();            
        }
    }

    private void CheckMoveInput()
    {
        Vector2 moveVector = Vector2.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        Move(moveVector.normalized);

    }

    private void CheckLookInput()
    {
        Look(Input.mousePosition);
    }

    private void CheckAlphaSelectInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { AlphaSelect(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { AlphaSelect(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { AlphaSelect(2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { AlphaSelect(3); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { AlphaSelect(4); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { AlphaSelect(5); }
    }
}
