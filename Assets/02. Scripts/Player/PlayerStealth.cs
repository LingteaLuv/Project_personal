using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private SphereCollider _presence;

    [Header("InputNumber")] 
    [SerializeField][Range(1,5)] private float _range;
    public float Range => _range;

    private bool _curState;
    
    private void Awake()
    {
        Init();
    }

    public void ChangePresence(bool isHide)
    {
        if (_curState != isHide)
        {
            _presence.radius = isHide ? 0.3f * _range : _range;
            _curState = isHide;
        }
    }

    private void Init()
    {
        _presence.radius = _range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _presence.radius);
    }
}
