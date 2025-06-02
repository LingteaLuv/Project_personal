using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Button _upBtn;
    [SerializeField] private Button _downBtn;
    
    
    private GameObject _chestInterface;
    public GameObject ChestInterface => _chestInterface;
    private void Awake()
    {
        Init();
    }
    
    private void Init()
    {
        _chestInterface = transform.GetChild(1).gameObject;
        _chestInterface.SetActive(false);
        _upBtn.onClick.AddListener(() => TransferManager.Instance.TransferAllToChest());
        _downBtn.onClick.AddListener(() => TransferManager.Instance.TransferAllToInventory());
    }
}