using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChestInventoryUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private List<Image> _chestInventoryList;
    [SerializeField] private List<Button> _chestInventoryBtnList;
    [SerializeField] private Sprite _basicSprite;
    private Chest _chest;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        for (int i = 0; i < _chestInventoryBtnList.Count; i++)
        {
            int index = i;
            _chestInventoryBtnList[i].onClick.AddListener(() => OnChestButtonClicked(index));
        }
    }

    private void OnChestButtonClicked(int index)
    {
        Stuff stuff = _chest.FindObject(index);
        TransferManager.Instance.TransferFromChest(stuff);
    }
    
    private void Update()
    {
        if (TransferManager.Instance.CurChest == _chest)
        {
            for (int i = 0; i < _chest.Count; i++)
            {
                _chestInventoryList[i].sprite = _chest.FindObject(i).Icon;
            }

            for (int i = _chest.Count; i < _chestInventoryList.Count; i++)
            {
                _chestInventoryList[i].sprite = _basicSprite;
            }
        }
    }
    
    public void SetProperty(Chest chest)
    {
        _chest = chest;
    }
    
    private void Init()
    {
        _chestInventoryList = new List<Image>();
        _chestInventoryBtnList = new List<Button>();
        for (int i = 0; i < 10; i++)
        {
            Transform child = transform.GetChild(i);
            _chestInventoryList.Add(child.GetComponent<Image>());
            _chestInventoryBtnList.Add(child.GetComponent<Button>());
        }
    }
}
