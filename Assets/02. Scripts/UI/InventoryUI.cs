using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private List<Image> _inventoryList;

    [SerializeField] private Sprite _basicSprite;
    
    private PlayerInventory _inventory;
    private bool _isOpen;
    
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (_isOpen)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                _inventoryList[i].sprite = _inventory.FindObject(i).Icon;
            }

            for (int i = _inventory.Count; i < 10; i++)
            {
                _inventoryList[i].sprite = _basicSprite;
            }
        }
    }
    
    private void OnEnable()
    {
        _isOpen = true;
    }
    
    private void OnDisable()
    {
        _isOpen = false;
    }
    
    public void SetProperty(PlayerInventory inventory)
    {
        _inventory = inventory;
    }

    private void Init()
    {
        _isOpen = false;
    }
}
