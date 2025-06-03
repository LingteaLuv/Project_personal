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
        Debug.Log("랜턴 획득");
    }

    public void GetCompass()
    {
        _hasCompass = true;
        Debug.Log("나침반 획득");
    }

    public void GetBackpack()
    {
        _hasBackpack = true;
        Debug.Log("가방 획득");
    }

    private void Init()
    {
        // todo : 테스트 용 값이니까 나중에 바꿔야함
        _hasLantern = false;
        _hasCompass = false;
        _hasBackpack = false;
    }
}
