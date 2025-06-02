using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private StatusUI _statusUI;
    [SerializeField] private InventoryUI _inventoryUI;
    
    public GameObject _curUI;

    protected override void Awake()
    {
        base.Awake();
        Init();
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
    }
    
    private void Init()
    {

    }
}
