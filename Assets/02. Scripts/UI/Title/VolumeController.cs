using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    private Volume _volume;
    private ColorAdjustments _color;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        BrightnessUpdate(SettingManager.Instance.Brightness.Value);
        SettingManager.Instance.Brightness.OnChanged += BrightnessUpdate;
    }

    private void BrightnessUpdate(float value)
    {
        float exposure = Mathf.Lerp(-1, 1, value);
        if (_color != null)
        {
            _color.postExposure.value = exposure;
        }
    }
    
    private void Init()
    {
        _volume = GetComponent<Volume>();
        if (_volume.profile.TryGet(out ColorAdjustments color))
        {
            _color = color;
        }
    }
}
