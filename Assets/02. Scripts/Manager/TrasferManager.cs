using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferManager : Singleton<TransferManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private GameObject _chestUI;

    private Chest _curChest;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void OpenChest(Chest chest)
    {
        _curChest = chest;
        UIManager.Instance.OpenUI(_chestUI);
    }

    public void CloseChest()
    {
        _curChest = null;
        UIManager.Instance.CloseUI();
    }
    
    public void TransferToChest(Stuff stuff)
    {
        if (_curChest != null)
        {
            if (_inventory.HasStuff(stuff))
            {
                _inventory.RemoveStuff(stuff, 1);
                _curChest.AddStuff(stuff);
            }
        }
    }

    public void TransferFromChest(Stuff stuff)
    {
        if (_curChest != null)
        {
            if (_curChest.HasStuff(stuff))
            {
                _curChest.RemoveStuff(stuff, 1);
                _inventory.AddStuff(stuff);
            }
        }
    }
    
    private void Init()
    {
        _curChest = null;
    }
}
