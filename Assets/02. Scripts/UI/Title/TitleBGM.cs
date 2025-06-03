using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGM : MonoBehaviour
{
    private AudioSource _source;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _source.volume = SettingManager.Instance.Sound.Value;
        SettingManager.Instance.Sound.OnChanged += SoundUpdate;
    }
    
    private void SoundUpdate(float input)
    {
        _source.volume = input;
    }

    private void Init()
    {
        _source = GetComponent<AudioSource>();
    }
}
