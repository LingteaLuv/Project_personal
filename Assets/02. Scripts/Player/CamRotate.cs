using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField] [Range(1,10)] private float _rotateSpeed;

    private float _curRotationX;
    private float _curRotationY;
    
    private void Update()
    {
        MouseInput();
        CameraRotate();
    }

    private void MouseInput()
    {
        float rotateX = UnityEngine.Input.GetAxis("Mouse Y");
        float rotateY = UnityEngine.Input.GetAxis("Mouse X");

        _curRotationX += rotateX * _rotateSpeed * 80 * Time.deltaTime;
        _curRotationY += rotateY * _rotateSpeed * 100 * Time.deltaTime;
        
        _curRotationX = Mathf.Clamp(_curRotationX, -60f, 60f);
    }

    private void CameraRotate()
    {
        transform.rotation = Quaternion.Euler(_curRotationX * -1, _curRotationY, 0);
    }
}
