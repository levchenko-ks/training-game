using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class MoveInputIvent : UnityEvent<float, float> { }

public class GameplayControls : MonoBehaviour
{
    ActionAssetControls controls;

    public MoveInputIvent moveInputIvent;

    private void Awake()
    {
        controls = new ActionAssetControls();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable(); // Enable Action Map
        controls.Gameplay.Moving.performed += MoveInput;
        controls.Gameplay.Moving.canceled += MoveInput;
    }

    private void MoveInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 moveInput = obj.ReadValue<Vector2>();
        moveInputIvent.Invoke(moveInput.x, moveInput.y);        
    }
}
