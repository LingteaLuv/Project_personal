using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : WearingItem
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
        _modifier = new StatModifier() { MentalityDecreaseChange = -0.5f };
        _handler = transform.root.GetComponent<IPlayerStatHandler>();
    }
}
