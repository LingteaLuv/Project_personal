using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    private bool _hasLantern;
    public bool HasLantern => _hasLantern;
    
    private bool _hasCompass;
    public bool HasCompass => _hasCompass;
    
    private bool _hasBackpack;
    public bool HasBackpack => _hasBackpack;
    
    protected override void Awake()
    {
        base.Awake();
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }
    
    public void GetLantern()
    {
        _hasLantern = true;
    }

    public void GetCompass()
    {
        _hasCompass = true;
    }

    public void GetBackpack()
    {
        _hasBackpack = true;
    }

    private void Init()
    {
        _hasLantern = false;
        _hasCompass = false;
        _hasBackpack = false;
    }
}
