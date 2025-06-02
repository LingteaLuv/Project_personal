using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInChestUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private List<Image> _inventoryList;
    [SerializeField] private List<Button> _inventoryBtnList;

    [SerializeField] private Sprite _basicSprite;
    [SerializeField] private Sprite _forbidSprite;
    
    private PlayerInventory _inventory;

    private void Awake()
    {
        Init();
    }
    
    private void Start()
    {
        for (int i = 0; i < _inventoryBtnList.Count; i++)
        {
            int index = i;
            _inventoryBtnList[i].onClick.AddListener(() => OnChestButtonClicked(index));
        }
    }
    
    private void Update()
    {
        if (TransferManager.Instance.CurChest !=null)
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
    
    private void OnChestButtonClicked(int index)
    {
        Stuff stuff = _inventory.FindObject(index);
        TransferManager.Instance.TransferToChest(stuff);
    }
    
    public void SetProperty(PlayerInventory inventory)
    {
        _inventory = inventory;
    }
    
    private void Init()
    {
        _inventoryList = new List<Image>();
        _inventoryBtnList = new List<Button>();
        for (int i = 0; i < 10; i++)
        {
            Transform child = transform.GetChild(i);
            _inventoryList.Add(child.GetComponent<Image>());
            _inventoryBtnList.Add(child.GetComponent<Button>());
        }
    }
}
