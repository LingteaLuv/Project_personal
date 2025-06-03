using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : WearingItem
{
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Activate();
    }
    
    private void Init()
    {
        _modifier = new StatModifier() { SpeedChange = 2f };
        _handler = transform.root.GetComponent<IPlayerStatHandler>();
    }
}
