using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private SphereCollider _presence;
    
    private IDetectRangeNotify _detectRangeNotify;
    private bool _curState;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _detectRangeNotify.OnDetectRangeChanged += UpdateRangeNotify;
    }

    private void OnDisable()
    {
        _detectRangeNotify.OnDetectRangeChanged -= UpdateRangeNotify;
    }

    public void ChangePresence(bool isHide)
    {
        if (_curState != isHide)
        {
            _curState = isHide;
            UpdateRangeNotify(_detectRangeNotify.DetectRange);
        }
    }

    private void Init()
    {
        _detectRangeNotify = GetComponentInParent<IDetectRangeNotify>();
    }

    private void UpdateRangeNotify(float range)
    {
        _presence.radius = _curState ? 0.3f * range : range;
    }
    
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, _presence.radius);
    }
}
