using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    private bool _hasLantern;
    public bool HasLantern => _hasLantern;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    
    public void GetLantern()
    {
        _hasLantern = true;
    }

    private void Init()
    {
        _hasLantern = true;
    }
}
