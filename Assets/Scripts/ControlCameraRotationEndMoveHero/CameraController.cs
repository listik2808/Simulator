using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool JoystickActive = false;

    [SerializeField] private float _sensitivity = 2.0f;
    [SerializeField] private float _sensitivityJoystick = 1;
    [SerializeField] private float _maxYAngle = 80.0f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _offSet = 0.2f;
    private bool _isWork = false;
    private float rotationX = 0.0f;

    public bool IsWork => _isWork;

    public Action<bool> Work;

    private void Update()
    {
        float mouseX = 0;
        float mouseY = 0;
        if (JoystickActive && _joystick.Direction.sqrMagnitude > 0.001f)
        {
            _isWork = true;
            Work?.Invoke(_isWork);
            float joyX = _joystick.Horizontal;
            float joyY = _joystick.Vertical;

            if (Mathf.Abs(joyX) > 0.2f)
            {
                mouseX = joyX * _sensitivityJoystick;
            }

            if (Mathf.Abs(joyY) > 0.2f)
            {
                mouseY = joyY * _sensitivityJoystick;
            }

        }
        else
        {
            _isWork = false;
            Work?.Invoke(_isWork);
        }

        transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

        rotationX -= mouseY * _sensitivity;
        rotationX = Mathf.Clamp(rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
