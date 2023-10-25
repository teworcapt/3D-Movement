using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 movementInput;
    public float verticalInput, horizontalInput, moveAmount;
    public bool sprint_Input,walk_Input;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            //when we hit WASD, it records the movement to a variable
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerAction.Sprint.performed += i => sprint_Input = true;
            playerControls.PlayerAction.Sprint.canceled += i => sprint_Input = false;
            playerControls.PlayerAction.Walk.performed += i => walk_Input = true;
            playerControls.PlayerAction.Walk.canceled += i => walk_Input = false;
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
        HandleMovementInput();
        HandleSprinting();
        HandleWalking();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput+verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleSprinting()
    {
        if (sprint_Input) {
        PlayerManager.Instance.isSprinting = true;
        } else
        {
        PlayerManager.Instance.isSprinting = false;
        }
    }
    private void HandleWalking()
    {
        if (walk_Input)
        {
            PlayerManager.Instance.isWalking = true;
        }
        else
        {
            PlayerManager.Instance.isWalking = false;
        }
    }
}

