using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    PlayerController playerController;

    InputSystemActions inputs;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputs = new InputSystemActions();
        playerController = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += Movimiento;
        inputs.Player.Move.canceled += Movimiento;
        inputs.Player.Interact.performed += Interact;
        inputs.Player.Bark.performed += Bark;
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    void Movimiento(InputAction.CallbackContext context)
    {
        playerController.MoveInput(context.ReadValue<Vector2>());
    }

    void Interact(InputAction.CallbackContext context)
    {
        playerController.Interact();
    }
    
    void Bark(InputAction.CallbackContext context)
    {
        playerController.Bark();
    }
    
    
}