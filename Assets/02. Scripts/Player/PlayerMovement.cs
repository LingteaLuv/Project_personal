using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private Camera _playerFollowCam;
    
    [Header("InputNumber")]
    [SerializeField] [Range(0,10)] private float _moveSpeed;
    [SerializeField] [Range(0,10)] private float _acceleration;
    [SerializeField] [Range(5,20)] private float _deceleration;
    [SerializeField] [Range(0,100)] private float _rotateInertia;
    
    private Rigidbody _rigid;
    

    private void Awake()
    {
        Init();
    }

    public void MoveUpdate(Vector3 inputDir)
    {
        if (inputDir != Vector3.zero)
        {
            Vector3 camForward = _playerFollowCam.transform.forward;
            Vector3 camRight = _playerFollowCam.transform.right;

            Vector3 moveDir = camForward * inputDir.z + camRight * inputDir.x;
            Vector3 targetV = moveDir * _moveSpeed;

            _rigid.velocity = Vector3.Lerp(_rigid.velocity, targetV, _acceleration * Time.fixedDeltaTime);
        }
        else
        {
            _rigid.velocity = Vector3.MoveTowards(_rigid.velocity, Vector3.zero, _deceleration * Time.fixedDeltaTime);
        }
    }

    public void RotateUpdate()
    {
        Vector3 targetEuler = _playerFollowCam.transform.rotation.eulerAngles;
        Quaternion targetRot = Quaternion.Euler(0, targetEuler.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * _rotateInertia);
    }

    private void Init()
    {
        _rigid = GetComponent<Rigidbody>();
    }
}
