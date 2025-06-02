using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private SphereCollider _presence;
    
    private PlayerProperty _property;
    
    public void GetProperty(PlayerProperty property)
    {
        _property = property;
    }

    private void Start()
    {
        _property.Speed.OnChanged += UpdatePresence;
    }

    private void OnDisable()
    {
        _property.Speed.OnChanged -= UpdatePresence;
    }

    private void UpdatePresence(float range)
    {
        _presence.radius = range;
    }
}
