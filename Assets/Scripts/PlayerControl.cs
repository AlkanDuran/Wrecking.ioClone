using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Vector3;

public class PlayerControl : Input
{
    public int _driveSpeed;
    public int _breakAmount;
    private Vector3 _startPosition;
    private Vector3 _deltaPosition;
    public float _swerveSmoothness;
    public float _swerveSpeed;
    private bool _isLocked;
    
    public float height;
    public bool isGrounded = true;

    public override void Swerve()
    {
        if (!_isLocked)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _startPosition = UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetMouseButton(0))
            {
                _deltaPosition = UnityEngine.Input.mousePosition - _startPosition;

                transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                    Mathf.Lerp(transform.eulerAngles.y,
                        transform.eulerAngles.y + (_deltaPosition.x / Screen.width) * _swerveSpeed,
                        _swerveSmoothness * Time.deltaTime), transform.eulerAngles.z);

                _startPosition = UnityEngine.Input.mousePosition;

                Debug.Log(_deltaPosition.x);
            }
        }
    }

    public override void Drive()
    {
        transform.Translate(forward * (_driveSpeed * Time.deltaTime));
    }

    private void Update()
    {
        Grounded();
        if(!isGrounded) return;
        Drive();
        Swerve();
        RotateAround();
        
    }

    private void RotateAround()
    {
        if (_deltaPosition.x > 50)
        {
            _isLocked = true;
            if (_isLocked)
            {
                if (UnityEngine.Input.GetMouseButton(0))
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 250, transform.rotation.z) * Time.deltaTime);
                    _driveSpeed -= _breakAmount;
                }

                if (UnityEngine.Input.GetMouseButtonUp(0))
                {
                    _deltaPosition = Vector3.zero;
                    _isLocked = false;
                    _driveSpeed += _breakAmount;
                }
            }
        }

        if (_deltaPosition.x < -50)
        {
            _isLocked = true;
            if (_isLocked)
            {
                if (UnityEngine.Input.GetMouseButton(0))
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y - 250, transform.rotation.z) * Time.deltaTime);
                    _driveSpeed -= _breakAmount;
                }

                if (UnityEngine.Input.GetMouseButtonUp(0))
                {
                    _deltaPosition = Vector3.zero;
                    _isLocked = false;
                    _driveSpeed += _breakAmount;
                }
            }
        }
    }
    
    void Grounded()
    {
        if (transform.position.y > height)
        {
            isGrounded = false;
        }

        if (!isGrounded && transform.position.y < height)
        {
            isGrounded = true;
            
        }
    }
}