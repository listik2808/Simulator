using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private Joystick joystick;
    private CharacterController controller;

    public bool joystickActive = false;
    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (joystickActive)
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }
        else
        {
           horizontalInput = Input.GetAxis("Horizontal"); 
           verticalInput = Input.GetAxis("Vertical");
        }

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        moveDirection.y -= 9.81f * Time.deltaTime;
        
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
