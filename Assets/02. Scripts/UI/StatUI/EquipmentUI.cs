using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private TMP_Text _lanternText;
    [SerializeField] private TMP_Text _compassText;
    [SerializeField] private TMP_Text _backpackText;

    private bool _isOpen;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _isOpen = true;
    }
    
    private void OnDisable()
    {
        _isOpen = false;
    }
    
    private void Update()
    {
        if(_isOpen)
        {
            _lanternText.text = ItemManager.Instance.HasLantern.Value ? $"   Lantern : O" : $"   Lantern : X";
            _compassText.text = ItemManager.Instance.HasCompass.Value ? $"   Compass : O" : $"   Compass : X";
            _backpackText.text = ItemManager.Instance.HasBackpack.Value ? $"   Backpack : O" : $"   Backpack : X";
        }
    }

    

    private void Init()
    {
        
    }
}
