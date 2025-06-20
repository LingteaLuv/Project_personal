using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TransferManager : Singleton<TransferManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private PlayerItemInventory _itemInventory;
    [SerializeField] private Crafting _craftNPC;

    private Chest _curChest;
    public Chest CurChest => _curChest;

    public event Action OnArrowAdded;
    

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void ThrowAwayStuff(Stuff stuff)
    {
        _inventory.RemoveStuff(stuff,1);
        Vector3 curPos = _inventory.transform.position + Vector3.down * 1f;
        GameObject stuffInMap = Instantiate(stuff.Prefab, curPos, quaternion.identity);

        Vector3 curMinimapPos = new Vector3(curPos.x / 5, 0, curPos.z / 5);
        GameObject stuffInMinimap = Instantiate(stuff.MinimapPrefab, curMinimapPos, quaternion.identity);
        
        StuffManager.Instance.Add(stuffInMap,stuffInMinimap);
    }
    
    public void GetItem(Item item)
    {
        _itemInventory.AddItem(item);
        if (item.name == "Arrow")
        {
            OnArrowAdded?.Invoke();
        }
    }
    
    public void OpenChest(Chest chest)
    {
        _curChest = chest;
        UIManager.Instance.OpenUI(chest.ChestUI);
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

    public void TransferAllToChest()
    {
        int count = _inventory.Count;
        for (int i = 0; i < count; i++)
        {
            if (_curChest.Volume > _curChest.Count)
            {
                Stuff stuff = _inventory.FindObject(count - i - 1);
                _inventory.RemoveStuff(stuff,1);
                _curChest.AddStuff(stuff);
            }
        }
    }

    public void TransferAllToInventory()
    {
        int count = _curChest.Count;
        for (int i = 0; i < count; i++)
        {
            if (_inventory.MaxCount > _inventory.Count)
            {
                Stuff stuff = _curChest.FindObject(count - i - 1);
                _curChest.RemoveStuff(stuff,1);
                _inventory.AddStuff(stuff);
            }
        }
    }

    public void TransferFromChest(Stuff stuff)
    {
        if (_curChest != null)
        {
            if (_curChest.HasStuff(stuff) && _inventory.Count < _inventory.MaxCount)
            {
                _curChest.RemoveStuff(stuff, 1);
                _inventory.AddStuff(stuff);
            }
        }
    }
    
    public void TransferToNPC(Stuff stuff)
    {
        if (_inventory.HasStuff(stuff) && _craftNPC.CraftStuff.Count < 2)
        {
            _inventory.RemoveStuff(stuff, 1);
            _craftNPC.CraftStuff.Add(stuff);
        }
    }
    
    public void TransferFromNPC(Stuff stuff)
    {
        if (_craftNPC.CraftStuff.Contains(stuff))
        {
            _craftNPC.CraftStuff.Remove(stuff);
            _inventory.AddStuff(stuff);
        }
    }
    
    public void TransferAllToInventoryInNPC()
    {
        int count = _craftNPC.CraftStuff.Count;
        for (int i = 0; i < count; i++)
        {
            if (_inventory.MaxCount > _inventory.Count)
            {
                Stuff stuff =  _craftNPC.FindObject(count - i - 1);
                _craftNPC.RemoveStuff(stuff);
                _inventory.AddStuff(stuff);
            }
        }
    }
    
    private void Init()
    {
        _curChest = null;
    }
}
