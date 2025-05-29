using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private IPlayerStatHandler _handler;
    
    private StatModifier _modifier;
    private bool _isActivated;

    private void Awake()
    {
        Init();
    }

    public void Activate()
    {
        if (!_isActivated)
        {
            _handler.ApplyModifier(_modifier);
            _isActivated = true;
        }
    }

    public void Deactivate()
    {
        if (_isActivated)
        {
            _handler.RemoveModifier(_modifier);
            _isActivated = false;
        }
    }
    
    private void Init()
    {
        _modifier = new StatModifier() { SpeedChange = 2f };
    }
}
