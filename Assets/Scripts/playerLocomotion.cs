using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class PlayerLocomotion : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Transform cameraObject;
    private Vector3 moveDirection;

    private void Awake()
    {
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerManager.Instance.isWalking)
        {
            moveDirection *= PlayerManager.Instance.walkSpeed;
        }
        else
        {
            moveDirection *= PlayerManager.Instance.movementSpeed;
        }

        if (PlayerManager.Instance.isSprinting)
        {
            moveDirection *= PlayerManager.Instance.sprintSpeed;
        }
        else
        {
            moveDirection *= PlayerManager.Instance.movementSpeed;
        }


        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection ==  Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManager.Instance.rotationSpeed);
    }

}
