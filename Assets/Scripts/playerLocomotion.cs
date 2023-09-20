using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class playerLocomotion : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody rigidBody;
    private Transform cameraObject;
    private Vector3 moveDirection;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {

    }

    private void HandleRotation()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
