using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable] public class VectorInputIvent : UnityEvent<float, float> { }
[Serializable] public class BoolInputIvent : UnityEvent<bool> { }

public class GameplayControls : MonoBehaviour
{
    ActionAssetControls controls;

    public VectorInputIvent MoveInputIvent;
    public VectorInputIvent LookInputIvent;
    public BoolInputIvent FireInputIvent;

    private void Awake()
    {
        controls = new ActionAssetControls();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable(); // Enable Gameplay Action Map
        controls.Gameplay.Moving.performed += MoveInput;
        controls.Gameplay.Moving.canceled += MoveInput;
        controls.Gameplay.Looking.performed += LookInput;
        controls.Gameplay.Fire.performed += FireInput;
        controls.Gameplay.Fire.canceled += FireInput;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        Vector2 moveInput = obj.ReadValue<Vector2>();
        MoveInputIvent.Invoke(moveInput.x, moveInput.y);
    }

    private void LookInput(InputAction.CallbackContext obj)
    {
        Vector2 lookInput = obj.ReadValue<Vector2>();
        LookInputIvent.Invoke(lookInput.x, lookInput.y);
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        bool fire = obj.ReadValueAsButton();
        FireInputIvent.Invoke(fire);
    }
}
