using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private StatusUI _statusUI;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private InventoryInChestUI _inventoryInChestUI;
    [SerializeField] private ChestInventoryUI _chestInventoryUI;
    [SerializeField] private ChestUI _chestUI;
    
    public GameObject _curUI;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public ChestUI GetChestUI()
    {
        return _chestUI;
    }
    
    public void OpenUI(GameObject curUI)
    {
        if (curUI != null)
        {
            _curUI = curUI;
            _curUI.gameObject.SetActive(true);
        }
    }

    public void CloseUI()
    {
        _curUI.gameObject.SetActive(false);
        _curUI = null;
    }

    public void Mediate(PlayerProperty playerProperty)
    {
        _statusUI.SetProperty(playerProperty);
    }

    public void Mediate(PlayerInventory playerInventory)
    {
        _inventoryUI.SetProperty(playerInventory);
        _inventoryInChestUI.SetProperty(playerInventory);
    }

    public void Mediate(Chest chest)
    {
        _chestInventoryUI.SetProperty(chest);
    }
    
    private void Init()
    {

    }
}
