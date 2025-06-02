using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private List<Image> _inventoryList;

    [SerializeField] private Sprite _basicSprite;
    [SerializeField] private Sprite _forbidSprite;
    
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

            for (int i = _inventory.Count; i < _inventory.MaxCount; i++)
            {
                _inventoryList[i].sprite = _basicSprite;
            }
            
            for (int i = _inventory.MaxCount; i < _inventoryList.Count; i++)
            {
                _inventoryList[i].sprite = _forbidSprite;
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
