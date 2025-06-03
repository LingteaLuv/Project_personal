using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : Singleton<SettingManager>
{
    private GameObject _settingUI;
    
    private bool _isOnSetting;
    public bool IsOnSetting => _isOnSetting;

    public Property<float> Brightness;
    public Property<float> FOV;
    public Property<float> Sound;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        Init();
    }

    public void Refer(GameObject settingUI)
    {
        _settingUI = settingUI;
        _settingUI.SetActive(false);
    }
    
    public void EnterSettingUI()
    {
        _settingUI.SetActive(true);
        _isOnSetting = true;
    }

    public void ExitSettingUI()
    {
        _settingUI.SetActive(false);
        _isOnSetting = false;
    }

    public void SetBrightness(float input)
    {
        Brightness.Value = input;
    }
    
    public void SetPOV(float input)
    {
        FOV.Value = input;
    }
    
    public void SetSound(float input)
    {
        Sound.Value = input;
    }
    
    private void Init()
    {
        _isOnSetting = false;
        
        Brightness = new Property<float>(0.5f);
        FOV = new Property<float>(0.5f);
        Sound = new Property<float>(0.5f);
    }
}
