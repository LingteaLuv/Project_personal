using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private PlayerItemInventory _itemInventory;
    
    private bool _hasLantern;
    public bool HasLantern => _hasLantern;
    
    private bool _hasCompass;
    public bool HasCompass => _hasCompass;
    
    private bool _hasBackpack;
    public bool HasBackpack => _hasBackpack;
    
    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void GetItem(Item item)
    {
        _itemInventory.AddItem(item);
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
        // todo : 테스트 용 값이니까 나중에 바꿔야함
        _hasLantern = true;
        _hasCompass = true;
        _hasBackpack = true;
    }
}
