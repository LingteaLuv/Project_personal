using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public Property<bool> HasLantern;
    public Property<bool> HasCompass;
    public Property<bool> HasBackpack;

    private bool _isLoadingData;
    
    protected override void Awake()
    {
        base.Awake();
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }

    private void Start()
    {
        DataManager.Instance.OnGameLoaded += LoadItemData;
    }
    
    public void GetLantern()
    {
        HasLantern.Value = false;
    }

    public void GetCompass()
    {
        HasCompass.Value = false;
    }

    public void GetBackpack()
    {
        HasBackpack.Value = false;
    }

    private void LoadItemData()
    {
        _isLoadingData = true;
        
        HasBackpack.Value = DataManager.Instance.GameData.HasBackpack;
        HasCompass.Value = DataManager.Instance.GameData.HasCompass;
        HasLantern.Value = DataManager.Instance.GameData.HasLantern;

        _isLoadingData = false;
    }

    private void SaveItemData(bool value)
    {
        if (_isLoadingData) return;
        
        DataManager.Instance.GameData.HasBackpack = HasBackpack.Value;
        DataManager.Instance.GameData.HasCompass = HasCompass.Value;
        DataManager.Instance.GameData.HasLantern = HasLantern.Value;
    }
    
    private void Init()
    {
        HasBackpack = new Property<bool>(true);
        HasCompass = new Property<bool>(true);
        HasLantern = new Property<bool>(true);
        
        HasBackpack.OnChanged += SaveItemData;
        HasCompass.OnChanged += SaveItemData;
        HasLantern.OnChanged += SaveItemData;

        _isLoadingData = false;
    }
}
