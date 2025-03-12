using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private Joystick _joystick;
    private CharacterController _controller;

    public bool JoystickActive = false;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (JoystickActive && _joystick.Direction.sqrMagnitude > 0.001f)
        {
            horizontalInput = _joystick.Horizontal;
            verticalInput = _joystick.Vertical;
        }

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        moveDirection.y -= 9.81f * Time.deltaTime;
        
        _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }
}
