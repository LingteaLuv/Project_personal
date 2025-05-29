using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cape : WearingItem
{
    private void Awake()
    {
        Init();
    }
    
    private void Init()
    {
        _modifier = new StatModifier() { DetectRangeChange = -2f };
        _handler = GetComponent<IPlayerStatHandler>();
    }
}
