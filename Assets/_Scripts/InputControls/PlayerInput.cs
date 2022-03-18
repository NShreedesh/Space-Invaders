using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputControl InputControl { get; private set; }

    [Header("Movement Input Controls")]
    private float _movementInput;
    public float MovementInput => _movementInput;

    private void Awake()
    {
        InputControl = new InputControl();
    }

    private void OnEnable()
    {
        InputControl.Player.Enable();

        InputControl.Player.Movement.started += _ctx => _movementInput = _ctx.ReadValue<float>(); 
        InputControl.Player.Movement.canceled += _ctx => _movementInput = _ctx.ReadValue<float>();
    }


    private void OnDisable()
    {
        InputControl.Player.Disable();
    }
}
