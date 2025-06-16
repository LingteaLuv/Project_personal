using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Slider _lightSlider;
    [SerializeField] private Slider _povSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _mouseSlider;
    
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _exitButton;

    private float _cacheBrightness;
    private float _cachePOV;
    private float _cacheSound;
    private float _cacheMouseSpeed;
    
    
    private void Awake()
    {
        Init();
    }
    
    
    private void Start()
    {
        _lightSlider.onValueChanged.AddListener((value)=> SettingManager.Instance.SetBrightness(value));
        _povSlider.onValueChanged.AddListener((value)=> SettingManager.Instance.SetFOV(value));
        _soundSlider.onValueChanged.AddListener((value)=> SettingManager.Instance.SetSound(value));
        _mouseSlider.onValueChanged.AddListener((value)=> SettingManager.Instance.SetMouseSpeed(value));
        
        _saveButton.onClick.AddListener(() => SettingSave());
        _exitButton.onClick.AddListener(()=>
        {
            SettingUpdate();
            gameObject.SetActive(false);
        });

        CacheInit();
        SettingUpdate();
        gameObject.SetActive(false);
    }

    private void CacheInit()
    {
        _cacheBrightness = SettingManager.Instance.Brightness.Value;
        _cachePOV = SettingManager.Instance.FOV.Value;
        _cacheSound = SettingManager.Instance.Sound.Value;
        _cacheMouseSpeed = SettingManager.Instance.MouseSpeed.Value;
    }
    
    private void SettingUpdate()
    {
        SettingManager.Instance.SetBrightness(_cacheBrightness);
        SettingManager.Instance.SetFOV(_cachePOV);
        SettingManager.Instance.SetSound(_cacheSound);
        
        _lightSlider.value = _cacheBrightness;
        _povSlider.value = _cachePOV;
        _soundSlider.value = _cacheSound;
        _mouseSlider.value = _cacheMouseSpeed;
    }
    
    private void SettingSave()
    {
        _cacheBrightness = _lightSlider.value;
        _cachePOV = _povSlider.value;
        _cacheSound = _soundSlider.value;
        _cacheMouseSpeed = _mouseSlider.value;
    }

    private void Init()
    {
        
    }
}
