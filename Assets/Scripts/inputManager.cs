using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (playerControls != null)
        {
            playerControls = new PlayerControls();
            //when we hit WASD, it records the movement to a variable
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        if (playerControls != null)
        {
            playerControls.Disable();
        }
    }

    public void HandleAllInput()
    {
        HandleAllInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}

