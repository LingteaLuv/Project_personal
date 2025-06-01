using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField] [Range(1,10)] private float _rotateSpeed;

    private float _curRotationX;
    private float _curRotationY;
    
    private bool _curState;
    private Vector3 _idlePos;
    private Vector3 _hidePos;

    private void Awake()
    {
        Init();
    }
    
    private void LateUpdate()
    {
        MouseInput();
        CameraRotate();
    }

    public void ChangePos(bool isHide)
    {
        if (_curState != isHide)
        {
            _curState = isHide;
            float offset = _curState ? 0.6f : -0.6f;
            transform.localPosition += Vector3.down * offset;
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Wall"))
        {
            transform.localPosition += other.contacts[0].normal * 1f;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if(other.transform.CompareTag("Wall"))
        {
            transform.localPosition -= other.contacts[0].normal * 1f;
        }
    }*/

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
        Quaternion targetRot = Quaternion.Euler(_curRotationX * -1, _curRotationY, 0);
        if (_curState)
        {
            targetRot = Quaternion.Euler(targetRot.eulerAngles + Vector3.right * -20);
        }
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.5f);

        if (Quaternion.Angle(targetRot, transform.rotation) < 0.1f)
        {
            transform.rotation = targetRot;
        }
    }

    private void Init()
    {
        _curState = false;
        _idlePos = new Vector3(0, 0.5f, 0);
        _hidePos = new Vector3(0, -0.1f, 0);
    }
}
