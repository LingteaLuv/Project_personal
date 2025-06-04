using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBinder : Singleton<UIBinder>
{
    [Header("Drag&Drop")] 
    [SerializeField] private PauseUI _pauseUI;
    [SerializeField] private StatusUI _statusUI;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private InventoryInChestUI _inventoryInChestUI;
    [SerializeField] private ChestInventoryUI _chestInventoryUI;
    [SerializeField] private ChestUI _chestUI;
    [SerializeField] private CraftStuff _craftStuff;
    [SerializeField] private InventoryInCraftUI _inventoryInCraftUI;
    [SerializeField] private CraftResult _craftResult;

    public PauseUI GetPauseUI()
    {
        return _pauseUI;
    }
    
    public ChestUI GetChestUI()
    {
        return _chestUI;
    }

    public CraftStuff GetCraftUI()
    {
        return _craftStuff;
    }
    
    public void Mediate(PlayerProperty playerProperty)
    {
        _statusUI.SetProperty(playerProperty);
    }

    public void Mediate(PlayerInventory playerInventory)
    {
        _inventoryUI.SetProperty(playerInventory);
        _inventoryInChestUI.SetProperty(playerInventory);
        _inventoryInCraftUI.SetProperty(playerInventory);
    }

    public void Mediate(Chest chest)
    {
        _chestInventoryUI.SetProperty(chest);
    }

    public void Mediate(Crafting craftNPC)
    {
        _craftStuff.SetProperty(craftNPC);
        _craftResult.SetProperty(craftNPC);
    }
}
